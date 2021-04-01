using DataLayer.Database;
using DataLayer.Entities;
using DataLayer.Interfaces;
using Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataLayer.Repositories
{
    public class EfRepository<T> : IRepository<T> where T : BaseEntity, IAggregateRoot
    {
        protected readonly TesterContext dbContext;

        public EfRepository(TesterContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void Add(T entity)
        {
            dbContext.Set<T>().Add(entity);
            dbContext.SaveChanges();
        }

        public int Count(Expression<Func<T, bool>> predicate)
        {
            return dbContext.Set<T>().Where(predicate).Count();
        }

        public int CountAll()
        {
            return dbContext.Set<T>().Count();
        }

        public T First(Expression<Func<T, bool>> predicate)
        {
            return dbContext.Set<T>().Where(predicate).First();
        }

        public T FirstOrDefault(Expression<Func<T, bool>> predicate)
        {
            return dbContext.Set<T>().Where(predicate).FirstOrDefault();
        }

        public T GetById(int id)
        {
            return dbContext.Set<T>().Find(id);
        }

        public IReadOnlyList<T> List(Expression<Func<T, bool>> predicate)
        {
            return dbContext.Set<T>().Where(predicate).ToList();
        }

        public IReadOnlyList<T> ListAll()
        {
            return dbContext.Set<T>().ToList();
        }

        public void Remove(T entity)
        {
            dbContext.Set<T>().Remove(entity); 
            dbContext.SaveChanges();
        }

        public void Update(T entity)
        {
            dbContext.Set<T>().Update(entity);
            dbContext.SaveChanges();
        }
    }
}
