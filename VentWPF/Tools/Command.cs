using System;
using System.Threading.Tasks;
using System.Windows.Input;

namespace VentWPF.Tools
{
    public class Command<T> : ICommand
    {
        public Command(Action<T> action)
        {
            this.action = action;
        }

        public Command()
        {
        }

#pragma warning disable 67
        public event EventHandler CanExecuteChanged;
#pragma warning restore 67

        public Action<T> action { get; init; }
        public Predicate<object> predicate { get; init; }

        public bool CanExecute(object parameter) => predicate == null ? true : predicate(parameter);

        public virtual void Execute(object parameter) => action((T)parameter);

        public void RaiseCanExecuteChanged()
        {
            CommandManager.InvalidateRequerySuggested();
        }
    }

    public class CommandAsync<T> : Command<T>
    {
        public CommandAsync(Action<T> action) : base(action)
        {
        }

        public CommandAsync()
        {
        }

        public override void Execute(object parameter) => Task.Run(() => this.action((T)parameter));
    }
}