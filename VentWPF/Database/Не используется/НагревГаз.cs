using System;
using System.Collections.Generic;

#nullable disable

namespace VentWPF
{
    public partial class НагревГаз
    {
        public int Код { get; set; }
        public string _ { get; set; }
        public double? Ступенчатая { get; set; }
        public double? Прогрессивная { get; set; }
        public double? Модулирующая { get; set; }
    }
}
