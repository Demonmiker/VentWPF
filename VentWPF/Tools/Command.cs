using System;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Input;

namespace VentWPF.Tools
{
    public class Command : ICommand
    {
        public Action<object> action { get; init; }

        public Predicate<object> predicate { get; init; }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public void RaiseCanExecuteChanged()
        {
            CommandManager.InvalidateRequerySuggested();
        }

        public bool CanExecute(object parameter) => predicate==null ? true : predicate(parameter);

        public virtual void Execute(object parameter) => action(parameter);

    }


    public class CommandAsync : Command
    {
        public override void Execute(object parameter) => Task.Run(() => action(parameter));
    }
}