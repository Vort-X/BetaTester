using BusinessLogicLayer.Domain;
using PresentationLayer.Models;

namespace BusinessLogicLayer.Mappers
{
    internal static class QuestionDifficultyMapper
    {
        public static QuestionDifficulty ToDomain(this QuestionDifficultyModel model)
        {
            return new QuestionDifficulty(model.Id, model.Name, model.Points);
        }

        public static QuestionDifficultyModel ToModel(this QuestionDifficulty domain)
        {
            return new QuestionDifficultyModel(domain.Id, domain.Name, domain.Points);
        }
    }
}
