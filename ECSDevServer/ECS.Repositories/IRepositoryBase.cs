using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace ECS.Repositories
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
        /// Returns the object with the specified list identifier.
        /// </summary>
        /// <param name="id">
        /// Unique identifier
        /// </param>
        /// <returns>
        /// Generic object.
        /// </returns>
        T GetById(int id);

        /// <summary>
        /// LINQ to SQL search for the Generic Type (T).
        /// </summary>
        /// <param name="predicate">
        /// Expression that results in true/false.
        /// </param>
        /// <returns>
        /// Data list result from the query.
        /// </returns>
        IQueryable<T> SearchFor(Expression<Func<T, bool>> predicate);

        /// <summary>
        /// LINQ to SQL query for all Generic Type Objects (T).
        /// </summary>
        /// <param name="navigationProperties">
        /// Connection from one entity to another
        /// </param>
        /// <returns>
        /// Data list result from the query.
        /// </returns>
        IList<T> GetAll(params Expression<Func<T, object>>[] navigationProperties);

        /// <summary>
        /// This method will find the related record of a given repository.
        /// </summary>
        /// <param name="where">
        /// Lambda expression to search a record. (Example: d => d.StandardName.Equals(standardName))
        /// </param>
        /// <param name="navigationProperties">
        /// Navigation property that leads to the related records. (Example: d => d.Students)
        /// </param>
        /// <returns>
        /// Returns a single, specific element of a sequence.
        /// </returns>
        T GetSingle(Func<T, bool> where, params Expression<Func<T, object>>[] navigationProperties);
    }
}