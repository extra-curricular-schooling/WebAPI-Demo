﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using ECS.Repositories.Contracts;

namespace ECS.Repositories.Implementations
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        // DbContext represents the data context (database connection) currently in use.
        protected readonly DbContext Context;

        // DbSet represents the "table" that you are performing operations on.
        protected readonly IDbSet<T> DbSet;

        /// <summary>
        /// Repository base class contructor.
        /// </summary>
        /// <param name="datacontext">
        /// The "database" that is used to produce the generated repository.
        /// </param>
        protected RepositoryBase(DbContext datacontext)
        {
            //You can use the cpmt
            Context = datacontext;
            DbSet = Context.Set<T>();
        }
        
        public void Insert(T entity)
        {
            //Use the context object and entity state to save the entity
            DbSet.Add(entity);
            Context.Entry(entity).State = EntityState.Added;
            Context.SaveChanges();
        }
        
        public void Delete(T entity)
        {
            //Use the context object and entity state to delete the entity
            DbSet.Attach(entity);
            DbSet.Remove(entity);
            Context.Entry(entity).State = EntityState.Deleted;
            Context.SaveChanges();
        }
        
        public void Update(T entity)
        {
            //Use the context object and entity state to update the entity
            Context.Entry(entity).State = EntityState.Modified;
            Context.SaveChanges();
        }

        public T GetById(int id)
        {
            return DbSet.Find(id);
        }

        public T GetById(string id)
        {
            return DbSet.Find(id);
        }

        public IQueryable<T> SearchFor(Expression<Func<T, bool>> predicate)
        {
            return DbSet.Where(predicate);
        }

        public IList<T> GetAll()
        {
            IQueryable<T> query = DbSet;
            IList<T> items = query.AsNoTracking().ToList<T>();
            return items;
        }

        public IList<T> GetAll(params Expression<Func<T, object>>[] navigationProperties)
        {
            IQueryable<T> query = DbSet;
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
            IQueryable<T> query = DbSet;
            T item = null;

            foreach (Expression<Func<T, object>> navigationProperty in navigationProperties)
                query = query.Include<T, object>(navigationProperty);

            item = query.AsNoTracking().FirstOrDefault(where);
            return item;
        }

        public bool Exists(Func<T, bool> where, params Expression<Func<T, object>>[] navigationProperties)
        {
            IQueryable<T> query = DbSet;
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

        public void Dispose()
        {
            Context?.Dispose();
        }
    }
}