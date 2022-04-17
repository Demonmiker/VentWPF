using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using VentWPF.Model;
using VentWPF.Tools;

namespace VentWPF.ViewModel
{
    internal class CreateViewModel
    {
        public CreateViewModel()
        {
            Menus = new()
            {
                new("Клапан", "Valve", false,
                    new(new ValveHorizontal()),
                    new(new ValveHorizontalHeat()),
                    new(new ValveVertical()),
                    new(new ValveVerticalHeat())),
                new("Фильтр", "Filter", false,
                    new(new FilterSection()),
                    new(new FilterShort()),
                    new(new FilterValve())),
                new("Нагреватель", "Heater", false,
                    new(new HeaterWater()),
                    new(new HeaterGas()),
                    new(new HeaterElectric())),
                new("Охладитель", "Cooler", false,
                    new(new CoolerFr()),
                    new(new CoolerWater())),
                new("Вентилятор", "FanC", false,
                    new(new FanC() { Direction = FanDirection.LeftRight }),
                    new(new FanC() { Direction = FanDirection.LeftUp }),
                    new(new FanC() { Direction = FanDirection.RightLeft }),
                    new(new FanC() { Direction = FanDirection.UpLeft })),
                new("Вентилятор улиточный", "FanP", false,
                    new(new FanP { Direction = FanDirection.LeftRight }),
                    new(new FanP { Direction = FanDirection.LeftUpLeft }),
                    new(new FanP { Direction = FanDirection.LeftUpRight }),
                    new(new FanP { Direction = FanDirection.RightLeft }),
                    new(new FanP { Direction = FanDirection.RightUpLeft })),
                new("Вентилятор потоковый", "FanK3G", false,
                    new(new FanK3G() { Direction = FanDirection.LeftRight }),
                    new(new FanK3G() { Direction = FanDirection.LeftUp }),
                    new(new FanK3G() { Direction = FanDirection.RightLeft })),
                new("Секция", "Section", false,
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
                    new(new SectionDouble() { Direction = SectionType.LeftRight },
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

        private static Popup OpenedPopup = null;
        private void OpenPopup(Popup p)
        {
            if (OpenedPopup is not null)
                OpenedPopup.IsOpen = false;
            p.VerticalOffset = 80;
            p.IsOpen = true;
            OpenedPopup = p;
        }

    }

    internal class CreateButton
    {
        public CreateButton(Element el)
        {
            CmdAdd = new Command(Add, CanAdd);
            CmdInsert = new Command(Insert);
            Element = el;
            TwoRowsOnly = el is IDoubleElement;
        }
        public CreateButton(Element el, string image)
        {
            Image = image;
            CmdAdd = new Command(Add, CanAdd);
            CmdInsert = new Command(Insert);
            Element = el;
            TwoRowsOnly = el is IDoubleElement;
        }

        public Element Element { get; set; }

        public string Image { get; init; }

        public bool TwoRowsOnly { get; init; }

        public Command CmdAdd { get; init; } = new Command();
        public Command CmdInsert { get; init; } = new Command();

        private bool CanAdd()
        {
            var grid = ProjectVM.Current.Grid;
            var els = ProjectVM.Current.Grid.Elements;
            var sel = ProjectVM.Current.Grid.Selected;
            if (grid.Index < 0 || sel is null) return false;
            Debug.WriteLine($"Проверяю {Element.Name}");
            if (grid.RowNumber == Rows.Двухярусный)
            {
                // Проверка на направление вентилятора
                if (Element is Fan fan)
                {
                    var row = grid.Index < 10 ? MainRow.Верхний : MainRow.Нижний;
                    var expt = ProjectVM.Current.ProjectInfo.View.FlowRow == row;
                    if (fan.Direction.ToString().StartsWith("Left") != expt)
                        return false;
                }
                //Проверка на совместимость размеров
                if (Element is IDoubleElement)
                {
                    if (!(sel is IDoubleElement))
                    {
                        (int top, int bot) = grid.IndexTopBottom(grid.Index);
                        if (els[top].Name != "" || els[bot].Name != "")
                            return false;
                    }
                }
                else
                    if (sel is IDoubleElement)
                    return false;
            }
            //Проверка на положение клапана
            if (Element is Valve)
            {
                int start = grid.Index < 10 ? 0 : 10;
                for (int i = start; i < grid.Index; i++)
                {
                    if (els[i].Name != "")
                        return false;
                }

            }



            return true;

        }
        // Добавляет элемент
        private void Add()
        {
            ProjectVM.Current.Grid.AddElement(Element);
        }
        private void Insert()
        {
            ProjectVM.Current.Grid.InsertElement(Element);
        }
    }
}