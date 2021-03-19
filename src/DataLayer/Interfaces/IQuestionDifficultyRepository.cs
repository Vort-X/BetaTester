using BusinessLogicLayer.Domain;

namespace DataLayer.Interfaces
{
    public interface IQuestionDifficultyRepository : IRepository<QuestionDifficulty>
    {
        TestConfig CreateConfig();
    }
}
