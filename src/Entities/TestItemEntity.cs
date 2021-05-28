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

        public TestItemEntity(int id, bool gotRightAnswer, int questionId)
        {
            Id = id;
            GotRightAnswer = gotRightAnswer;
            QuestionId = questionId;
        }
    }
}
