using System.Collections.ObjectModel;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows;
using VentWPF.Model;
using VentWPF.Tools;
using System.Windows.Data;
using System.Windows.Media;

namespace VentWPF.ViewModel
{
    internal class MainViewModel : BaseViewModel
    {
        public MainViewModel()
        {
            InitTable(CurrentProject.Rows);



            CmdAddElement = new(AddElement);
            CmdAutoColumns = new(AutoColumns);
        }

        public ProjectVM CurrentProject { get; set; } = Element.project;
        public ImageCollection HeaderImages { get; init; } = new ImageCollection();

        #region Комманды

        public Command<Element> CmdAddElement { get; init; }

        public Command<DataGridAutoGeneratingColumnEventArgs> CmdAutoColumns { get; init; }

        public Command<Popup> CmdOpenPopup { get; init; } = new Command<Popup>(OpenPopup);

        private void AutoColumns(DataGridAutoGeneratingColumnEventArgs e)
        {
            if(SelectedElement.Format.ContainsKey(e.Column.Header.ToString()))
            {
                Style defaultStyle = Application.Current.TryFindResource(typeof(DataGridCell)) as Style;
                Style style = new Style(typeof(DataGridCell), defaultStyle);

                style.Setters.Add(new Setter()
                {
                    Property = DataGridCell.BackgroundProperty,
                    Value = Brushes.Pink,
                });
                var tg = new Trigger();

                style.Triggers.Add(new DataTrigger()
                {
                    Binding = new Binding(e.Column.Header.ToString()) { Converter = SelectedElement.Format[e.Column.Header.ToString()].conv },
                    Value = true,
                    Setters =
                {
                    new Setter() { Property = DataGridCell.BackgroundProperty, Value = Brushes.PaleGreen}
                }
                }); ;
                e.Column.Header = SelectedElement.Format[e.Column.Header.ToString()].name;
                e.Column.CellStyle = style;
            }
           


        }

        private static void OpenPopup(Popup p)
        {
            p.HorizontalOffset = 1;
            p.IsOpen = true;
        }

        private void AddElement(Element e)
        {
            if (SelectedIndex >= 0 && SelectedIndex < Table.Count)
                Table[SelectedIndex] = e;
        }
        #endregion Комманды

        #region Таблица со схемой

        public Element SelectedElement { get; set; }
        public int SelectedIndex { get; set; } = 0;
        public ObservableCollection<Element> Table { get; set; }

        public void InitTable(Rows rows)
        {
            if (rows == Rows.Row1)
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

        #endregion Таблица со схемой
    }
}