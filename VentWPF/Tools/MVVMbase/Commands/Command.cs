using System;
using System.Windows.Input;

namespace VentWPF.Tools
{
    /// <summary>
    /// Класс комманды для реализации MVVM паттерна
    /// @@warn можно написать лучше
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Command<T> : ICommand
    {
        public Command(Action<T> action,Func<T,bool> predicate)
        {
            this.action = action;
            this.predicate = predicate;
        }

        public Command(Action<T> action)
        {
            this.action = action;
        }

        public Command()
        {
        }

#pragma warning disable 67

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

#pragma warning restore 67
        public Action<T> action { get; init; }

        public Func<T,bool> predicate { get; init; }

        public bool CanExecute(object parameter) => predicate == null ? true : predicate((T)parameter);

        public virtual void Execute(object parameter) => action((T)parameter);

        public void RaiseCanExecuteChanged() => CommandManager.InvalidateRequerySuggested();

    }
    public class Command : ICommand
    {

        public Command(Action action,Func<bool> predicate)
        {
            this.action = action;
            this.predicate = predicate;
        }
        public Command(Action action)
        {
            this.action = action;
        }

        public Command()
        {
        }

#pragma warning disable 67

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }
#pragma warning restore 67
        public Action action { get; init; }

        public Func<bool> predicate { get; init; }

        public bool CanExecute(object parameter) => predicate == null ? true : predicate();

        public virtual void Execute(object parameter) => action();

        public void RaiseCanExecuteChanged() => CommandManager.InvalidateRequerySuggested();

    }
}