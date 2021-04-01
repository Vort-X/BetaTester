using Entities.Interfaces;
using System.Collections.Generic;

namespace DataLayer.Entities
{
    public class QuestionEntity : BaseEntity, IAggregateRoot
    {
        public string Text { get; private set; }
        public int DifficultyId { get; private set; }
        public List<AnswerEntity> Answers { get; private set; }

        private QuestionEntity()
        {

        }

        public QuestionEntity(int id, string text, int difficultyId)
        {
            Id = id;
            Text = text;
            DifficultyId = difficultyId;

            Answers = new List<AnswerEntity>();
        }
    }
}
