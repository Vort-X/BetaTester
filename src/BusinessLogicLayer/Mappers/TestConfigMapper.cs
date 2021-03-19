using BusinessLogicLayer.Domain;
using PresentationLayer.Models;

namespace BusinessLogicLayer.Mappers
{
    internal static class TestConfigMapper
    {
        public static TestConfig ToDomain(this TestConfigModel model)
        {
            var config = new TestConfig();
            foreach (var key in model.QuestionsOfEachDifficulty.Keys)
            {
                config.QuestionsOfEachDifficulty[key.ToDomain()] = model.QuestionsOfEachDifficulty[key];
            }
            return config;
        }

        public static TestConfigModel ToModel(this TestConfig domain)
        {
            var config = new TestConfigModel();
            foreach (var key in domain.QuestionsOfEachDifficulty.Keys)
            {
                config.QuestionsOfEachDifficulty[key.ToModel()] = domain.QuestionsOfEachDifficulty[key];
            }
            return config;
        }
    }
}
