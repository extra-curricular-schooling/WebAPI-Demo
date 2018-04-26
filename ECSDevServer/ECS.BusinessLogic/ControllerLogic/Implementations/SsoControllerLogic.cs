using System;
using System.Data;
using System.Net;
using System.Net.Http;
using ECS.BusinessLogic.ModelLogic.Implementations;
using ECS.Constants.Network;
using ECS.DTO.Sso;
using ECS.Models;
using ECS.Security.AccessTokens.Jwt;
using ECS.Security.Hash;

namespace ECS.BusinessLogic.ControllerLogic.Implementations
{
    public class  SsoControllerLogic
    {
        private readonly AccountLogic _accountLogic;
        private readonly PartialAccountLogic _partialAccountLogic;
        private readonly SaltLogic _saltLogic;
        private readonly PartialAccountSaltLogic _partialAccountSaltLogic;
        private readonly JAccessTokenLogic _jAccessTokenLogic;
        private readonly ExpiredAccessTokenLogic _expiredAccessTokenLogic;

        public SsoControllerLogic()
        {
            _jAccessTokenLogic = new JAccessTokenLogic();
            _expiredAccessTokenLogic = new ExpiredAccessTokenLogic();
            _saltLogic = new SaltLogic();
            _partialAccountSaltLogic = new PartialAccountSaltLogic();
            _accountLogic = new AccountLogic();
            _partialAccountLogic = new PartialAccountLogic();
        }

        public SsoControllerLogic(AccountLogic accountLogic, PartialAccountLogic partialAccountLogic, 
            PartialAccountSaltLogic partialAccountSaltLogic, SaltLogic saltLogic, JAccessTokenLogic jAccessTokenLogic, 
            ExpiredAccessTokenLogic expiredAccessTokenLogic)
        {
            _accountLogic = accountLogic;
            _partialAccountLogic = partialAccountLogic;
            _partialAccountSaltLogic = partialAccountSaltLogic;
            _saltLogic = saltLogic;
            _jAccessTokenLogic = jAccessTokenLogic;
            _expiredAccessTokenLogic = expiredAccessTokenLogic;
        }

        public HttpResponseMessage RegisterPartialAccount(SsoRegistrationRequestDTO registrationDto)
        {
            // Validation Step
            if (_partialAccountLogic.Exists(registrationDto.Username) ||
                _accountLogic.Exists(registrationDto.Username))
            {
                return new HttpResponseMessage
                {
                    Content = new StringContent("Account already exists"),
                    StatusCode = HttpStatusCode.Conflict
                };
            }

            // Add new PartialAccount to the database
            var partialAccount = new PartialAccount()
            {
                UserName = registrationDto.Username,
                Password = registrationDto.HashedPassword,
                AccountType = registrationDto.RoleType
            };

            // Add new attached Salt to the database connected with PartialAccount.
            var salt = new PartialAccountSalt()
            {
                PasswordSalt = registrationDto.PasswordSalt,
                UserName = registrationDto.Username,
                PartialAccount = partialAccount
            };
            _partialAccountSaltLogic.Create(salt);

            return new HttpResponseMessage(HttpStatusCode.OK);
        }

        public HttpResponseMessage Login(SsoLoginRequestDTO loginDto)
        {
            // Partial Account will be null or Account will be null.

            var partialAccount = _partialAccountLogic.GetPartialAccount(loginDto.Username);
            var account = _accountLogic.GetSingle(loginDto.Username);

            // Validate

            //if (partialAccount == null && account == null)
            //{
            //    return new HttpResponseMessage
            //    {
            //        ReasonPhrase = "Invalid Credentials",
            //        StatusCode = HttpStatusCode.BadRequest
            //    };
            //}

            //if (partialAccount != null && account != null)
            //{
            //    return new HttpResponseMessage
            //    {
            //        ReasonPhrase = "Database Inconsistency",
            //        StatusCode = HttpStatusCode.InternalServerError
            //    };
            //}

            if (partialAccount != null)
            {
                return PartialAccountLoginHelper(loginDto, partialAccount);
            }

            if (account != null)
            {
                return AccountLoginHelper(loginDto, account);
            }

            return new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.InternalServerError
            };
        }

        private HttpResponseMessage PartialAccountLoginHelper(SsoLoginRequestDTO loginDto, PartialAccount partialAccount)
        { 
            // Provide Partial Account RoleType
            loginDto.RoleType = partialAccount.AccountType;

            // Generate our token for them.
            var partialAccountToken = SsoJwtManager.Instance.GenerateToken(loginDto);

            return new HttpResponseMessage
            {
                Content = new StringContent(UrlConstants.BaseAppClient + "partial-registration?jwt=" + partialAccountToken),
                StatusCode = HttpStatusCode.OK
            };
        }

        private HttpResponseMessage AccountLoginHelper(SsoLoginRequestDTO loginDto, Account account)
        {
            var saltModel = _saltLogic.GetSalt(loginDto.Username);
            // TODO: @Scott Check if the Saltmodel.Account is still null
            if (saltModel == null)
            {
                return new HttpResponseMessage
                {
                    Content = new StringContent("Database does not contain salt"),
                    StatusCode = HttpStatusCode.InternalServerError
                };
            }

            // Make sure you append the salt, not prepend (group decision).
            var hashedPassword = HashService.Instance.HashPasswordWithSalt(saltModel.PasswordSalt, loginDto.Password, true);

            if (!account.Password.Equals(hashedPassword))
            {
                return new HttpResponseMessage
                {
                    Content = new StringContent("Hashed Password mismatch account password"),
                    StatusCode = HttpStatusCode.Unauthorized
                };
            }

            var token = JwtManager.Instance.GenerateToken(loginDto.Username);

            // Grab the previous access token associated with the account.
            var accountAccessToken = _jAccessTokenLogic.GetJAccessToken(loginDto.Username);
            if (accountAccessToken != null)
            {
                // Set current account token to expired list.
                var expiredToken = new ExpiredAccessToken(accountAccessToken.Value, false);
                _expiredAccessTokenLogic.Create(expiredToken);

                // Updated new access token.
                accountAccessToken.Value = token;
                _jAccessTokenLogic.Update(accountAccessToken);
            }

            // Redirect them to our Home page with their credentials logged.
            return new HttpResponseMessage
            {
                Content = new StringContent(UrlConstants.BaseAppClient + "home?jwt=" + token),
                ReasonPhrase = "Redirected",
                StatusCode = HttpStatusCode.OK
            };
        }

        public HttpResponseMessage ResetPassword(SsoResetPasswordRequestDTO resetPasswordDto)
        {
            // Partial Account will be null or Account will be null.

            var partialAccount = _partialAccountLogic.GetPartialAccount(resetPasswordDto.Username);
            var account = _accountLogic.GetSingle(resetPasswordDto.Username);

            // Validate

            if (partialAccount == null && account == null)
            {
                return new HttpResponseMessage
                {
                    Content = new StringContent("Invalid Credentials"),
                    StatusCode = HttpStatusCode.BadRequest
                };
            }

            if (partialAccount != null && account != null)
            {
                return new HttpResponseMessage
                {
                    Content = new StringContent("Database Inconsistency"),
                    StatusCode = HttpStatusCode.InternalServerError
                };
            }

            if (partialAccount != null)
            {
                return PartialAccountResetPasswordHelper(resetPasswordDto, partialAccount);
            }

            if (account != null)
            {
                return AccountResetPasswordHelper(resetPasswordDto, account);
            }

            // Login Failure
            return new HttpResponseMessage(HttpStatusCode.InternalServerError);
        }

        private HttpResponseMessage PartialAccountResetPasswordHelper(SsoResetPasswordRequestDTO resetPasswordDto,
            PartialAccount partialAccount)
        {
            // Update password for account
            partialAccount.Password = resetPasswordDto.HashedNewPassword;
            _partialAccountLogic.Update(partialAccount);

            // Update salt table related to account
            var partialAccountSalt = _partialAccountSaltLogic.GetSingle(resetPasswordDto.Username);
            partialAccountSalt.PasswordSalt = resetPasswordDto.PasswordSalt;
            _partialAccountSaltLogic.Update(partialAccountSalt);

            return new HttpResponseMessage(HttpStatusCode.OK);
        }

        private HttpResponseMessage AccountResetPasswordHelper(SsoResetPasswordRequestDTO resetPasswordDto,
            Account account)
        {
            // Update password for account
            account.Password = resetPasswordDto.HashedNewPassword;
            _accountLogic.Update(account);

            // Update salt table related to account
            var accountSalt = _saltLogic.GetSalt(resetPasswordDto.Username);
            accountSalt.PasswordSalt = resetPasswordDto.PasswordSalt;
            _saltLogic.Update(accountSalt);

            return new HttpResponseMessage(HttpStatusCode.OK);
        }
    }
}
