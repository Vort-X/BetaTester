using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace PresentationLayer.WpfApp.Commands
{
    public class Command : ICommand
    {
        private readonly Action<object> action;
        private readonly Func<object, bool> condition;

        public Command(Action<object> action, Func<object, bool> condition)
        {
            this.action = action;
            this.condition = condition;
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object parameter)
        {
            return condition.Invoke(parameter);
        }

        public void Execute(object parameter)
        {
            action?.Invoke(parameter);
        }
    }
}
