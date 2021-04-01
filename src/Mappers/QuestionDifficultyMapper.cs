using BusinessLogicLayer.Domain;
using DataLayer.Entities;
using PresentationLayer.Models;

namespace Mappers
{
    public static class QuestionDifficultyMapper
    {
        public static QuestionDifficulty ToDomain(this QuestionDifficultyEntity entity)
        {
            return new QuestionDifficulty(entity.Id, entity.Name, entity.Points);
        }

        public static QuestionDifficulty ToDomain(this QuestionDifficultyModel model)
        {
            return new QuestionDifficulty(model.Id, model.Name, model.Points);
        }

        public static QuestionDifficultyEntity ToEntity(this QuestionDifficulty domain)
        {
            return new QuestionDifficultyEntity(domain.Id, domain.Name, domain.Points);
        }

        public static QuestionDifficultyModel ToModel(this QuestionDifficulty domain)
        {
            return new QuestionDifficultyModel(domain.Id, domain.Name, domain.Points);
        }
    }
}

