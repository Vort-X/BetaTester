using PresentationLayer.WpfApp.Commands;
using PresentationLayer.WpfApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;

namespace PresentationLayer.WpfApp.ViewModels
{
    public class ConfigViewModel : BaseViewModel, INotifyPropertyChanged
    {
        private readonly TestProcessor processor;
        //private ObservableCollection<> config;

        public ConfigViewModel(TestProcessor processor)
        {
            this.processor = processor;

            MenuCommand = new NavigationCommand(_ => {
            
            }, _ => true);
        }

        public ICommand MenuCommand { get; set; }

        public void RefreshConfig()
        {

        }
    }
}
