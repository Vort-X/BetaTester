namespace BusinessLogicLayer.Domain
{
    public class Answer : Base
    {
        public bool IsCorrect { get; private set; }
        public string Text { get; private set; }

        public Answer(int id, bool isCorrect, string text)
        {
            Id = id;
            IsCorrect = isCorrect;
            Text = text;
        }
    }
}
