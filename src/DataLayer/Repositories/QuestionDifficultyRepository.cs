using DataLayer.Database;
using DataLayer.Entities;
using DataLayer.Interfaces;
using System.Linq;

namespace DataLayer.Repositories
{
    public class QuestionDifficultyRepository : EfRepository<QuestionDifficultyEntity, int>, IQuestionDifficultyRepository
    {
        public QuestionDifficultyRepository(TesterContext dbContext) : base(dbContext)
        {
            //Удалить эту гадость
            if (!dbContext.QuestionDifficulties.Any())
            {
                Add(new QuestionDifficultyEntity(0, "Easy", 1));
                Add(new QuestionDifficultyEntity(0, "Normal", 3));
                Add(new QuestionDifficultyEntity(0, "Hard", 6));
                dbContext.SaveChanges();
            }
        }
    }
}
