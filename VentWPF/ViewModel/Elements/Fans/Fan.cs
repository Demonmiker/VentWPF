using System.ComponentModel;
using System.IO;

namespace VentWPF.ViewModel
{
    internal class Fan : Element
    {
        public Fan()
        {
            Name = "Вентилятор";
        }

        //[Browsable(false)]
        public Fan_Direction Direction
        {
            get => (Fan_Direction)SubType;
            set => SubType = (int)value;
        }

        public override string Image => Path.GetFullPath($"Assets/Images/Fans/Directions/{Direction}.png");

        //
        //FanData fd;

        //[DisplayName("Элемент:")][Category(c2), PropertyOrder(3)]
        //public string Id => fd?.ARTICLE_NO;
    }
}