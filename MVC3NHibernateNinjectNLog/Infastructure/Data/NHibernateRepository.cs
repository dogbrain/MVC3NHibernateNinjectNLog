using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

using NHibernate;
using NHibernate.Linq;

namespace MVC3NHibernateNinjectNLog.Infastructure.Data
{
    public class NHibernateRepository<T> : IRepository<T>
    {
        public ISession Session
        {
            get { return NHibernateSessionPerRequest.GetCurrentSession(); }
        }

        public IQueryable<T> GetAll()
        {
            return Session.Query<T>();
        }

        public IQueryable<T> Get(Expression<Func<T, bool>> predicate)
        {
            return GetAll().Where(predicate);
        }

        public IEnumerable<T> SaveOrUpdateAll(params T[] entities)
        {
            foreach (var entity in entities)
            {
                Session.SaveOrUpdate(entity);
            }

            return entities;
        }

        public T SaveOrUpdate(T entity)
        {
            Session.SaveOrUpdate(entity);
       

            return entity;
        }


        public void Delete(T entity)
        {
            Session.Delete(entity);
        }

        public void DeleteAll(params T[] entities)
        {
            foreach (var entity in entities)
            {
                Session.Delete(entity);
            }
        }


        public T Add(T entity)
        {
            Session.Save(entity);
            return entity;
        }
    }
}