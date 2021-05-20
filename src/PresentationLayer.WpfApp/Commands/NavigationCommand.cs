using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace PresentationLayer.WpfApp.Commands
{
    public class NavigationCommand : ICommand
    {
        private readonly Command command;

        public NavigationCommand(Action<object> action, Func<object, bool> condition)
        {
            command = new Command(action, condition);
        }

        public Action Navigation { get; set; }

        public event EventHandler CanExecuteChanged
        {
            add { command.CanExecuteChanged += value; }
            remove { command.CanExecuteChanged -= value; }
        }

        public bool CanExecute(object parameter)
        {
            return command.CanExecute(parameter);
        }

        public void Execute(object parameter)
        {
            command.Execute(parameter);
            Navigation?.Invoke();
        }
    }
}
