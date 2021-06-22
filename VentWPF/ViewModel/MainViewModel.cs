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
                new Heater_Gas(),new Heater_Water(),new Heater_Electric(),new Cooler_Fr(),new Cooler_Water(),
                new Muffler(),new Muffler_Corrector(),new Filter_Section(),new Filter_Short(),new Filter_Valve(),
                new Section_Straight(),new Section_Up(),new Section_Down(),new Section_Down_Reverse(),new  Valve_Hor(),
                new Valve_Hor_Heat(),new Valve_Ver(),new Valve_Ver_Heat(),new (),new(),
            };
            AddElementCommand = new()
            {
                action = (x) =>
                {
                    if (SelectedIndex >= 0 && SelectedIndex < Table.Count)
                        Table[SelectedIndex] = (Element)x;
                }
            };

           
        }

        public ObservableCollection<Element> Table { get; set; }

        public int SelectedIndex { get; set; } = 0;

        public Element SelectedElement { get; set; }

        public Command AddElementCommand { get; init; }

        public ImageCollection HeaderImages { get; init; } = new ImageCollection();

       
      

        
    }
}
