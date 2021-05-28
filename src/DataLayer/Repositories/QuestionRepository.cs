using DataLayer.Database;
using DataLayer.Entities;
using DataLayer.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataLayer.Repositories
{
    public class QuestionRepository : EfRepository<QuestionEntity, int>, IQuestionRepository
    {
        public QuestionRepository(TesterContext dbContext) : base(dbContext)
        {
        }

        public IReadOnlyList<QuestionEntity> GetRandomByDifficulty(int difficultyId, int amount)
        {
            return dbContext.Questions
                .Where(q => q.DifficultyId == difficultyId)
                .OrderBy(q => Guid.NewGuid())
                .Take(amount)
                .Include(q => q.Answers)
                .ToList();
        }
    }
}
