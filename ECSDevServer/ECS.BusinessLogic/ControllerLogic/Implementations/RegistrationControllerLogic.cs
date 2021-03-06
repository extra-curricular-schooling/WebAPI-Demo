﻿using System;
using System.Collections.Generic;
using System.Net;
using ECS.BusinessLogic.ModelLogic.Implementations;
using System.Net.Http;
using ECS.BusinessLogic.ModelLogic.Contracts;
using ECS.Constants.Security;
using ECS.DTO;
using ECS.Models;
using ECS.Security.Hash;
using ECS.Constants.Data_Access;
using System.Web.Script.Serialization;
using ECS.Security.AccessTokens.Jwt;

namespace ECS.BusinessLogic.ControllerLogic.Implementations
{
    public class RegistrationControllerLogic
    {
        private readonly AccountLogic _accountLogic;
        private readonly PartialAccountLogic _partialAccountLogic;
        private readonly SaltLogic _saltLogic;
        private readonly PartialAccountSaltLogic _partialAccountSaltLogic;
        private readonly UserProfileLogic _userProfileLogic;
        private readonly SecurityQuestionLogic _securityQuestionLogic;

        public RegistrationControllerLogic()
        {
            _userProfileLogic = new UserProfileLogic();
            _saltLogic = new SaltLogic();
            _partialAccountSaltLogic = new PartialAccountSaltLogic();
            _accountLogic = new AccountLogic();
            _partialAccountLogic = new PartialAccountLogic();
            _securityQuestionLogic = new SecurityQuestionLogic();
        }

        public RegistrationControllerLogic(AccountLogic accountLogic, PartialAccountLogic partialAccountLogic, 
            PartialAccountSaltLogic partialAccountSaltLogic, SaltLogic saltLogic, UserProfileLogic userProfileLogic,
            SecurityQuestionLogic securityQuestionLogic)
        {
            _accountLogic = accountLogic;
            _partialAccountLogic = partialAccountLogic;
            _partialAccountSaltLogic = partialAccountSaltLogic;
            _saltLogic = saltLogic;
            _userProfileLogic = userProfileLogic;
            _securityQuestionLogic = securityQuestionLogic;
        }


        /// <summary>
        /// Logic that takes form properties and inserts to context
        /// </summary>
        /// <param name="registrationForm"></param>
        /// <returns></returns>
        public HttpResponseMessage Registration(RegistrationDTO registrationForm)
        {

            // Check if user already exists
            if (_accountLogic.Exists(registrationForm.Username))
            {
                return new HttpResponseMessage
                {
                    ReasonPhrase = "Username Exists",
                    StatusCode = HttpStatusCode.Conflict
                };
            }

            // Create salts and hash password and answers to security questions
            var pSalt = HashService.Instance.CreateSaltKey();
            var aSalt1 = HashService.Instance.CreateSaltKey();
            var aSalt2 = HashService.Instance.CreateSaltKey();
            var aSalt3 = HashService.Instance.CreateSaltKey();

            var hashedPassword = HashService.Instance.HashPasswordWithSalt(pSalt, registrationForm.Password, true);

            var hashedAnswer1 = HashService.Instance.HashPasswordWithSalt(aSalt1, registrationForm.SecurityQuestions[0].Answer, true);
            var hashedAnswer2 = HashService.Instance.HashPasswordWithSalt(aSalt2, registrationForm.SecurityQuestions[1].Answer, true);
            var hashedAnswer3 = HashService.Instance.HashPasswordWithSalt(aSalt3, registrationForm.SecurityQuestions[2].Answer, true);


            // Collections representing child models of Account
            List<SaltSecurityAnswer> saltSecurityAnswers = new List<SaltSecurityAnswer>
            {
                new SaltSecurityAnswer
                {
                    SaltValue = aSalt1,
                    UserName = registrationForm.Username,
                    SecurityQuestionID = registrationForm.SecurityQuestions[0].Question
                },
                new SaltSecurityAnswer
                {
                    SaltValue = aSalt2,
                    UserName = registrationForm.Username,
                    SecurityQuestionID = registrationForm.SecurityQuestions[1].Question
                },
                new SaltSecurityAnswer
                {
                    SaltValue = aSalt3,
                    UserName = registrationForm.Username,
                    SecurityQuestionID = registrationForm.SecurityQuestions[2].Question
                },
            };

            List<SecurityQuestionAccount> securityAnswers = new List<SecurityQuestionAccount>
            {
                new SecurityQuestionAccount
                {
                    Answer = hashedAnswer1,
                    SecurityQuestionID = registrationForm.SecurityQuestions[0].Question,
                    Username = registrationForm.Username
                },
                new SecurityQuestionAccount
                {
                    Answer = hashedAnswer2,
                    SecurityQuestionID = registrationForm.SecurityQuestions[1].Question,
                    Username = registrationForm.Username
                },
                new SecurityQuestionAccount
                {
                    Answer = hashedAnswer3,
                    SecurityQuestionID = registrationForm.SecurityQuestions[2].Question,
                    Username = registrationForm.Username
                }
            };

            List<AccountType> accountTypes = new List<AccountType>
            {
                new AccountType()
                {
                    PermissionName = ClaimValues.Scholar,
                    Username = registrationForm.Username
                },
                new AccountType()
                {
                    PermissionName = ClaimValues.CanEditInformation,
                    Username = registrationForm.Username
                },
                new AccountType()
                {
                    PermissionName = ClaimValues.CanViewArticle,
                    Username = registrationForm.Username
                },
                new AccountType()
                {
                    PermissionName = ClaimValues.CanEnterRaffle,
                    Username = registrationForm.Username
                },
                new AccountType()
                {
                    PermissionName = ClaimValues.CanShareLinkedIn,
                    Username = registrationForm.Username
                }
            };

            List<ZipLocation> zipLocations = new List<ZipLocation>
            {
                CreateZipLocationHelper(registrationForm.Address, registrationForm.City, registrationForm.State, registrationForm.ZipCode.ToString())
            };

            // Account model child to UserProfile
            Account account = new Account
            {
                UserName = registrationForm.Username,
                Email = registrationForm.Email,
                Password = hashedPassword,
                Points = 0,
                AccountStatus = true,
                SuspensionTime = DateTime.UtcNow,
                FirstTimeUser = true,
                SecurityAnswers = securityAnswers, // Navigation Property
                AccountTags = new List<InterestTag>(), // Navigation Property
                SaltSecurityAnswers = saltSecurityAnswers, // Navigation Property
                AccountTypes = accountTypes // Navigation Property
            };

            UserProfile user = new UserProfile()
            {
                Email = registrationForm.Email,
                FirstName = registrationForm.FirstName,
                LastName = registrationForm.LastName,
                ZipLocations = zipLocations,
                Account = account // Navigation Property
            };

            Salt salt = new Salt()
            {
                PasswordSalt = pSalt,
                UserName = registrationForm.Username
            };

            try
            {
                _userProfileLogic.Create(user);
                _saltLogic.Create(salt);

                return new HttpResponseMessage(HttpStatusCode.OK);

            }
            catch (Exception ex)
            {   
                return new HttpResponseMessage
                {
                    ReasonPhrase = ex.Message,
                    StatusCode = HttpStatusCode.InternalServerError
                };
            }
        }

        /// <summary>
        /// Business Logic to complete registration for PartialAccounts
        /// </summary>
        /// <param name="registrationForm"></param>
        /// <returns></returns>
        public HttpResponseMessage FinishRegistration(RegistrationDTO registrationForm)
        {
            // Fetch: Check if user already exists
            var userModel = _userProfileLogic.GetSingle(registrationForm.Email);
            var partialAccountModel = _partialAccountLogic.GetPartialAccount(registrationForm.Username);
            var partialAccountSaltModel = _partialAccountSaltLogic.GetSingle(registrationForm.Username);
            
            if (userModel != null)
            {
                return new HttpResponseMessage
                {
                    ReasonPhrase = "User already exists.",
                    Content = new StringContent("User already exists"),
                    StatusCode = HttpStatusCode.Conflict
                };
            }
            if (partialAccountModel == null)
            {
                return new HttpResponseMessage
                {
                    ReasonPhrase = "Partial account does not exist",
                    Content = new StringContent("Partial account does not exist"),
                    StatusCode = HttpStatusCode.BadRequest
                };
            }
            
            if (partialAccountSaltModel == null)
            {
                return new HttpResponseMessage
                {
                    ReasonPhrase = "Salt does not exist",
                    Content = new StringContent("Salt does not exist"),
                    StatusCode = HttpStatusCode.InternalServerError
                };
            }


            // Create: Temporary Objects
            List<ZipLocation> zipLocations = new List<ZipLocation>
            {
                CreateZipLocationHelper(registrationForm.Address, registrationForm.City, registrationForm.State, registrationForm.ZipCode.ToString())
                //new ZipLocation
                //{
                //    ZipCode = registrationForm.ZipCode.ToString(),
                //    Address = registrationForm.Address,
                //    City = registrationForm.City,
                //    State = registrationForm.State
                //}
            };

            // Create Salts
            var aSalt1 = HashService.Instance.CreateSaltKey();
            var aSalt2 = HashService.Instance.CreateSaltKey();
            var aSalt3 = HashService.Instance.CreateSaltKey();

            var hashedAnswer1 = HashService.Instance.HashPasswordWithSalt(aSalt1, registrationForm.SecurityQuestions[0].Answer, true);
            var hashedAnswer2 = HashService.Instance.HashPasswordWithSalt(aSalt2, registrationForm.SecurityQuestions[1].Answer, true);
            var hashedAnswer3 = HashService.Instance.HashPasswordWithSalt(aSalt3, registrationForm.SecurityQuestions[2].Answer, true);


            // Temporary Collections
            List<SecurityQuestionAccount> securityAnswers = new List<SecurityQuestionAccount>
            {
                new SecurityQuestionAccount
                {
                    Answer = hashedAnswer1,
                    SecurityQuestionID = registrationForm.SecurityQuestions[0].Question,
                    Username = registrationForm.Username
                },
                new SecurityQuestionAccount
                {
                    Answer = hashedAnswer2,
                    SecurityQuestionID = registrationForm.SecurityQuestions[1].Question,
                    Username = registrationForm.Username
                },
                new SecurityQuestionAccount
                {
                    Answer = hashedAnswer3,
                    SecurityQuestionID = registrationForm.SecurityQuestions[2].Question,
                    Username = registrationForm.Username
                }
            };

            List<SaltSecurityAnswer> saltSecurityAnswers = new List<SaltSecurityAnswer>
            {
                new SaltSecurityAnswer
                {
                    SaltValue = aSalt1,
                    UserName = registrationForm.Username,
                    SecurityQuestionID = registrationForm.SecurityQuestions[0].Question
                },
                new SaltSecurityAnswer
                {
                    SaltValue = aSalt2,
                    UserName = registrationForm.Username,
                    SecurityQuestionID = registrationForm.SecurityQuestions[1].Question
                },
                new SaltSecurityAnswer
                {
                    SaltValue = aSalt3,
                    UserName = registrationForm.Username,
                    SecurityQuestionID = registrationForm.SecurityQuestions[2].Question
                },
            };

            List<AccountType> accountTypes = new List<AccountType>
            {
                new AccountType()
                {
                    PermissionName = ClaimValues.Scholar,
                    Username = registrationForm.Username
                },
                new AccountType()
                {
                    PermissionName = ClaimValues.CanEditInformation,
                    Username = registrationForm.Username
                },
                new AccountType()
                {
                    PermissionName = ClaimValues.CanViewArticle,
                    Username = registrationForm.Username
                },
                new AccountType()
                {
                    PermissionName = ClaimValues.CanEnterRaffle,
                    Username = registrationForm.Username
                },
                new AccountType()
                {
                    PermissionName = ClaimValues.CanShareLinkedIn,
                    Username = registrationForm.Username
                }
            };

            Account account = new Account()
            {
                UserName = partialAccountModel.UserName,
                Email = registrationForm.Email,
                Password = partialAccountModel.Password,
                Points = 0,
                AccountStatus = true,
                SuspensionTime = DateTime.UtcNow,
                FirstTimeUser = true,
                SecurityAnswers = securityAnswers, 
                AccountTags = new List<InterestTag>(), 
                SaltSecurityAnswers = saltSecurityAnswers, 
                AccountTypes = accountTypes 
            };

            UserProfile user = new UserProfile()
            {
                Email = registrationForm.Email,
                FirstName = registrationForm.FirstName,
                LastName = registrationForm.LastName,
                ZipLocations = zipLocations,
                Account = account
            };

            Salt salt = new Salt()
            {
                PasswordSalt = partialAccountSaltModel.PasswordSalt,
                UserName = registrationForm.Username,
            };

            try
            {
                // Enter the user, which then chains all of the navigation properties
                // into one transaction.
                _userProfileLogic.Create(user);

                // Enter the salt (it is not chained with the other tables).
                _saltLogic.Create(salt);

                // Delete old Partial Account
                _partialAccountLogic.Delete(partialAccountModel);

                // TODO: @Scott Might need a hot fix here for tokens in partial registration.
                var token = JwtManager.Instance.GenerateToken(accountTypes);

                return new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent(token)
                };

            }
            catch (Exception ex)
            {
                return new HttpResponseMessage
                {
                    ReasonPhrase = ex.Message,
                    StatusCode = HttpStatusCode.InternalServerError
                };
            }
        }

        /// <summary>
        /// Gets security questions
        /// </summary>
        /// <returns></returns>
        public HttpResponseMessage SecurityQuestions()
        {
            try
            {
                List<SecurityQuestion> allQuestions = _securityQuestionLogic.GetAllQuestions();

                // Return unavailable if no security questions in db
                if (allQuestions.Count == 0)
                {
                    return new HttpResponseMessage
                    {
                        StatusCode = HttpStatusCode.ServiceUnavailable
                    };
                }

                // else serialize questions and assign into String Content
                var content = new JavaScriptSerializer().Serialize(allQuestions);
                var stringContent = new StringContent(content);

                return new HttpResponseMessage
                {
                    Content = stringContent,
                    StatusCode = HttpStatusCode.OK
                };

            } catch (Exception ex)
            {
                return new HttpResponseMessage
                {
                    ReasonPhrase = ex.Message,
                    StatusCode = HttpStatusCode.InternalServerError
                };
            }
        }

        /// <summary>
        /// Helper method to check for empty values and create a new ZipLocation
        /// </summary>
        /// <param name="address"></param>
        /// <param name="city"></param>
        /// <param name="state"></param>
        /// <param name="zipCode"></param>
        /// <returns></returns>
        private ZipLocation CreateZipLocationHelper(string address, string city, string state, string zipCode)
        {
            if (address == "")
            {
                address = ZipLocationProperties.Address;
            }

            if (city == "")
            {
                city = ZipLocationProperties.City;
            }

            if (state == "")
            {
                state = ZipLocationProperties.State;
            }

            if (zipCode == "0")
            {
                zipCode = ZipLocationProperties.ZipCode;
            }

            return new ZipLocation
            {
                Address = address,
                City = city,
                State = state,
                ZipCode = zipCode
            };
        }
    }
}
