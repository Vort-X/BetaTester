using BusinessLogicLayer.Domain;
using System.Collections.Generic;

namespace DataLayer.Interfaces
{
    public interface IAttemptRepository : IRepository<Attempt>
    {
        IEnumerable<Attempt> GetLeaders(int amount);
    }
}
