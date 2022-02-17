using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;

namespace VentWPF.ViewModel
{
    /// <summary>
    /// Этот класс служит для выполнения операций параллельно
    /// Ставит операции в очередь
    /// </summary>
    public class TaskManagerVM : BaseViewModel
    {
        private Stopwatch Sw = new();

        private bool IsWorking = false;


        public int Count { get; set; }
        private ObservableCollection<Action> Tasks { get; init; } = new ObservableCollection<Action>();

        /// <summary>
        /// Добавить операцию на выполнение
        /// </summary>
        /// <param name="t"></param>
        public void Add(Action t)
        {
            Tasks.Add(t);
            Count = Tasks.Count;
            if (!IsWorking)
            {
                IsWorking = true;
                Task.Run(() => DoTasks());
            }
        }

        private void DoTasks()
        {
            IsWorking = true;
            Sw.Restart();
            while (Tasks.Count > 0)
            {
                Action action = Tasks[0];
                Tasks.RemoveAt(0);
                action.Invoke();
                Count = Tasks.Count;
            }
            Sw.Stop();
            IsWorking = false;
        }
    }
}