using System.ComponentModel.DataAnnotations.Schema;

namespace DataLayer.Entities
{
    public class TestItemEntity : BaseEntity
    {
        public bool GotRightAnswer { get; private set; }
        [ForeignKey("QuestionId")]
        public QuestionEntity Question { get; private set; }
        
        public int QuestionId { get; private set; }

        private TestItemEntity()
        {

        }

        public TestItemEntity(int id, bool gotRightAnswer, QuestionEntity question) : base(id)
        {
            GotRightAnswer = gotRightAnswer;
            Question = question;
            QuestionId = question.Id;
        }

        public void NullifyReferences()
        {
            Question = null;
        }
    }
}
