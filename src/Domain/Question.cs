using System.Collections.Generic;

namespace BusinessLogicLayer.Domain
{
    public class Question : Base
    {
        public string Text { get; private set; }
        public int DifficultyId { get; private set; }
        public List<Answer> Answers { get; private set; }

        public int Points;

        public Question(int id, string text, int difficultyId)
        {
            Id = id;
            Text = text;
            DifficultyId = difficultyId;

            Answers = new List<Answer>();
        }
    }
}
