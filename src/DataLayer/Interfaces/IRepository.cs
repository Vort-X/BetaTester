using BusinessLogicLayer.Domain;
using System.Collections.Generic;

namespace DataLayer.Interfaces
{
    public interface IRepository<T> where T : Base
    {
        T GetById(int id);
        IEnumerable<T> GetAll();
        void Add(T domain);
        void Update(T domain);
        void Remove(T domain);
    }
}
