namespace PresentationLayer.Models
{
    public class AnswerModel : BaseModel
    {
        public bool IsCorrect { get; private set; }
        public string Text { get; private set; }

        public AnswerModel(int id, bool isCorrect, string text)
        {
            Id = id;
            IsCorrect = isCorrect;
            Text = text;
        }
    }
}
