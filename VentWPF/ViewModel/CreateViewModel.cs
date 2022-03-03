using System.Collections.Generic;
using System.IO;
using System.Linq;
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
                new("Клапан", "Valve",false,
                    new(new ValveHorizontal()),
                    new(new ValveHorizontalHeat()),
                    new(new ValveVertical()),
                    new(new ValveVerticalHeat())),
                new("Фильтр", "Filter",false,
                    new(new FilterSection()),
                    new(new FilterShort()),
                    new(new FilterValve())),
                new("Нагревателm", "Heater",false,
                    new(new HeaterWater()),
                    new(new HeaterGas()),
                    new(new HeaterElectric())),
                new("Охладитель", "Cooler",false,
                    new(new CoolerFr()),
                    new(new CoolerWater())),
                new("Вентилятор", "FanC",false,
                    new(new FanC() { Direction = FanDirection.LeftRight }),
                    new(new FanC() { Direction = FanDirection.LeftUp }),
                    new(new FanC() { Direction = FanDirection.RightLeft }),
                    new(new FanC() { Direction = FanDirection.UpLeft })),
                new("Вентилятор улиточный", "FanP",false,
                    new(new FanP { Direction = FanDirection.LeftRight }),
                    new(new FanP { Direction = FanDirection.LeftUpLeft }),
                    new(new FanP { Direction = FanDirection.LeftUpRight }),
                    new(new FanP { Direction = FanDirection.RightLeft }),
                    new(new FanP { Direction = FanDirection.RightUpLeft })),
                new("Вентилятор потоковый", "FanK3G",false,
                    new(new FanK3G() { Direction = FanDirection.LeftRight }),
                    new(new FanK3G() { Direction = FanDirection.LeftUp }),
                    new(new FanK3G() { Direction = FanDirection.RightLeft })),
                new("Секция", "Section",false,
                    new(new Section() { Direction = SectionType.LeftRight }),
                    new(new Section() { Direction = SectionType.LeftUpDown }),
                    new(new Section() { Direction = SectionType.LeftDown }),
                    new(new Section() { Direction = SectionType.LeftUp }),
                    new(new Section() { Direction = SectionType.RightDown }),
                    new(new Section() { Direction = SectionType.LeftUpRight }),
                    new(new Section() { Direction = SectionType.LeftRightDown }),
                    new(new Section() { Direction = SectionType.LeftRightShort }),
                    new(new Section() { Direction = SectionType.LeftRightValve }),
                    new(new Section() { Direction = SectionType.LeftUpRightValve }),
                    new(new SectionDouble() { Direction = SectionType.LeftRight},
                        Path.GetFullPath($"Assets/Images/Icons/Sections/Double.png"))
                    //new Section() { Direction = SectionType.LeftRightShort , TwoRowsOnly=true},//Для только двухярусных
                ),
                new("Шумоглушитель", "Muffler", false,
                    new(new MufflerDefault()),
                    new(new MufflerCorrector())),
                new("Увлажнитель", "Humidifier", false,
                    new(new HumidCell()),
                    new(new HumidSpray()),
                    new(new HumidSteam())),
                new("Рекуператор", "Recuperator", true),
            };
        }

        public List<CreateMenu> Menus { get; set; }
    }

    internal class CreateMenu
    {
        public CreateMenu(string name, string image, params CreateButton[] elements)
        {
            Name = name;
            Image = Path.GetFullPath($"Assets/Images/Icons/_Menu/{image}.png");
            Elements = elements.ToList();
            CmdOpenPopup = new Command<Popup>(OpenPopup);
        }

        public CreateMenu(string name, string image, bool twoRowsOnly, params CreateButton[] elements)
        {
            TwoRowsOnly = twoRowsOnly;
            Name = name;
            Image = Path.GetFullPath($"Assets/Images/Icons/_Menu/{image}.png");
            Elements = elements.ToList();
            CmdOpenPopup = new Command<Popup>(OpenPopup);
        }

        public string Name { get; set; }

        public string Image { get; set; }

        public bool TwoRowsOnly { get; set; } = false;

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
            CmdInsert = new Command<object>((x) => Insert());
            Element = el;
            TwoRowsOnly = el.TwoRowsOnly;
        }
        public CreateButton(Element el,string image)
        {
            Image = image;
            CmdAdd = new Command<object>((x) => Add());
            CmdInsert = new Command<object>((x) => Insert());
            Element = el;
            TwoRowsOnly = el.TwoRowsOnly;
        }

        public Element Element { get; init; }

        public string Image { get; init; }

        public bool TwoRowsOnly { get; init; }

        public Command<object> CmdAdd { get; init; } = new Command<object>();

        // Добавляет элемент
        private void Add()
        {
            ProjectVM.Current.Grid.AddElement(Element);
        }
        public Command<object> CmdInsert { get; init; } = new Command<object>();
        private void Insert()
        {
            ProjectVM.Current.Grid.InsertElement(Element);
        }
    }
}