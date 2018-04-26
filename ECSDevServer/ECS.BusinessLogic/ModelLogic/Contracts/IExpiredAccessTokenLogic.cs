using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECS.Models;

namespace ECS.BusinessLogic.ModelLogic.Contracts
{
    /// <summary>
    /// ExpiredAccessToken business logic contract
    /// </summary>
    public interface IExpiredAccessTokenLogic
    {
        void Create(ExpiredAccessToken badAccessToken);

        ExpiredAccessToken GetExpiredAccessToken(string token);

        List<ExpiredAccessToken> GetExpiredAccessTokens(string token);

        bool Exists(string token);

        void Update(ExpiredAccessToken badAccessToken);

    }
}
