using BusinessLogicLayer.Domain;
using DataLayer.Entities;
using PresentationLayer.Models;

namespace Mappers
{
    public static class QuestionMapper
    {
        public static Question ToDomain(this QuestionEntity entity)
        {
            var question = new Question(entity.Id, entity.Text, entity.DifficultyId);
            entity.Answers.ForEach(a => question.Answers.Add(a.ToDomain()));
            return question;
        }

        public static Question ToDomain(this QuestionModel model)
        {
            var question = new Question(model.Id, model.Text, model.DifficultyId);
            model.Answers.ForEach(a => question.Answers.Add(a.ToDomain()));
            return question;
        }

        public static QuestionEntity ToEntity(this Question domain)
        {
            var question = new QuestionEntity(domain.Id, domain.Text, domain.DifficultyId);
            domain.Answers.ForEach(a => question.Answers.Add(a.ToEntity()));
            return question;
        }

        public static QuestionModel ToModel(this Question domain)
        {
            var question = new QuestionModel(domain.Id, domain.Text, domain.DifficultyId);
            domain.Answers.ForEach(a => question.Answers.Add(a.ToModel()));
            return question;
        }
    }
}
