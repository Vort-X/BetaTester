using System.Collections.Generic;

namespace BusinessLogicLayer.Domain
{
    public class TestConfig
    {
        public Dictionary<QuestionDifficulty, int> QuestionsOfEachDifficulty { get; private set; }

        public TestConfig()
        {
            QuestionsOfEachDifficulty = new Dictionary<QuestionDifficulty, int>();
        }
    }
}
