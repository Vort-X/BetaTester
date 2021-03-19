using System.Collections.Generic;

namespace BusinessLogicLayer.Domain
{
    public class Question : Base
    {
        public string Text { get; private set; }
        public QuestionDifficulty Difficulty { get; private set; }
        public List<Answer> Answers { get; private set; }

        public int Points;

        public Question(int id, string text, QuestionDifficulty difficulty) : base(id)
        {
            Text = text;
            Difficulty = difficulty;

            Answers = new List<Answer>();
        }
    }
}
