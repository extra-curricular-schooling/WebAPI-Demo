using ECS.DTO;
using ECS.Models;
using System;

namespace ECS.BusinessLogic.ModelLogic.Contracts
{
    public interface ILinkedinLogic
    {
        bool CheckForLinkedInAccessToken(string username);
        bool CheckForExpiredLinkedInAccessToken(LinkedInAccessToken token);
        LinkedInAccessToken GetLinkedInAccessToken(string username);
        bool InvalidateLinkedInAccessToken(LinkedInAccessToken token);
        bool InsertLinkedInAccessToken (LinkedInAccessToken token);
        Object SharePost(LinkedInAccessToken linkedInAccessToken, LinkedInPostDTO linkedInPostDTO);
        bool UpdateLinkedInAccessToken (LinkedInAccessToken token);
    }
}
