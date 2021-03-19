using BusinessLogicLayer.Domain;
using DataLayer.Entities;

namespace DataLayer.Mappers
{
    internal static class QuestionMapper
    {
        public static Question ToDomain(this QuestionEntity entity)
        {
            var question = new Question(entity.Id, entity.Text, entity.Difficulty.ToDomain());
            entity.Answers.ForEach(a => question.Answers.Add(a.ToDomain()));
            return question;
        }
        public static QuestionEntity ToEntity(this Question domain)
        {
            var question = new QuestionEntity(domain.Id, domain.Text, domain.Difficulty.ToEntity());
            domain.Answers.ForEach(a => question.Answers.Add(a.ToEntity()));
            return question;
        }
    }
}
