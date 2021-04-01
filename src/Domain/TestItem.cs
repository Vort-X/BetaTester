namespace BusinessLogicLayer.Domain
{
    public class TestItem : Base
    {
        public bool GotRightAnswer { get; private set; }
        public int QuestionId { get; private set; }

        public TestItem(int id, bool gotRightAnswer, int questionId)
        {
            Id = id;
            GotRightAnswer = gotRightAnswer;
            QuestionId = questionId;
        }
    }
}
