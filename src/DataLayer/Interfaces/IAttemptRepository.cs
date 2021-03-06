using DataLayer.Entities;
using System.Collections.Generic;

namespace DataLayer.Interfaces
{
    public interface IAttemptRepository : IRepository<AttemptEntity, int>
    {
        IReadOnlyList<AttemptEntity> GetLeaders(int amount);
        int GetPoints(int attemptId);
    }
}
