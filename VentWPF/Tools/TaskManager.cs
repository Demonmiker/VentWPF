using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VentWPF.Tools
{
    public static class TaskManager
    {
        static Queue<Action> tasks = new Queue<Action>();
        static Stopwatch Sw = new Stopwatch();

        public static void Add(Action t)
        {
            tasks.Enqueue(t);
            if (!IsWorking)
            {
                IsWorking = true;
                Task.Run(() => DoTasks());
            }
                
        }

        static bool IsWorking = false;

        static void DoTasks()
        {
            Debug.WriteLine($"TM Start");
            IsWorking = true;
            Sw.Restart();
            while(tasks.Count>0)
            {
                Debug.WriteLine(tasks.Count);
                var action = tasks.Dequeue();
                action.Invoke();
                Debug.WriteLine($"Запрос :{Sw.ElapsedTicks} тик");
            }
            Sw.Stop();
            
            IsWorking = false;
            Debug.WriteLine($"TM Stop");

        }
    }
}
