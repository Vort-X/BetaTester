using DataLayer.Entities;
using Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace DataLayer.Interfaces
{
    public interface IRepository<T> where T : BaseEntity, IAggregateRoot
    {
        int Count(Expression<Func<T, bool>> predicate);
        int CountAll();
        T GetById(int id);
        T First(Expression<Func<T, bool>> predicate);
        T FirstOrDefault(Expression<Func<T, bool>> predicate);
        IReadOnlyList<T> List(Expression<Func<T, bool>> predicate);
        IReadOnlyList<T> ListAll();
        void Add(T entity);
        void Update(T entity);
        void Remove(T entity);
    }
}
