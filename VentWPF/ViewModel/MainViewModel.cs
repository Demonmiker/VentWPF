using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;

namespace VentWPF.ViewModel
{
    internal class MainViewModel : BaseViewModel
    {

        public MainViewModel()
        {
            Table = new ObservableCollection<Element>()
            {
                new Heater_Gas(),new Heater_Water(),new Heater_Electric(),new(),new (),new(),new (),new(),new (),new(),
                new (),new(),new (),new(),new (),new(),new (),new(),new (),new(),
            };
        }

        public ObservableCollection<Element> Table { get; set; }

        
        public Element SelectedElement { get; set; }
      

        
    }
}
