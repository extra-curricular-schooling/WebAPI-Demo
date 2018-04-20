using System;
using System.Collections.Generic;
using System.Net;
using ECS.BusinessLogic.ModelLogic.Implementations;
using System.Net.Http;
using ECS.DTO;
using ECS.Models;
using ECS.Security.Hash;

namespace ECS.BusinessLogic.ControllerLogic.Implementations
{
    public class RegistrationControllerLogic
    {
        private const string BaseClientUrl = "http://localhost:8080/";

        private readonly AccountLogic _accountLogic;
        private readonly PartialAccountLogic _partialAccountLogic;
        private readonly SaltLogic _saltLogic;
        private readonly PartialAccountSaltLogic _partialAccountSaltLogic;
        private readonly JAccessTokenLogic _jAccessTokenLogic;
        private readonly ExpiredAccessTokenLogic _expiredAccessTokenLogic;
        private readonly UserProfileLogic _userProfileLogic;

        public RegistrationControllerLogic()
        {
            _userProfileLogic = new UserProfileLogic();
            _jAccessTokenLogic = new JAccessTokenLogic();
            _expiredAccessTokenLogic = new ExpiredAccessTokenLogic();
            _saltLogic = new SaltLogic();
            _partialAccountSaltLogic = new PartialAccountSaltLogic();
            _accountLogic = new AccountLogic();
            _partialAccountLogic = new PartialAccountLogic();
        }

        public RegistrationControllerLogic(AccountLogic accountLogic, PartialAccountLogic partialAccountLogic, 
            PartialAccountSaltLogic partialAccountSaltLogic, SaltLogic saltLogic, JAccessTokenLogic jAccessTokenLogic, 
            ExpiredAccessTokenLogic expiredAccessTokenLogic, UserProfileLogic userProfileLogic)
        {
            _accountLogic = accountLogic;
            _partialAccountLogic = partialAccountLogic;
            _partialAccountSaltLogic = partialAccountSaltLogic;
            _saltLogic = saltLogic;
            _jAccessTokenLogic = jAccessTokenLogic;
            _expiredAccessTokenLogic = expiredAccessTokenLogic;
            _userProfileLogic = userProfileLogic;
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
                    PermissionName = "canEditInformation",
                    Username = registrationForm.Username
                },
                new AccountType()
                {
                    PermissionName = "canViewArticle",
                    Username = registrationForm.Username
                },
                new AccountType()
                {
                    PermissionName = "canEnterRaffle",
                    Username = registrationForm.Username
                },
                new AccountType()
                {
                    PermissionName = "canShareLinkedIn",
                    Username = registrationForm.Username
                }
            };

            List<ZipLocation> zipLocations = new List<ZipLocation>
            {
                new ZipLocation
                {
                    ZipCode = registrationForm.ZipCode.ToString(),
                    Address = registrationForm.Address,
                    City = registrationForm.City,
                    State = registrationForm.State
                }
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

        public HttpResponseMessage FinishRegistration(RegistrationDTO registrationForm)
        {
            // Fetch: Check if user already exists
            var partialAccountModel = _partialAccountLogic.GetPartialAccount(registrationForm.Username);
            var partialAccountSaltModel = _partialAccountSaltLogic.GetSingle(registrationForm.Username);

            // Validate: Validate Domain Models
            if (partialAccountModel == null)
            {
                return new HttpResponseMessage
                {
                    ReasonPhrase = "Account does not exist",
                    StatusCode = HttpStatusCode.BadRequest
                };
            }
            if (partialAccountSaltModel == null)
            {
                return new HttpResponseMessage
                {
                    ReasonPhrase = "Salt does not exist",
                    StatusCode = HttpStatusCode.InternalServerError
                };
            }

            // Create: Temporary Objects
            List<ZipLocation> zipLocations = new List<ZipLocation>
            {
                new ZipLocation
                {
                    ZipCode = registrationForm.ZipCode.ToString(),
                    Address = registrationForm.Address,
                    City = registrationForm.City,
                    State = registrationForm.State
                }
            };

            // TODO: @Scott Change the salts for each of the hashed answers. They should all be different.
            var hashedAnswer1 = HashService.Instance.HashPasswordWithSalt(partialAccountSaltModel.PasswordSalt, registrationForm.SecurityQuestions[0].Answer, true);
            var hashedAnswer2 = HashService.Instance.HashPasswordWithSalt(partialAccountSaltModel.PasswordSalt, registrationForm.SecurityQuestions[1].Answer, true);
            var hashedAnswer3 = HashService.Instance.HashPasswordWithSalt(partialAccountSaltModel.PasswordSalt, registrationForm.SecurityQuestions[2].Answer, true);

            List<SecurityQuestionAccount> securityQuestionAccountListObj = new List<SecurityQuestionAccount>
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

            Account account = new Account()
            {
                UserName = partialAccountModel.UserName,
                Email = registrationForm.Email,
                Password = partialAccountModel.Password,
                Points = 0,
                AccountStatus = true,
                SuspensionTime = DateTime.UtcNow,  // TODO: @Trish
                FirstTimeUser = true,
                SecurityAnswers = securityQuestionAccountListObj
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
                // Enter the user,
                // which enters the account and zipLocations by navigation property,
                // which enters the the securityAnswers by navigation property.
                _userProfileLogic.Create(user);

                // Enter the salt (it is not chained with the other tables).
                _saltLogic.Create(salt);

                // Delete old Partial Account
                // TODO: @Scott The partial accounts need to be deleted after finishing registration, but they won't delete.
                //partialAccountSaltRepository.Delete(partialAccountSaltRepository.GetSingle(s => s.UserName == partialAccountModel.UserName));
                //partialAccountRepository.Delete(partialAccountRepository.GetSingle(acc => acc.UserName == partialAccountModel.UserName));
                return new HttpResponseMessage(HttpStatusCode.OK);

            }
            catch (Exception ex)
            {
                //string summary = "Data Access Error";
                //string source = ex.Source;
                //string message = ex.Message;
                //string stackTrace = ex.StackTrace;

                //var error = new
                //{
                //    summary,
                //    source,
                //    message,
                //    stackTrace
                //};

                return new HttpResponseMessage
                {
                    ReasonPhrase = ex.Message,
                    StatusCode = HttpStatusCode.InternalServerError
                };
            }
            
        }
    }

    
}
