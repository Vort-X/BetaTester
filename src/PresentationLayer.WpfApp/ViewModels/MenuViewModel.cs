using PresentationLayer.WpfApp.Commands;
using PresentationLayer.WpfApp.Models;
using PresentationLayer.WpfApp.Navigation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows;
using System.Windows.Input;

namespace PresentationLayer.WpfApp.ViewModels
{
    public class MenuViewModel : BaseViewModel, INotifyPropertyChanged
    {
        //readonly TestProcessor processor;

        public MenuViewModel(TestViewModel test,
                             ConfigViewModel config,
                             LeaderTableViewModel leaderTable,
                             TestProcessor processor,
                             NavigationService navigationService)
        {
            //this.processor = processor;

            StartTestCommand = new UnconditionalCommand(_ =>
            { 
                processor.GenerateTest();
                test.OnQuestionUpdate();
                navigationService.NavigateTo("Test"); 
            });
            ConfigurateTestCommand = new UnconditionalCommand(_ => 
            {
                config.RefreshConfig();
                navigationService.NavigateTo("Config"); 
            });
            LeaderTableCommand = new UnconditionalCommand(_ => 
            {
                leaderTable.RefreshLeaders();
                navigationService.NavigateTo("LeaderTable"); 
            });
        }

        public ICommand StartTestCommand { get; set; }
        public ICommand ConfigurateTestCommand { get; set; }
        public ICommand LeaderTableCommand { get; set; }
        public ICommand ExitAppCommand { get; set; } = new UnconditionalCommand(_ => Application.Current.Shutdown());
    }
}
