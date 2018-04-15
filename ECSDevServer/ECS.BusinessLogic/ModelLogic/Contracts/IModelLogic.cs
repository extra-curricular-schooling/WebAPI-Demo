using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECS.BusinessLogic.ModelLogic.Contracts
{
    public interface IModelLogic<T>
    {
        void Create(T entity);

        T GetSingle(string username);

        IList<T> GetAll(string username);

        void Update(T entity);

        void Delete(T partialAccountSalt);
    }
}
