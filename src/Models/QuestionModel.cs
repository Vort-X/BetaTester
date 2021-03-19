using System.Collections.Generic;

namespace PresentationLayer.Models
{
    public class QuestionModel : BaseModel
    {
        public string Text { get; private set; }
        public QuestionDifficultyModel Difficulty { get; private set; }
        public List<AnswerModel> Answers { get; private set; }

        public int Points;

        public QuestionModel(int id, string text, QuestionDifficultyModel difficulty) : base(id)
        {
            Text = text;
            Difficulty = difficulty;

            Answers = new List<AnswerModel>();
        }
    }
}
