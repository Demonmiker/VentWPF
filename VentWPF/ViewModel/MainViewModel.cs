using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;
using VentWPF.Tools;

namespace VentWPF.ViewModel
{
    internal class MainViewModel : BaseViewModel
    {

        public MainViewModel()
        {
            Table = new ObservableCollection<Element>()
            {
                new Heater_Gas(),new Heater_Water(),new Heater_Electric(),new Cooler_Fr(),new Cooler_Water(),new(),new (),new(),new (),new(),
                new Filter_Section(),new Filter_Short(),new Filter_Valve(),new(),new (),new(),new (),new(),new (),new(),
            };

            AddElement = new()
            {
                action = (x) => SelectedElement = (Element)x
            };
        }

        public ObservableCollection<Element> Table { get; set; }

        
        public Element SelectedElement { get; set; }

        public Command AddElement { get; init; }
      

        
    }
}
