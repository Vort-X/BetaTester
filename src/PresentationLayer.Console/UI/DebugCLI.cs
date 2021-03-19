using BusinessLogicLayer.Interfaces;
using PresentationLayer.Models;
using System;
using System.Collections.Generic;

namespace PresentationLayer.ConsoleUI.UI
{
    class DebugCLI : CLI
    {
        public DebugCLI(IAttemptService attemptService, IQuestionService questionService) : base(attemptService, questionService)
        {
            mainMenu = new Dictionary<int, string>
            {
                { 1, "Start" },
                { 2, "Test configuration" },
                { 3, "Leader table" },
                { 4, "Add Question" },
                { 0, "Exit" }
            };
        }

        protected override void Press()
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
                    AddQuestion();
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

        void AddQuestion()
        {
            
            Console.Clear();

            QuestionDifficultyModel difficulty;
            string text;

            var difsMenu = new Dictionary<int, QuestionDifficultyModel>();
            int i = 1;
            foreach (var key in questionService.CreateConfig().QuestionsOfEachDifficulty.Keys)
            {
                difsMenu[i++] = key;
            }
            Console.WriteLine("Choose difficulty:");
            foreach (var pair in difsMenu)
            {
                Console.WriteLine($"{pair.Key}. {pair.Value.Name}");
            }
            int input;
            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out input) && input < i && input >= 1)
                {
                    difficulty = difsMenu[input];
                    break;
                }
            }
            Console.WriteLine("Write question text:");
            text = Console.ReadLine();
            QuestionModel question = new QuestionModel(0, text, difficulty);

            bool isRight = true;
            for (int j = 0; j < 4; j++)
            {
                Console.WriteLine($"Write {j+1} of 4 answers");
                question.Answers.Add(new AnswerModel(0, isRight, Console.ReadLine()));
                if (isRight) isRight = false;
            }

            questionService.AddQuestion(question);
        }
        //public new void Run()
        //{

        //}
    }
}
