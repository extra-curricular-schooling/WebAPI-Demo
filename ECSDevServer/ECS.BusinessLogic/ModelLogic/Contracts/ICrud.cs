using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECS.BusinessLogic.ModelLogic.Contracts
{
    public interface ICrud<T> where T : class
    {
        bool Create(Object entity);

        T GetSingle(Object key);

        T FilterBy(Object key);

        bool Update(Object entity);

        bool Delete(Object entity);
    }

    public interface ICrud
    {
        bool Create(Object entity);

        Object GetSingle(Object key);

        Object FilterBy(Object key);

        bool Update(Object entity);

        bool Delete(Object entity);
    }
}
