using DataLayer.Entities;
using Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace DataLayer.Interfaces
{
    public interface IRepository<TEntity, TKey> where TEntity : IAggregateRoot
    {
        int CountAll();
        TEntity GetById(TKey id);
        IReadOnlyList<TEntity> ListAll();
        void Add(TEntity entity);
        void Update(TEntity entity);
        void Remove(TEntity entity);
    }
}
