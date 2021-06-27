using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VentWPF.ViewModel
{
    class ImageCollection
    {
        public string Empty { get; set; } = Path.GetFullPath("Assets/Images/Empty.png");

        public string Valves { get; set; } = Path.GetFullPath("Assets/Images/Valves/Valves.png");

        public string Heaters { get; init; } = Path.GetFullPath("Assets/Images/Heaters/Heaters.png");

        public string Coolers { get; set; } = Path.GetFullPath("Assets/Images/Coolers/Coolers.png");

        public string Muffers { get; init; } = Path.GetFullPath("Assets/Images/Mufflers/Mufflers.png");

        public string Filters { get; set; } = Path.GetFullPath("Assets/Images/Filters/Filters.png");

        public string Sections { get; set; } = Path.GetFullPath("Assets/Images/Sections/Sections.png");

        public string Humidifiers { get; set; } = Path.GetFullPath("Assets/Images/Humidifiers/Humidifiers.png");

        public string Fans_C { get; set; } = Path.GetFullPath("Assets/Images/Fans/Fan_C.png");

        public string Fans_P { get; set; } = Path.GetFullPath("Assets/Images/Fans/Fan_P.png");

        public string Fans_K3G { get; set; } = Path.GetFullPath("Assets/Images/Fans/Fan_K3G.png");

    }
}
