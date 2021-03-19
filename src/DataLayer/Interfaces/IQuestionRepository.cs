using BusinessLogicLayer.Domain;
using System.Collections.Generic;

namespace DataLayer.Interfaces
{
    public interface IQuestionRepository : IRepository<Question>
    {
        IEnumerable<Question> GetByDifficulty(QuestionDifficulty difficulty, int amount);
    }
}
