namespace BusinessLogicLayer.Domain
{
    public class TestItem : Base
    {
        public bool GotRightAnswer { get; private set; }
        public Question Question { get; private set; }

        public TestItem(int id, bool gotRightAnswer, Question question) : base(id)
        {
            GotRightAnswer = gotRightAnswer;
            Question = question;
        }
    }
}
