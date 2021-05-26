using DataLayer.Entities;
using Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace DataLayer.Interfaces
{
    public interface IRepository<T> where T : BaseEntity, IAggregateRoot
    {
        int CountAll();
        T GetById(int id);
        IReadOnlyList<T> ListAll();
        void Add(T entity);
        void Update(T entity);
        void Remove(T entity);
    }
}
