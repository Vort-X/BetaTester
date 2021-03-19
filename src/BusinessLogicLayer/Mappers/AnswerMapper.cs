using BusinessLogicLayer.Domain;
using PresentationLayer.Models;

namespace BusinessLogicLayer.Mappers
{
    internal static class AnswerMapper
    {
        public static Answer ToDomain(this AnswerModel model)
        {
            return new Answer(model.Id, model.IsCorrect, model.Text);
        }

        public static AnswerModel ToModel(this Answer domain)
        {
            return new AnswerModel(domain.Id, domain.IsCorrect, domain.Text);
        }
    }
}
