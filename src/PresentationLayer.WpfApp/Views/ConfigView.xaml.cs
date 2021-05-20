using PresentationLayer.WpfApp.Commands;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PresentationLayer.WpfApp.Views
{
    /// <summary>
    /// Логика взаимодействия для ConfigView.xaml
    /// </summary>
    public partial class ConfigView : UserControl, INavigatable
    {
        private readonly ConfigViewModel viewModel;

        public ConfigView(ConfigViewModel viewModel)
        {
            InitializeComponent();

            this.viewModel = viewModel;
            DataContext = viewModel;
        }

        public void BuildNavigation(MainWindow window)
        {
            (viewModel.MenuCommand as NavigationCommand).Navigation = window.ShowView<MenuView>;
        }

        public void Refresh()
        {
            viewModel.RefreshConfig();
        }
    }
}
