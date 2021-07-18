using System;
using System.Collections.Generic;
using System.Linq;
using System.Collections.ObjectModel;
using System.ComponentModel;
using PropertyChanged;

namespace VentWPF.ViewModel
{
    internal class ErrorManagerVM : BaseViewModel
    {
        List<ValidViewModel> ValidModels { get; init; } = new();

        List<string> Names { get; init; } = new();


        public ObservableCollection<string> Errors { get; init; } = new ObservableCollection<string>();

        [DependsOn("errorCount")]
        public bool HasErrors => errorCount > 0;


        private int errorCount { get; set; } = 0;

        public void Add(ValidViewModel o,string name)
        {
            int ind = Names.FindIndex(x => x == name);
            if(ind==-1)
            {
                ValidModels.Add(o);
                Errors.Add("");
                Names.Add(name);
                Update(o, null);
                o.PropertyChanged += Update;
            }
            else
            {
                ValidModels[ind].PropertyChanged -= Update;
                ValidModels[ind] = o;
                Update(o, null);
                o.PropertyChanged += Update;
            }

        
          
        }


        public void AddRange(IEnumerable<(string name,ValidViewModel model)> arr)
        {
            foreach (var o in arr)
                Add(o.model,o.name);

        }

        private void Update(object sender, PropertyChangedEventArgs e)
        {
            int ind = ValidModels.IndexOf(sender as ValidViewModel);
            string error = ValidModels[ind].Error;
            bool old = Errors[ind].Length > 0;
            bool cur = error.Length > 0;
            if (cur && !old)
                errorCount++;
            else if (!cur && old)
                errorCount--;
            if (error!="")
            {
                Errors[ind] = $"\n{(Names[ind]!=null ? Names[ind]+"\n" : "")}{error}";
            }
            else
            {
                 Errors[ind] = "";
            }
           
           
        }

        public void Update()
        {
            foreach (var item in ValidModels)
            {
                Update(item, null);
            }
        }
    }
}
