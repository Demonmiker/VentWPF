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
                new("Клапан", "Valve", new ValveHorizontal(), new ValveHorizontalHeat(), new ValveVertical(), new ValveVerticalHeat()),
                new("Фильтр", "Filter", new FilterSection(), new FilterShort(), new FilterValve()),
                new("Нагревателm", "Heater", new HeaterWater(), new HeaterGas(), new HeaterElectric()),
                new("Охладитель", "Cooler", new CoolerFr(), new CoolerWater()),
                new("Вентилятор", "FanC",
                    new FanC() { Direction = FanDirection.LeftRight },
                    new FanC() { Direction = FanDirection.LeftUp },
                    new FanC() { Direction = FanDirection.RightLeft },
                    new FanC() { Direction = FanDirection.UpLeft }
                ),
                new("Вентилятор улиточный", "FanP",
                    new FanP { Direction = FanDirection.LeftRight },
                    new FanP { Direction = FanDirection.LeftUpLeft },
                    new FanP { Direction = FanDirection.LeftUpRight },
                    new FanP { Direction = FanDirection.RightLeft },
                    new FanP { Direction = FanDirection.RightUpLeft }
                ),
                new("Вентилятор потоковый", "FanK3G",
                    new FanK3G() { Direction = FanDirection.LeftRight },
                    new FanK3G() { Direction = FanDirection.LeftUp },
                    new FanK3G() { Direction = FanDirection.RightLeft }
                ),
                new("Секция", "Section",
                    new Section() { Direction = SectionType.LeftRight },
                    new Section() { Direction = SectionType.LeftUpDown },
                    new Section() { Direction = SectionType.LeftDown },
                    new Section() { Direction = SectionType.LeftUp },
                    new Section() { Direction = SectionType.RightDown },
                    new Section() { Direction = SectionType.LeftUpRight },
                    new Section() { Direction = SectionType.LeftRightDown },
                    new Section() { Direction = SectionType.LeftRightShort },
                    new Section() { Direction = SectionType.LeftRightValve },
                    new Section() { Direction = SectionType.LeftUpRightValve }
                    //new Section() { Direction = SectionType.LeftRightShort , TwoRowsOnly=true},//Для только двухярусных
                ),
                new("Шумоглушитель", "Muffler", new MufflerDefault(), new MufflerCorrector()),
                new("Увлажнитель", "Humidifier", new HumidCell(), new HumidSpray(), new HumidSteam()),
                new("Рекуператор", "Recuperator", true),
            };
        }

        public List<CreateMenu> Menus { get; set; }
    }

    internal class CreateMenu
    {
        public CreateMenu(string name, string image, params Element[] elements)
        {
            Name = name;
            Image = Path.GetFullPath($"Assets/Images/Icons/_Menu/{image}.png");
            Elements = elements.Select(x => new CreateButton(x)).ToList();
            CmdOpenPopup = new Command<Popup>(OpenPopup);
        }

        public CreateMenu(string name, string image, bool twoRowsOnly, params Element[] elements)
        {
            TwoRowsOnly = twoRowsOnly;
            Name = name;
            Image = Path.GetFullPath($"Assets/Images/Icons/_Menu/{image}.png");
            Elements = elements.Select(x => new CreateButton(x)).ToList();
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

        public Element Element { get; init; }

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