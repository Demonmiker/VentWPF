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
        #region Constructors

        public Command(Action<T> action)
        {
            this.action = action;
        }

        public Command()
        {
        }

        #endregion

        #region Events

#pragma warning disable 67

        public event EventHandler CanExecuteChanged;

#pragma warning restore 67

        #endregion

        #region Properties

        public Action<T> action { get; init; }

        public Predicate<T> predicate { get; init; }

        #endregion

        #region Methods

        public bool CanExecute(object parameter) => predicate == null ? true : predicate((T)parameter);

        public virtual void Execute(object parameter) => action((T)parameter);

        public void RaiseCanExecuteChanged() => CommandManager.InvalidateRequerySuggested();

        #endregion
    }
}