using BusinessLogicLayer.Interfaces;
using PresentationLayer.Models;
using Mappers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PresentationLayer.ConsoleUI.UI
{
    class CLI : IUserInterface
    {
        protected readonly IAttemptService attemptService;
        protected readonly IQuestionService questionService;

        protected Dictionary<int, string> mainMenu = new Dictionary<int, string> 
        { 
            { 1, "Start" }, 
            { 2, "Test configuration" }, 
            { 3, "Leader table" }, 
            { 0, "Exit" } 
        };

        protected TestConfigModel cfg;
        protected ConsoleKey pressed;

        public CLI(IAttemptService attemptService, IQuestionService questionService)
        {
            this.attemptService = attemptService;
            this.questionService = questionService;
        }

        public void Run()
        {
            do
            {
                PrintMenu();
                pressed = Console.ReadKey().Key;
                Press();
            } while (pressed != ConsoleKey.D0);
        }

        protected virtual void PrintMenu()
        {
            Console.Clear();
            foreach (var pair in mainMenu)
            {
                Console.WriteLine($"{pair.Key}. {pair.Value}");
            }
        }

        protected virtual void Press()
        {
            switch (pressed)
            {
                case ConsoleKey.D1:
                    StartTest();
                    break;
                case ConsoleKey.D2:
                    Configurate();
                    break;
                case ConsoleKey.D3:
                    ShowLeaderTable();
                    break;
                case ConsoleKey.D4:
                    break;
                case ConsoleKey.D5:
                    break;
                case ConsoleKey.D6:
                    break;
                case ConsoleKey.D7:
                    break;
                case ConsoleKey.D8:
                    break;
                case ConsoleKey.D9:
                    break;
                case ConsoleKey.D0:
                default:
                    break;
            }
        }

        #region Menu items
        protected void StartTest()
        {
            Console.Clear();
            cfg = questionService.CreateConfig().ToModel();
            cfg.QuestionsOfEachDifficulty.Keys.ToList().ForEach(key => cfg.QuestionsOfEachDifficulty[key] = 1);
            var testContent = questionService.GenerateTest(cfg.ToDomain());
            if (testContent.Count == 0)
            {
                return;
            }

            List<TestItemModel> testItems = new List<TestItemModel>();
            testContent.ForEach(question => testItems.Add(GetAnswer(question.ToModel())));
            Console.Write("Write your name: ");
            var name = Console.ReadLine();
            AttemptModel attempt = new AttemptModel(0, name, DateTime.Now );
            attempt.TestItems.AddRange(testItems);

            attemptService.SaveAttempt(attempt.ToDomain());

            TestItemModel GetAnswer(QuestionModel question)
            {
                Console.WriteLine("Difficulty: " + question.DifficultyId);
                Console.WriteLine(question.Text);
                var shuffledAnswers = question.Answers.OrderBy(q => Guid.NewGuid()).ToList();
                for (int index = 0; index < shuffledAnswers.Count; index++)
                {
                    Console.WriteLine($"{index + 1}: {shuffledAnswers[index].Text}");
                }
                while (true)
                {
                    if (int.TryParse(Console.ReadLine(), out int input) && input <= 4 && input >= 1)
                    {
                        return new TestItemModel(0, shuffledAnswers[input - 1].IsCorrect, question.Id);
                    }
                }
            }
        }
        protected void Configurate()
        {
            Console.Clear();

        }
        protected void ShowLeaderTable()
        {
            Console.Clear();
            //attemptService.GetTopTen().ForEach(a => Console.WriteLine($"{a.TestingDate} " +
            //    $"{a.TesterName} " +
            //    $"{a.TestItems.Where(ti => ti.GotRightAnswer).Select(ti => ti.Question.Difficulty.Points).Sum()}/" +
            //    $"{a.TestItems.Select(ti => ti.Question.Difficulty.Points).Sum()}"));
            Console.ReadKey();
        }
        #endregion
    }
}
