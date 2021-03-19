namespace BusinessLogicLayer.Domain
{
    public class QuestionDifficulty : Base
    {
        public string Name { get; private set; }
        public int Points { get; private set; }

        public QuestionDifficulty(int id, string name, int points) : base(id)
        {
            Name = name;
            Points = points;
        }
    }
}
