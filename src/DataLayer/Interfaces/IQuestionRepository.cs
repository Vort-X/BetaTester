using DataLayer.Entities;
using System.Collections.Generic;

namespace DataLayer.Interfaces
{
    public interface IQuestionRepository : IRepository<QuestionEntity>
    {
        IReadOnlyList<QuestionEntity> GetRandomByDifficulty(int difficultyId, int amount);
    }
}
