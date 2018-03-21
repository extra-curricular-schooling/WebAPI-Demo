using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace ECS.Repositories
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        // DbContext represents the data context (database connection) currently in use.
        protected DbContext context;

        // DbSet represents the "table" that you are performing operations on.
        protected IDbSet<T> dbSet;

        /// <summary>
        /// Repository base class contructor.
        /// </summary>
        /// <param name="datacontext">
        /// The "database" that is used to produce the generated repository.
        /// </param>
        protected RepositoryBase(DbContext datacontext)
        {
            //You can use the cpmt
            context = datacontext;
            dbSet = context.Set<T>();
        }
        
        public void Insert(T entity)
        {
            //Use the context object and entity state to save the entity
            dbSet.Add(entity);
            context.Entry(entity).State = EntityState.Added;
            context.SaveChanges();
        }
        
        public void Delete(T entity)
        {
            //Use the context object and entity state to delete the entity
            dbSet.Remove(entity);
            context.Entry(entity).State = EntityState.Deleted;
            context.SaveChanges();
        }
        
        public void Update(T entity)
        {
            //Use the context object and entity state to update the entity
            context.Entry(entity).State = EntityState.Modified;
            context.SaveChanges();
        }

        // Haven't tested these yet!!!!!!!!!!!!!!!!!
        // TODO: @Scott Find can be very slow. Try to change to SingleOrDefault<>()
        public T GetById(int id)
        {
            return dbSet.Find(id);
        }

        // Haven't tested these yet!!!!!!!!!!!!!!!!!
        public T GetById(string id)
        {
            return dbSet.Find(id);
        }

        public IQueryable<T> SearchFor(Expression<Func<T, bool>> predicate)
        {
            return dbSet.Where(predicate);
        }
        
        public IList<T> GetAll(params Expression<Func<T, object>>[] navigationProperties)
        {
            IQueryable<T> query = dbSet;
            var list = new List<T>();

            //Apply eager loading
            foreach (var navigationProperty in navigationProperties)
            {
                query = query.Include(navigationProperty);

                list = query.AsNoTracking().ToList();
            }
            return list;
        }

        // An example of the method GetStandardByName(string standardName)
        // public Standard GetStandardByName(string standardName)
        // {
        //   return _standardRepository.GetSingle(d => d.StandardName.Equals(standardName), d => d.Students);
        // } 
        public T GetSingle(Func<T, bool> where, params Expression<Func<T, object>>[] navigationProperties)
        {
            IQueryable<T> query = dbSet;
            T item = null;

            foreach (Expression<Func<T, object>> navigationProperty in navigationProperties)
                query = query.Include<T, object>(navigationProperty);

            item = query.AsNoTracking().FirstOrDefault(where);
            return item;
        }

        /// <summary>
        /// Garbage Collection is not implemented.
        /// </summary>
        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public bool Exists(Func<T, bool> where, params Expression<Func<T, object>>[] navigationProperties)
        {
            IQueryable<T> query = dbSet;
            T item = null;

            foreach (Expression<Func<T, object>> navigationProperty in navigationProperties)
                query = query.Include<T, object>(navigationProperty);
            
            try
            {
                item = query.AsNoTracking().Single(where);
            } catch (ArgumentNullException)
            {
                return false;
            } catch (InvalidOperationException)
            {
                return false;
            }

            return true;
        }
    }
}