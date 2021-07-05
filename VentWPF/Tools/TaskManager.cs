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

        public static void Add(Action t)
        {
            tasks.Enqueue(t);
            if (!IsWorking)
                Task.Run(() => DoTasks());
        }

        static bool IsWorking = false;

        static void DoTasks()
        {
            
            IsWorking = true;
            while(tasks.Count>0)
            {
                Debug.WriteLine(tasks.Count);
                var action = tasks.Dequeue();
                action.Invoke();
            }
            IsWorking = false;
        }
    }
}
