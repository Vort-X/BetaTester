using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataLayer.Entities
{
    public class QuestionEntity : BaseEntity
    {
        public string Text { get; private set; }
        [ForeignKey("DifficultyId")]
        public QuestionDifficultyEntity Difficulty { get; private set; }
        public int DifficultyId { get; private set; }
        public List<AnswerEntity> Answers { get; private set; }

        private QuestionEntity()
        {

        }

        public QuestionEntity(int id, string text, QuestionDifficultyEntity difficulty) : base(id)
        {
            Text = text;
            Difficulty = difficulty;
            DifficultyId = difficulty.Id;

            Answers = new List<AnswerEntity>();
        }

        public void NullifyReferences()
        {
            Difficulty = null;
        }
    }
}
