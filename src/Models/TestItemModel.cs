namespace PresentationLayer.Models
{
    public class TestItemModel : BaseModel
    {
        public bool GotRightAnswer { get; private set; }
        public int QuestionId { get; private set; }

        public TestItemModel(int id, bool gotRightAnswer, int questionId)
        {
            Id = id;
            GotRightAnswer = gotRightAnswer;
            QuestionId = questionId;
        }
    }
}
