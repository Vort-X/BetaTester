using System.Collections.Generic;

namespace PresentationLayer.Models
{
    public class TestConfigModel
    {
        public Dictionary<QuestionDifficultyModel, int> QuestionsOfEachDifficulty { get; private set; }

        public TestConfigModel()
        {
            QuestionsOfEachDifficulty = new Dictionary<QuestionDifficultyModel, int>();
        }
    }
}
