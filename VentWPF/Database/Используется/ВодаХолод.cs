using System;
using System.Collections.Generic;

#nullable disable

namespace VentWPF
{
    public partial class ВодаХолод
    {
        public int Код { get; set; }
        public double? LВозд { get; set; }
        public string Типоряд { get; set; }
        public double? АШиринаЖс { get; set; }
        public double? ВВысотаЖс { get; set; }
        public double? ШиринаГабарит { get; set; }
        public double? ВысотаГабарит { get; set; }
        public double? NКвт { get; set; }
        public string ДПрисоединения { get; set; }
        public double? Цена { get; set; }
        public string Код1с { get; set; }
    }
}
