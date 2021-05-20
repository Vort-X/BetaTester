using System;
using System.Windows.Input;

namespace PresentationLayer.WpfApp.Commands
{
    public class UnconditionalCommand : ICommand
    {
        private readonly Action<object> action;

        public UnconditionalCommand(Action<object> action)
        {
            this.action = action;
        }

        public event EventHandler CanExecuteChanged
        {
            add { }
            remove { }
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            action?.Invoke(parameter);
        }
    }
}
