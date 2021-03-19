namespace PresentationLayer.Models
{
    public class QuestionDifficultyModel : BaseModel
    {
        public string Name { get; private set; }
        public int Points { get; private set; }

        public QuestionDifficultyModel(int id, string name, int points) : base(id)
        {
            Name = name;
            Points = points;
        }
    }
}
