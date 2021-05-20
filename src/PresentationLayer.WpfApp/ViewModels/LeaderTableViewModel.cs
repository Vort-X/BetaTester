using PresentationLayer.Models;
using PresentationLayer.WpfApp.Commands;
using PresentationLayer.WpfApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace PresentationLayer.WpfApp.ViewModels
{
    public class LeaderTableViewModel : BaseViewModel, INotifyPropertyChanged
    {
        private readonly LeaderTableProcessor processor;
        private ObservableCollection<AttemptInfoModel> leaders;

        public LeaderTableViewModel(LeaderTableProcessor processor)
        {
            this.processor = processor;

            MenuCommand = new NavigationCommand(_ => { }, _ => true);
        }

        public ObservableCollection<AttemptInfoModel> Leaders 
        { 
            get => leaders; 
            private set => Update(ref leaders, value); 
        }

        public ICommand MenuCommand { get; set; }

        public void RefreshLeaders()
        {
            Leaders = new ObservableCollection<AttemptInfoModel>(processor.GetLeaderTable());
        }
    }
}
