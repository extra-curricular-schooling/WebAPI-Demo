using ECS.Models;
using ECS.Repositories.Implementations;
using System;

namespace ECS.BusinessLogic.ModelLogic.Implementations
{
    public class LinkedinLogic : Contracts.ILinkedinLogic
    {
        #region Constants and fields
        private readonly ILinkedInAccessTokenRepository _linkedInAccessTokenRepository;
        #endregion

        public LinkedinLogic()
        {
            _linkedInAccessTokenRepository = new LinkedInAccessTokenRepository();
        }

        public bool CheckForExpiredLinkedInAccessToken(LinkedInAccessToken token)
        {
            if (token.TokenCreation.AddDays(60).CompareTo(DateTime.Now.ToUniversalTime()) <= 0 || token.Expired == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool CheckForLinkedInAccessToken(string username)
        {
            return _linkedInAccessTokenRepository.Exists(d => d.UserName == username, d => d.Account);
        }

        public LinkedInAccessToken GetLinkedInAccessToken(string username)
        {
            try
            {
                return _linkedInAccessTokenRepository.GetSingle(d => d.UserName == username, d => d.Account);
            }
            catch (Exception)
            {
                return null;
            }          
        }

        public bool InsertLinkedInAccessToken(LinkedInAccessToken token)
        {
            try
            {
                _linkedInAccessTokenRepository.Insert(token);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool InvalidateLinkedInAccessToken(LinkedInAccessToken token)
        {
            token.Expired = true;
            return UpdateLinkedInAccessToken(token);
        }

        public bool UpdateLinkedInAccessToken(LinkedInAccessToken token)
        {
            try
            {
                _linkedInAccessTokenRepository.Update(token);
                return true;
            } catch (Exception)
            {
                return false;
            }
        }
    }
}
