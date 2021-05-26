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
        }

        public int CountAll()
        {
            return dbContext.Set<T>().Count();
        }

        public T GetById(int id)
        {
            return dbContext.Set<T>().Find(id);
        }

        public IReadOnlyList<T> ListAll()
        {
            return dbContext.Set<T>().ToList();
        }

        public void Remove(T entity)
        {
            dbContext.Set<T>().Remove(entity); 
        }

        public void Update(T entity)
        {
            dbContext.Set<T>().Update(entity);
        }
    }
}
