using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls.Primitives;
using VentWPF.Tools;

namespace VentWPF.ViewModel
{
    internal class CreateViewModel
    {
        public CreateViewModel()
        {
            Menus = new()
            {
                new("Клапан", "Valves/Valves.png", new Valve_Hor(), new Valve_Hor_Heat(), new Valve_Ver(), new Valve_Ver_Heat()),
                new("Фильтр", "Filters/Filters.png", new Filter_Section(), new Filter_Short(), new Filter_Valve()),
                new("Нагревателm", "Heaters/Heaters.png", new Heater_Water(), new Heater_Gas(), new Heater_Electric()),
                new("Охладитель", "Coolers/Coolers.png", new Cooler_Fr(), new Cooler_Water()),
                new("Вентилятор", "Fans/Fan_C.png"),
                new("Вентилятор улиточный", "Fans/Fan_P.png"),
                new("Вентилятор потоковый", "Fans/Fan_K3G.png"),
                new("Секция", "Sections/Sections.png"),
                new("Шумоглушитель", "Mufflers/Mufflers.png", new Muffler_Classic(), new Muffler_Corrector()),
                new("Увлажнитель", "Humidifiers/Humidifiers.png", new Humid_Cell(), new Humid_Spray(), new Humid_Steam()),
                new("Рекуператор", "Recuperators/Recuperators.png"),
            };
        }

        public List<CreateMenu> Menus { get; set; }
    }

    internal class CreateMenu
    {
        public CreateMenu(string name, string image, params Element[] elements)
        {
            Name = name;
            Image = Path.GetFullPath($"Assets/Images/{image}");
            Elements = elements.Select(x => new CreateButton(x)).ToList();
            CmdOpenPopup = new Command<Popup>(OpenPopup);
        }

        public string Name { get; set; }

        public string Image { get; set; }

        public List<CreateButton> Elements { get; set; }

        public Command<Popup> CmdOpenPopup { get; set; }

        private void OpenPopup(Popup p)
        {
            p.VerticalOffset = 80;
            p.IsOpen = true;
        }
    }

    internal class CreateButton
    {
        public CreateButton(Element el)
        {
            CmdAdd = new Command<object>((x) => Add());
            Element = el;
        }

        public Element Element { get; set; }

        public Command<object> CmdAdd { get; set; } = new Command<object>();

        // Добавляет элемент
        private void Add()
        {
            ProjectVM.Current.Grid.AddElement(Element);
        }
    }
}