using PresentationLayer.WpfApp.Commands;
using PresentationLayer.WpfApp.Models;
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

        public MenuViewModel(TestProcessor processor)
        {
            //this.processor = processor;

            StartTestCommand = new NavigationCommand(_ => processor.GenerateTest(), _ => true);
            ConfigurateTestCommand = new NavigationCommand(_ => { }, _ => true);
            LeaderTableCommand = new NavigationCommand(_ => { }, _ => true);
        }

        public ICommand StartTestCommand { get; set; }
        public ICommand ConfigurateTestCommand { get; set; }
        public ICommand LeaderTableCommand { get; set; }
        public ICommand ExitAppCommand { get; set; } = new UnconditionalCommand(_ => Application.Current.Shutdown());
    }
}
