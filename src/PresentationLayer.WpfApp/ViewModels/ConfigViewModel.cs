﻿using PresentationLayer.Models;
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
    public class ConfigViewModel : BaseViewModel, INotifyPropertyChanged
    {
        private ObservableCollection<ConfigRowModel> config;
        private readonly TestProcessor processor;

        public ConfigViewModel(TestProcessor processor)
        {
            this.processor = processor;

            MenuCommand = new NavigationCommand(_ => 
            {
                foreach (var item in Config)
                {
                    processor.Config[item.Difficulty] = item.NumberOfQuestions;
                }
            }, _ => true);
        }

        public ObservableCollection<ConfigRowModel> Config
        { 
            get => config; 
            private set => Update(ref config, value); 
        }

        public ICommand MenuCommand { get; set; }

        public void RefreshConfig()
        {
            Config = new ObservableCollection<ConfigRowModel>(processor.Config
                .Select(d => new ConfigRowModel(d.Key, d.Value)));
        }
    }
}
