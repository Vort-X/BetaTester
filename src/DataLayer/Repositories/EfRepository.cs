using DataLayer.Database;
using DataLayer.Entities;
using DataLayer.Interfaces;
using Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataLayer.Repositories
{
    public class EfRepository<TEntity, TKey> : IRepository<TEntity, TKey> where TEntity : class, IAggregateRoot
    {
        protected readonly TesterContext dbContext;

        public EfRepository(TesterContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void Add(TEntity entity)
        {
            dbContext.Set<TEntity>().Add(entity);
        }

        public int CountAll()
        {
            return dbContext.Set<TEntity>().Count();
        }

        public TEntity GetById(TKey id)
        {
            return dbContext.Set<TEntity>().Find(id);
        }

        public IReadOnlyList<TEntity> ListAll()
        {
            return dbContext.Set<TEntity>().ToList();
        }

        public void Remove(TEntity entity)
        {
            dbContext.Set<TEntity>().Remove(entity); 
        }

        public void Update(TEntity entity)
        {
            dbContext.Set<TEntity>().Update(entity);
        }
    }
}
