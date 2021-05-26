using BusinessLogicLayer.Interfaces;
using BusinessLogicLayer.Services;
using DataLayer.Database;
using DataLayer.Interfaces;
using DataLayer.Repositories;
using DataLayer.UnitOfWork;
using Microsoft.Extensions.DependencyInjection;
using PresentationLayer.ConsoleUI.UI;
using System;

namespace PresentationLayer.ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            IServiceCollection services = new ServiceCollection();
            ConfigureServices(services);
            ServiceProvider provider = services.BuildServiceProvider();

            DateTime start = DateTime.Now;
            var p = provider.GetRequiredService<IUserInterface>();
            DateTime end = DateTime.Now;
            Console.WriteLine(end - start);
            Console.ReadKey();

            p.Run();
            //provider.GetRequiredService<IUserInterface>().Run();
        }

        private static void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<TesterContext>()
                //.AddScoped<IQuestionDifficultyRepository, QuestionDifficultyRepository>()
                //.AddScoped<IQuestionRepository, QuestionRepository>()
                //.AddScoped<IAttemptRepository, AttemptRepository>()
                .AddSingleton<IUnitOfWork, UnitOfWork>()
                .AddScoped<IAttemptService, AttemptService>()
                .AddScoped<IQuestionService, QuestionService>()
                .AddScoped<IUserInterface, DebugCLI>();
        }

        //static void ConsoleTestingUI(Dictionary<QuestionEntity, List<AnswerEntity>> test)
        //{
        //    int correct = 0;
        //    ConsoleKey pressed;
        //    int selected;
        //    foreach (var pair in test)
        //    {
        //        selected = 0;
        //        do
        //        {
        //            PrintQuestion(pair, selected);
        //            MoveArrow(pair.Value.Count, out pressed, ref selected);
        //        }
        //        while (pressed != ConsoleKey.Enter);
        //        if (pair.Value[selected].IsCorrect)
        //        {
        //            Console.WriteLine("Correct");
        //            correct++;
        //        }
        //        else
        //        {
        //            Console.WriteLine("INCORRECT");
        //        }
        //        Console.WriteLine("Press any key to contiue.");
        //        Console.ReadKey();
        //    }
        //    Console.Clear();
        //    Console.WriteLine($"Your result: {correct}/{test.Count}");
        //}
        //static void MoveArrow(in int answersCount, out ConsoleKey pressed, ref int selected)
        //{
        //    pressed = Console.ReadKey().Key;
        //    if (pressed == ConsoleKey.UpArrow)
        //    {
        //        selected = (selected + answersCount - 1) % answersCount;
        //    }
        //    else if (pressed == ConsoleKey.DownArrow)
        //    {
        //        selected = (selected + answersCount + 1) % answersCount;
        //    }
        //}
        //static void PrintQuestion(KeyValuePair<QuestionEntity, List<AnswerEntity>> pair, int selected)
        //{
        //    Console.Clear();
        //    Console.WriteLine(pair.Key.Text);
        //    for (int i = 0; i < pair.Value.Count; i++)
        //    {
        //        if (i == selected)
        //        {
        //            Console.WriteLine($">>{pair.Value[i].Text}<<");
        //        }
        //        else
        //        {
        //            Console.WriteLine($"--{pair.Value[i].Text}--");
        //        }
        //    }
        //}

    }
}
