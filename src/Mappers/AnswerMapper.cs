using BusinessLogicLayer.Domain;
using DataLayer.Entities;
using PresentationLayer.Models;

namespace Mappers
{
    public static class AnswerMapper
    {
        public static Answer ToDomain(this AnswerEntity entity)
        {
            return new Answer(entity.Id, entity.IsCorrect, entity.Text);
        }
    
        public static Answer ToDomain(this AnswerModel model)
        {
            return new Answer(model.Id, model.IsCorrect, model.Text);
        }

        public static AnswerEntity ToEntity(this Answer domain)
        {
            return new AnswerEntity(domain.Id, domain.IsCorrect, domain.Text);
        }

        public static AnswerModel ToModel(this Answer domain)
        {
            return new AnswerModel(domain.Id, domain.IsCorrect, domain.Text);
        }
    }
}
