using System;
using System.Collections.Generic;
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
        private Stopwatch Sw = new Stopwatch();

        private bool IsWorking = false;

        public int Count => Tasks.Count;

        private List<Action> Tasks { get; init; } = new List<Action>();

        /// <summary>
        /// Добавить операцию на выполнение
        /// </summary>
        /// <param name="t"></param>
        public void Add(Action t)
        {
            Tasks.Add(t);
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
                Debug.WriteLine($"TM: {Tasks.Count}");
                var action = Tasks[0];
                Tasks.RemoveAt(0);
                action.Invoke();
            }
            Sw.Stop();
            IsWorking = false;
        }
    }
}