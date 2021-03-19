using BusinessLogicLayer.Domain;
using DataLayer.Entities;

namespace DataLayer.Mappers
{
    internal static class AnswerMapper
    {
        public static Answer ToDomain(this AnswerEntity entity)
        {
            return new Answer(entity.Id, entity.IsCorrect, entity.Text);
        }

        public static AnswerEntity ToEntity(this Answer domain)
        {
            return new AnswerEntity(domain.Id, domain.IsCorrect, domain.Text);
        }
    }
}
