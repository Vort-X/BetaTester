namespace DataLayer.Entities
{
    public class QuestionDifficultyEntity : BaseEntity
    {
        public string Name { get; private set; }
        public int Points { get; private set; }

        private QuestionDifficultyEntity()
        {

        }

        public QuestionDifficultyEntity(int id, string name, int points) : base(id)
        {
            Name = name;
            Points = points;
        }
    }
}
