using BusinessLogicLayer.Interfaces;
using BusinessLogicLayer.Services;
using DataLayer.Database;
using DataLayer.Interfaces;
using DataLayer.Repositories;
using DataLayer.UnitOfWork;
using Microsoft.Extensions.DependencyInjection;
using PresentationLayer.WpfApp.Models;
using PresentationLayer.WpfApp.ViewModels;
using PresentationLayer.WpfApp.Views;
using System.Windows;
using System.Windows.Controls;

namespace PresentationLayer.WpfApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            var services = new ServiceCollection();
            ConfigureServices(services);
            var provider = services.BuildServiceProvider();
            var w = provider.GetRequiredService<MainWindow>();
            w.Show();
        }

        private void ConfigureServices(ServiceCollection services)
        {
            ConfigureDAL(services);
            ConfigureBLL(services);
            ConfigurePL(services);
        }

        private void ConfigurePL(ServiceCollection services)
        {
            services.AddScoped<MainWindow>();

            services.AddScoped<UserControl, MenuView>()
                .AddScoped<UserControl, TestView>()
                .AddScoped<UserControl, ConfigView>()
                .AddScoped<UserControl, LeaderTableView>();

            services.AddScoped<MainViewModel>()
                .AddScoped<MenuViewModel>()
                .AddScoped<TestViewModel>()
                .AddScoped<ConfigViewModel>()
                .AddScoped<LeaderTableViewModel>();

            services.AddScoped<TestProcessor>()
                .AddScoped<LeaderTableProcessor>();

            services.AddScoped<Navigation.NavigationService>();
        }

        private void ConfigureBLL(ServiceCollection services)
        {
            services.AddScoped<IAttemptService, AttemptService>()
                .AddScoped<IQuestionService, QuestionService>();
        }

        private void ConfigureDAL(ServiceCollection services)
        {
            services.AddDbContext<TesterContext>()
                .AddScoped<IUnitOfWork, UnitOfWork>();
        }
    }
}
