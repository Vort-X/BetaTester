using BusinessLogicLayer.Interfaces;
using Mappers;
using PresentationLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PresentationLayer.WpfApp.Models
{
    public class TestProcessor
    {
        private readonly IAttemptService attemptService;
        private readonly IQuestionService questionService;

        private readonly TestConfigModel config;
        private readonly List<QuestionDifficultyModel> difficulties;
        private readonly List<QuestionModel> questions;
        private readonly List<TestItemModel> testItems;
        private int currentIndex = 0;

        public TestProcessor(IAttemptService attemptService, IQuestionService questionService)
        {
            this.attemptService = attemptService;
            this.questionService = questionService;

            config = questionService.CreateConfig().ToModel();
            difficulties = questionService.GetDifficulties().Select(qd => qd.ToModel()).ToList();
            questions = new List<QuestionModel>();
            testItems = new List<TestItemModel>();
        }

        public QuestionDifficultyModel CurrentDifficulty => difficulties.Find(d => d.Id == CurrentQuestion.DifficultyId);
        public QuestionModel CurrentQuestion => questions[currentIndex];

        public event Action QuestionUpdate;

        public void GenerateTest()
        {
            questions.Clear();
            questions.AddRange(questionService.GenerateTest(config.ToDomain()).Select(q => q.ToModel()));
            if (questions.Count == 0)
            {
                throw new ArgumentOutOfRangeException(nameof(questions.Count), "No questions were returned from database");
            }
            testItems.Clear();
            currentIndex = 0;

            QuestionUpdate?.Invoke();
        }

        public bool GiveAnswer(int index)
        {
            bool isRight = CurrentQuestion.Answers[index].IsCorrect;
            testItems.Add(new TestItemModel(0, isRight, CurrentQuestion.Id));
            return isRight;
        }

        public bool HasNext()
        {
            return currentIndex + 1 < questions.Count;
        }

        public void Next()
        {
            if (HasNext())
            {
                currentIndex++;
                QuestionUpdate?.Invoke();
            }
        }

        public void SaveAttempt(string username)
        {
            var attempt = new AttemptModel(0, username, DateTime.Now);
            attempt.TestItems.AddRange(testItems);
            attemptService.SaveAttempt(attempt.ToDomain());
        }
    }
}
