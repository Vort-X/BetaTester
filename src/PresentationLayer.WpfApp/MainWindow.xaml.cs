﻿using PresentationLayer.WpfApp.Commands;
using PresentationLayer.WpfApp.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PresentationLayer.WpfApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow(IEnumerable<INavigatable> userControls)
        {
            InitializeComponent();

            Views = userControls;
            foreach (var item in Views)
            {
                item.BuildNavigation(this);
            }
        }

        public IEnumerable<INavigatable> Views { get; private set; }

        public void ShowView<T>() where T : INavigatable
        {
            Func<INavigatable, bool> predicate = v => v is T;
            if (Views.Any(predicate))
            {
                INavigatable view = Views.Single(predicate);
                view.Refresh();
                Content = view;
            }
        }
    }
}
