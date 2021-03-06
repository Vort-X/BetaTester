using PresentationLayer.WpfApp.Commands;
using PresentationLayer.WpfApp.Navigation;
using PresentationLayer.WpfApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
//using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PresentationLayer.WpfApp.Views
{
    /// <summary>
    /// Логика взаимодействия для LeaderTableView.xaml
    /// </summary>
    public partial class LeaderTableView : UserControl
    {
        readonly LeaderTableViewModel viewModel;

        public LeaderTableView(LeaderTableViewModel viewModel, NavigationService navigationService)
        {
            InitializeComponent();

            this.viewModel = viewModel;
            DataContext = viewModel;
            navigationService.Register("LeaderTable", this);
        }
    }
}
