namespace PresentationLayer.Models
{
    public class TestItemModel : BaseModel
    {
        public bool GotRightAnswer { get; private set; }
        public QuestionModel Question { get; private set; }

        public TestItemModel(int id, bool gotRightAnswer, QuestionModel question) : base(id)
        {
            GotRightAnswer = gotRightAnswer;
            Question = question;
        }
    }
}
