using DataLayer.Database;
using DataLayer.Entities;
using DataLayer.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace DataLayer.Repositories
{
    public class AttemptRepository : EfRepository<AttemptEntity>, IAttemptRepository
    {
        public AttemptRepository(TesterContext dbContext): base(dbContext)
        {
        }

        public IReadOnlyList<AttemptEntity> GetLeaders(int amount)
        {
            return dbContext.Attempts
                .OrderByDescending(a => a.TestItems
                    .Sum(ti => dbContext
                        .Find<QuestionDifficultyEntity>(dbContext
                            .Find<QuestionEntity>(ti.QuestionId)
                            .DifficultyId)
                        .Points))
                .Take(amount)
                .ToList();
        }
    }
}
