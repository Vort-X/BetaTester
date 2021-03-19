using BusinessLogicLayer.Domain;
using DataLayer.Entities;

namespace DataLayer.Mappers
{
    internal static class QuestionDifficultyMapper
    {
        public static QuestionDifficulty ToDomain(this QuestionDifficultyEntity entity)
        {
            return new QuestionDifficulty(entity.Id, entity.Name, entity.Points);
        }

        public static QuestionDifficultyEntity ToEntity(this QuestionDifficulty domain)
        {
            return new QuestionDifficultyEntity(domain.Id, domain.Name, domain.Points);
        }
    }
}
