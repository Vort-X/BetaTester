namespace DataLayer.Entities
{
    public class AnswerEntity : BaseEntity
    {
        public bool IsCorrect { get; private set; }
        public string Text { get; private set; }

        private AnswerEntity()
        {

        }

        public AnswerEntity(int id, bool isCorrect, string text)
        {
            Id = id;
            IsCorrect = isCorrect;
            Text = text;
        }
    }
}
