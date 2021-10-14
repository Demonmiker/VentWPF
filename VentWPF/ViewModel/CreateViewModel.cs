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
                new("Нагреватели", "Heaters/Heaters.png",
                new()
                {
                    new() { Element = new Heater_Water() }
                }
                )
            };
        }

        public List<CreateMenu> Menus { get; set; }
    }

    internal class CreateMenu
    {
        public CreateMenu(string name, string image, List<CreateButton> elements)
        {
            Name = name;
            Image = Path.GetFullPath($"Assets/Images/{image}");
            Elements = elements;
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
        public CreateButton()
        {
            CmdAdd = new Command<object>((x) => Add());
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