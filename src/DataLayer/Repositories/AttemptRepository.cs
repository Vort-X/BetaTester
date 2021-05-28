using DataLayer.Database;
using DataLayer.Entities;
using DataLayer.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace DataLayer.Repositories
{
    public class AttemptRepository : EfRepository<AttemptEntity, int>, IAttemptRepository
    {
        public AttemptRepository(TesterContext dbContext): base(dbContext)
        {
        }

        public IReadOnlyList<AttemptEntity> GetLeaders(int amount)
        {
            return dbContext.Attempts
                .Include(a => a.TestItems)
                .OrderByDescending(PointsSelector)
                .Take(amount)
                .ToList();
        }

        public int GetPoints(int attemptId)
        {
            return PointsSelector(dbContext.Attempts
                .Include(a => a.TestItems)
                .Single(a => a.Id == attemptId));
        }

        private Func<AttemptEntity, int> PointsSelector => a => a.TestItems
            .Where(ti => ti.GotRightAnswer)
            .Select(ti => dbContext
                .Find<QuestionDifficultyEntity>(dbContext
                    .Find<QuestionEntity>(ti.QuestionId)
                    .DifficultyId)
                .Points)
            .Sum();
        
    }
}
