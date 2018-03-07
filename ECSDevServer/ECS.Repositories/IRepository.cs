using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace ECS.Repositories
{
    public interface IRepository<T> : IDisposable
    {
        void Insert(T entity);

        void Delete(T entity);

        void Update(T entity);

        T GetById(int id);

        IQueryable<T> SearchFor(Expression<Func<T, bool>> predicate);

        IList<T> GetAll(params Expression<Func<T, object>>[] navigationProperties);

        T GetSingle(Func<T, bool> where, params Expression<Func<T, object>>[] navigationProperties);
    }
}