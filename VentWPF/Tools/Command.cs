using System;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Input;

namespace VentWPF.Tools
{
    public class Command<T> : ICommand
    {
        public Action<T> action { get; init; }

        public Command(Action<T> action)
        {
            this.action = action;
        }

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

        public virtual void Execute(object parameter) => action((T)parameter);

    }


    public class CommandAsync<T> : Command<T>
    {
        public CommandAsync(Action<T> action) : base(action) { }

        public override void Execute(object parameter) => Task.Run(() => this.action((T)parameter));
    }
}