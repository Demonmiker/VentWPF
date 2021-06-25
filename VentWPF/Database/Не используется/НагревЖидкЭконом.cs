using System;
using System.Collections.Generic;

#nullable disable

namespace VentWPF
{
    public partial class НагревЖидкЭконом
    {
        public int Код { get; set; }
        public string _ { get; set; }
        public double? С1ФНасосом { get; set; }
        public double? С3ФНасосомДо3КВт { get; set; }
        public double? С3ФНасосомДо75КВт { get; set; }
    }
}
