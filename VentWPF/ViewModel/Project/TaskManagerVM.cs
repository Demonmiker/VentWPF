using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VentWPF.ViewModel;

namespace VentWPF.ViewModel
{
    public class TaskManagerVM : BaseViewModel
    {
        ObservableCollection<Action> Tasks { get; init; } = new ObservableCollection<Action>();

        Stopwatch Sw = new Stopwatch();

        [DependsOn("Tasks")]
        public int Count => Tasks.Count;

        public void Add(Action t)
        {
            Tasks.Add(t);
            if (!IsWorking)
            {
                IsWorking = true;
                Task.Run(() => DoTasks());
            }
                
        }

        bool IsWorking = false;

        void DoTasks()
        {
            Debug.WriteLine($"TM Start");
            IsWorking = true;
            Sw.Restart();
            while(Tasks.Count>0)
            {
                Debug.WriteLine(Tasks.Count);
                var action = Tasks[0];
                Tasks.RemoveAt(0);
                action.Invoke();
                Debug.WriteLine($"Запрос :{Sw.ElapsedTicks} тик");
            }
            Sw.Stop();
            
            IsWorking = false;
            Debug.WriteLine($"TM Stop");

        }
    }
}
