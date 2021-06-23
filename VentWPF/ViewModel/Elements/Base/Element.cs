using System.Collections;
using System.ComponentModel;
using System.IO;
using VentWPF.Model;

namespace VentWPF.ViewModel
{
    public class Element : BaseViewModel
    {
        public const string c1 = "Данные";
        public const string c2 = "Информация";

        protected string image = "Empty.png";

        public static ProjectVM project { get; set; } = new();

        [Browsable(false)]
        public string Image => Path.GetFullPath("Assets/Images/" + image);

        [Browsable(false)]
        public string Name { get; protected set; } = "";

        public virtual float Performance { get; set; }
        public virtual float PressureDrop => 0;

        [Browsable(false)]
        public ICollection Query { get; init; }
    }
}