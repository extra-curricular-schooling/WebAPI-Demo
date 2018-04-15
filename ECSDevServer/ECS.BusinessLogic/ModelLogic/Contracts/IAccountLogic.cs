using ECS.Models;

namespace ECS.BusinessLogic.ModelLogic.Contracts
{
    public interface IAccountLogic
    {
        void Create(Account account);
        void Read(Account account);
        void Update(Account account);
    }
}
