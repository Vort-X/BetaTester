using PresentationLayer.WpfApp.ViewModels;
using PresentationLayer.WpfApp.Views;
using System;
using System.Collections.Generic;
using System.Windows.Controls;

namespace PresentationLayer.WpfApp.Navigation
{
    public class NavigationService
    {
        private readonly Dictionary<string, UserControl> views;
        private string currentKey;

        public NavigationService()
        {
            views = new Dictionary<string, UserControl>();
        }

        public UserControl CurrentView 
        { 
            get; 
            private set; 
        }

        public event Action CurrentViewChanged;

        public void NavigateTo(string key)
        {
            if (currentKey == key)
            {
                return;
            }
            if (!views.ContainsKey(key))
            {
                return;
            }
            CurrentView = views[key];
            currentKey = key;
            CurrentViewChanged?.Invoke();
        }

        public void Register(string key, UserControl view)
        {
            views[key] = view;
        }
    }
}
