using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECS.WebAPI.Services.Security
{
    public interface IHashService
    {
        string CreateSaltKey();
        string HashPasswordWithSalt(string salt, string password);
    }
}
