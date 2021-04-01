using BusinessLogicLayer.Domain;
using DataLayer.Entities;
using PresentationLayer.Models;

namespace Mappers
{
    public static class TestConfigMapper
    {
        public static TestConfig ToDomain(this TestConfigModel model)
        {
            var testConfig = new TestConfig();
            foreach (var pair in model.QuestionsOfEachDifficulty)
            {
                testConfig.QuestionsOfEachDifficulty[pair.Key.ToDomain()] = pair.Value;
            }
            return testConfig;
        }

        public static TestConfigModel ToModel(this TestConfig domain)
        {
            var testConfig = new TestConfigModel();
            foreach (var pair in domain.QuestionsOfEachDifficulty)
            {
                testConfig.QuestionsOfEachDifficulty[pair.Key.ToModel()] = pair.Value;
            }
            return testConfig;
        }
    }
}
