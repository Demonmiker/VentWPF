using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VentWPF.Model;

namespace VentWPF.ViewModel
{

    public class Element : BaseViewModel
    {
        public const string c1 = "Данные";
        public const string c2 = "Информация";

        [Browsable(false)]
        public string Name { get; protected set; } = "";

        
        protected string image = "Empty.png";

        [Browsable(false)]
        public string Image => Path.GetFullPath("Assets/Images/"+image);

        public static ProjectVM project { get; set; } = new();

        public virtual float PressureDrop => 0;

        public virtual float Performance { get; set; }

        [Browsable(false)]
        public ICollection Query { get; init; }  

    }
}
