using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ECS.DataAccess.Repositories.Contracts
{
    public interface IRepositoryBase<T> : IDisposable
    {
        /// <summary>
        /// Add an entity to the repository
        /// </summary>
        /// <param name="entity"></param>
        void Insert(T entity);

        /// <summary>
        /// Delete an entity from the repository.
        /// </summary>
        /// <param name="entity"></param>
        void Delete(T entity);

        /// <summary>
        /// Update an entity in the repository
        /// </summary>
        /// <param name="entity"></param>
        void Update(T entity);

        /// <summary>
        /// LINQ to SQL search for the Generic Type (T).
        /// </summary>
        /// <param name="predicate">Expression that results in true/false.</param>
        /// <returns>Data list result from the query.</returns>
        IQueryable<T> SearchFor(Expression<Func<T, bool>> predicate);

        /// <summary>
        /// Returns a list of objects that represent all records of a repository
        /// </summary>
        /// <returns>List of objects</returns>
        IList<T> GetAll();

        /// <summary>
        /// LINQ to SQL query for all Generic Type Objects (T).
        /// </summary>
        /// <param name="navigationProperties">Connection from one entity to another</param>
        /// <returns>Data list result from the query</returns>
        IList<T> GetAll(params Expression<Func<T, object>>[] navigationProperties);

        /// <summary>
        /// This method will find the related record of a given repository.
        /// </summary>
        /// <param name="where">Lambda expression to search a record. (Example: d => d.StandardName.Equals(standardName))</param>
        /// <param name="navigationProperties">Navigation property that leads to the related records. (Example: d => d.Students)</param>
        /// <returns>Returns a single, specific element of a sequence</returns>
        T GetSingle(Func<T, bool> where, params Expression<Func<T, object>>[] navigationProperties);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="where"></param>
        /// <param name="navigationProperties"></param>
        /// <returns></returns>
        bool Exists(Func<T, bool> where, params Expression<Func<T, object>>[] navigationProperties);   
    }
}
