using System.Collections.Generic;

namespace PresentationLayer.Models
{
    public class QuestionModel : BaseModel
    {
        public string Text { get; private set; }
        public int DifficultyId { get; private set; }
        public List<AnswerModel> Answers { get; set; }

        public int Points;

        public QuestionModel(int id, string text, int difficultyId)
        {
            Id = id;
            Text = text;
            DifficultyId = difficultyId;

            Answers = new List<AnswerModel>();
        }
    }
}
