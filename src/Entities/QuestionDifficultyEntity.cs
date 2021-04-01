using Entities.Interfaces;

namespace DataLayer.Entities
{
    public class QuestionDifficultyEntity : BaseEntity, IAggregateRoot
    {
        public string Name { get; private set; }
        public int Points { get; private set; }

        private QuestionDifficultyEntity()
        {

        }

        public QuestionDifficultyEntity(int id, string name, int points)
        {
            Id = id;
            Name = name;
            Points = points;
        }
    }
}
