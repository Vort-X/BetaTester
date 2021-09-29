using PresentationLayer.WpfApp.Navigation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Controls;

namespace PresentationLayer.WpfApp.ViewModels
{
    public class MainViewModel : BaseViewModel, INotifyPropertyChanged
    {
        private UserControl currentView;
        private readonly NavigationService navigationService;
        private readonly IEnumerable<UserControl> controls;

        public MainViewModel(IEnumerable<UserControl> controls, NavigationService navigationService)
        {
            this.controls = controls;
            this.navigationService = navigationService;

            navigationService.CurrentViewChanged += RefreshView;
            navigationService.NavigateTo("Menu");
        }

        public UserControl CurrentView 
        {
            get => currentView;
            private set => Update(ref currentView, value);
        }

        private void RefreshView()
        {
            if (controls.Contains(navigationService.CurrentView))
                CurrentView = navigationService.CurrentView;
        }
    }
}
