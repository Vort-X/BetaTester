using BusinessLogicLayer.Interfaces;
using BusinessLogicLayer.Mappers;
using DataLayer.Interfaces;
using DataLayer.Repositories;
using PresentationLayer.Models;
using System.Collections.Generic;
using System.Linq;

namespace BusinessLogicLayer.Services
{
    public class QuestionService : IQuestionService
    {
        protected readonly IQuestionRepository questionRepository;
        protected readonly IQuestionDifficultyRepository questionDifficultyRepository;

        public QuestionService(IQuestionRepository questionRepository, IQuestionDifficultyRepository questionDifficultyRepository)
        {
            this.questionRepository = questionRepository;
            this.questionDifficultyRepository = questionDifficultyRepository;
        }

        public TestConfigModel CreateConfig()
        {
            return questionDifficultyRepository.CreateConfig().ToModel();
        }

        public List<QuestionModel> GenerateTest(TestConfigModel testConfig)
        {
            List<QuestionModel> testContent = new List<QuestionModel>();
            testConfig.QuestionsOfEachDifficulty
                .Where(p => p.Value > 0)
                .ToList()
                .ForEach((pair) => {
                    testContent.AddRange(questionRepository
                        .GetByDifficulty(pair.Key.ToDomain(), pair.Value)
                        .Select(q => q.ToModel()));
                });
            return testContent;
        }

        public void AddQuestion(QuestionModel questionModel)
        {
            questionRepository.Add(questionModel.ToDomain());
        }
    }
}
