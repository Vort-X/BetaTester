using BusinessLogicLayer.Domain;
using PresentationLayer.Models;

namespace BusinessLogicLayer.Mappers
{
    internal static class QuestionMapper
    {
        public static Question ToDomain(this QuestionModel model)
        {
            var question = new Question(model.Id, model.Text, model.Difficulty.ToDomain());
            model.Answers.ForEach(a => question.Answers.Add(a.ToDomain()));
            return question;
        }

        public static QuestionModel ToModel(this Question domain)
        {
            var question = new QuestionModel(domain.Id, domain.Text, domain.Difficulty.ToModel());
            domain.Answers.ForEach(a => question.Answers.Add(a.ToModel()));
            return question;
        }
    }
}
