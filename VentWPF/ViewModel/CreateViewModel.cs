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
                new("Вентилятор", "Fans/Fan_C.png",
                    new Fan_C() { Direction = Fan_Direction.LeftRight },
                    new Fan_C() { Direction = Fan_Direction.LeftUp },
                    new Fan_C() { Direction = Fan_Direction.RightLeft },
                    new Fan_C() { Direction = Fan_Direction.UpLeft }
                ),
                new("Вентилятор улиточный", "Fans/Fan_P.png",
                    new Fan_P { Direction = Fan_Direction.LeftRight },
                    new Fan_P { Direction = Fan_Direction.LeftUpLeft },
                    new Fan_P { Direction = Fan_Direction.LeftUpRight },
                    new Fan_P { Direction = Fan_Direction.RightLeft },
                    new Fan_P { Direction = Fan_Direction.RightUpLeft }
                ),
                new("Вентилятор потоковый", "Fans/Fan_K3G.png",
                    new Fan_K3G() { Direction = Fan_Direction.LeftRight },
                    new Fan_K3G() { Direction = Fan_Direction.LeftUp },
                    new Fan_K3G() { Direction = Fan_Direction.RightLeft }
                ),
                new("Секция", "Sections/Sections.png",
                    new Section() { Direction = SectionType.LR },
                    new Section() { Direction = SectionType.LUD },
                    new Section() { Direction = SectionType.LD },
                    new Section() { Direction = SectionType.LU },
                    new Section() { Direction = SectionType.RD },
                    new Section() { Direction = SectionType.LUR },
                    new Section() { Direction = SectionType.LRD },
                    new Section() { Direction = SectionType.LR_Short },
                    new Section() { Direction = SectionType.LR_Valve },
                    new Section() { Direction = SectionType.LUR_Valve }
                ),
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