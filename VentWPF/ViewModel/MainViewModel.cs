using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Markup;
using VentWPF.Model;
using VentWPF.Tools;

namespace VentWPF.ViewModel
{
    internal class MainViewModel : BaseViewModel
    {

        public MainViewModel()
        {
            InitTable(CurrentProject.Rows);

            AddElementCommand = new()
            {
                action = (x) =>
                {
                    if (SelectedIndex >= 0 && SelectedIndex < Table.Count)
                        Table[SelectedIndex] = (Element)x;
                }
            };
            //Not Used
            CmdClosePopup = new()
            {
                action = (x) =>
                {
                    (x as Popup).IsOpen = false;
                }
            };
            CmdOpenPopup = new()
            {
                action = (o) =>
                {
                    
                    Popup p = o as Popup;
                    p.HorizontalOffset = 1;
                    p.IsOpen = true;
                }
            };

            ChangeSize = new()
            {
                action = (x) =>
                {
                    InitTable(CurrentProject.Rows);
                }
            };


        }

        public ObservableCollection<Element> Table { get; set; }

        public int SelectedIndex { get; set; } = 0;

        public Element SelectedElement { get; set; }

        public Command AddElementCommand { get; init; }

        public Command CmdOpenPopup { get; init; }

        public Command CmdClosePopup { get; init; }

        public Command ChangeSize { get; init; }

        public ImageCollection HeaderImages { get; init; } = new ImageCollection();

        public ProjectVM CurrentProject { get; set; } = Element.project;

        public Rows RowCount
        {
            get { return CurrentProject.Rows; }
            set 
            { 
                CurrentProject.Rows = value;
                InitTable(CurrentProject.Rows);
            }
        }

        public void InitTable(Rows rows)
        {
            if(rows==Rows.Row1) 
            {
                Table = new ObservableCollection<Element>()
                {
                    new Heater_Gas(),new Heater_Water(),new Heater_Electric(),new Cooler_Fr(),new Cooler_Water(),
                    new Muffler(),  new Muffler_Corrector(),new Filter_Section(),new Filter_Short(),new Filter_Valve(),
                };
            }
            else
            {
                Table = new ObservableCollection<Element>()
                {
                    new Heater_Gas(),new Heater_Water(),new Heater_Electric(),new Cooler_Fr(),new Cooler_Water(),
                    new Muffler(),new Muffler_Corrector(),new Filter_Section(),new Filter_Short(),new Filter_Valve(),
                    new Section_Straight(),new Section_Up(),new Section_Down(),new Section_Down_Reverse(),new  Valve_Hor(),
                    new Valve_Hor_Heat(),new Valve_Ver(),new Valve_Ver_Heat(),new (),new(),
                };
            }
        }
      

        
    }
}
