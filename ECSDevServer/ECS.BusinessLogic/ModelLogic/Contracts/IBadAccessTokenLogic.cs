using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECS.Models;

namespace ECS.BusinessLogic.ModelLogic.Contracts
{
    public interface IBadAccessTokenLogic
    {
        void Create(BadAccessToken badAccessToken);

        BadAccessToken GetBadAccessToken(string token);

        List<BadAccessToken> GetBadAccessTokens(string token);

        bool Exists(string token);

        void Update(BadAccessToken badAccessToken);
    }
}
