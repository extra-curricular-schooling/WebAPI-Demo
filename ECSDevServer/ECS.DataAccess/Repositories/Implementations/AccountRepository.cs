using ECS.DataAccess.Migrations;
using ECS.DataAccess.Models;
using ECS.DataAccess.Repositories.Contracts;

namespace ECS.DataAccess.Repositories.Implementations
{
    /// <summary>
    /// Account Repository using ECS DbContext connection
    /// </summary>
    public class AccountRepository : RepositoryBase<Account>, IAccountRepository
    {
        public AccountRepository() : base(new ECSContext())
        {
        }
    }
}
