using ECS.DTO;
using ECS.Models;
using System;

namespace ECS.BusinessLogic.ModelLogic.Contracts
{
    /// <summary>
    /// LinkedIn business logic contract
    /// </summary>
    public interface ILinkedinLogic
    {
        bool CheckForLinkedInAccessToken(string username);

        bool CheckForExpiredLinkedInAccessToken(LinkedInAccessToken token);

        LinkedInAccessToken GetLinkedInAccessToken(string username);

        bool InvalidateLinkedInAccessToken(LinkedInAccessToken token);

        bool InsertLinkedInAccessToken (LinkedInAccessToken token);

        bool UpdateLinkedInAccessToken (LinkedInAccessToken token);
    }
}
