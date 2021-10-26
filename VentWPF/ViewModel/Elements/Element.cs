using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VentWPF.Model;

namespace VentWPF.ViewModel
{
    
    public  class Element
    {
        public const string c1 = "Данные";
        public const string c2 = "Информация";

        [Browsable(false)]
        public string Name { get; protected set; } = "";

        
        protected string image = "Empty.png";

        [Browsable(false)]
        public string Image => Path.GetFullPath("Assets/Images/"+image);

        public static Project project { get; set; } = new();

        



    }
}
