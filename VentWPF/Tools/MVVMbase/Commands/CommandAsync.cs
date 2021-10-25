using System;
using System.Threading.Tasks;

namespace VentWPF.Tools
{
    /// <summary>
    /// Асинхронная реализация комманды для MVVM паттерна
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class CommandAsync<T> : Command<T>
    {

        public CommandAsync(Action<T> action) : base(action)
        {
        }

        public override void Execute(object parameter) => Task.Run(() => this.action((T)parameter));

    }
}