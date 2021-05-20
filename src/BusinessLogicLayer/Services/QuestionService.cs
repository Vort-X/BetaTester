using BusinessLogicLayer.Domain;
using BusinessLogicLayer.Interfaces;
using DataLayer.Interfaces;
using Mappers;
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

        public TestConfig CreateConfig()
        {
            var cfg = new TestConfig();
            foreach (var item in questionDifficultyRepository.ListAll())
            {
                cfg.QuestionsOfEachDifficulty[item.ToDomain()] = 1;
            }
            return cfg;
        }

        public List<Question> GenerateTest(TestConfig testConfig)
        {
            List<Question> testContent = new List<Question>();
            testConfig.QuestionsOfEachDifficulty
                .Where(p => p.Value > 0)
                .ToList()
                .ForEach((pair) => {
                    testContent.AddRange(questionRepository
                        .GetRandomByDifficulty(pair.Key.Id, pair.Value)
                        .Select(q => q.ToDomain()));
                });
            return testContent;
        }

        public void AddQuestion(Question question)
        {
            questionRepository.Add(question.ToEntity());
        }

        public List<QuestionDifficulty> GetDifficulties()
        {
            return questionDifficultyRepository.ListAll().Select(qd => qd.ToDomain()).ToList();
        }
    }
}
