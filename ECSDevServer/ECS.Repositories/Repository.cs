using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace ECS.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected DbContext context;
        protected IQueryable<T> DbSet;
        public Repository(DbContext datacontext)
        {
            //You can use the cpmt
            context = datacontext;
            DbSet = context.Set<T>();
        }

        public void Insert(T entity)
        {
            //Use the context object and entity state to save the entity
            context.Entry(entity).State = System.Data.Entity.EntityState.Added;
            context.SaveChanges();
        }

        public void Delete(T entity)
        {
            //Use the context object and entity state to delete the entity
            context.Entry(entity).State = System.Data.Entity.EntityState.Deleted;
            context.SaveChanges();
        }

        public void Update(T entity)
        {

            //Use the context object and entity state to update the entity
            context.Entry(entity).State = System.Data.Entity.EntityState.Modified;
            context.SaveChanges();
        }

        public T GetById(int id)
        {
            return null;
        }

        public IQueryable<T> SearchFor(Expression<Func<T, bool>> predicate)
        {
            IQueryable<T> dbQuery = context.Set<T>();
            return dbQuery.Where(predicate);
        }

        public IList<T> GetAll(params Expression<Func<T, object>>[] navigationProperties)
        {
            List<T> list = new List<T>();
            IQueryable<T> dbQuery = context.Set<T>();

            //Apply eager loading
            foreach (Expression<Func<T, object>> navigationProperty in navigationProperties)
            {
                dbQuery = dbQuery.Include<T, object>(navigationProperty);

                list = dbQuery.AsNoTracking().ToList<T>();
            }
            return list;
        }

        public T GetSingle(Func<T, bool> where, params Expression<Func<T, object>>[] navigationProperties)
        //This method will find the related records by passing two argument
        //First argument: lambda expression to search a record such as d => d.StandardName.Equals(standardName) to search am record by standard name
        //Second argument: navigation property that leads to the related records such as d => d.Students
        //The method returns the related records that met the condition in the first argument.
        //An example of the method GetStandardByName(string standardName)
        //public Standard GetStandardByName(string standardName)
        //{
        //return _standardRepository.GetSingle(d => d.StandardName.Equals(standardName), d => d.Students);
        //} 
        {
            T item = null;
            IQueryable<T> dbQuery = context.Set<T>();
            foreach (Expression<Func<T, object>> navigationProperty in navigationProperties)
                dbQuery = dbQuery.Include<T, object>(navigationProperty);

            item = dbQuery.AsNoTracking().FirstOrDefault(where);
            return item;

        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}