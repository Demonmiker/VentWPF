using PropertyChanged;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace VentWPF.ViewModel
{
    /// <summary>
    /// Менеджер обработки ошибок всего проекта
    /// </summary>
    internal class ErrorManagerVM : BaseViewModel
    {
        public ObservableCollection<string> Errors { get; init; } = new ObservableCollection<string>();

        [DependsOn("errorCount")]
        public bool HasErrors => errorCount > 0;

        private List<ValidViewModel> ValidModels { get; init; } = new();

        private List<string> Names { get; init; } = new();

        private int errorCount { get; set; } = 0;

        public void Add(ValidViewModel o, string name)
        {
            int ind = Names.FindIndex(x => x == name);
            if (ind == -1)
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

        public void AddRange(IEnumerable<(string name, ValidViewModel model)> arr)
        {
            foreach (var o in arr)
                Add(o.model, o.name);
        }

        public void Update()
        {
            foreach (var item in ValidModels)
            {
                Update(item, null);
            }
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
            if (error != "")
            {
                Errors[ind] = $"\n{(Names[ind] != null ? Names[ind] + "\n" : "")}{error}";
            }
            else
            {
                Errors[ind] = "";
            }
        }
    }
}