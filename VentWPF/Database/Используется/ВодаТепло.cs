using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace VentWPF
{
    public partial class ВодаТепло
    {
        public string Типоряд { get; set; }
        [NotMapped]
        public double Скорость => 5;
        public double? LВозд { get; set; }
        public double? ШиринаГабарит { get; set; }
        public double? ВысотаГабарит { get; set; }
        public double? ШиринаЖс { get; set; }
        public double? ВысотаЖс { get; set; }
        public double? Цена { get; set; }
       
        public double? Код { get; set; }
        public double? NКвт { get; set; }
        public string ДПрисоединения { get; set; }
        
        public string DPConst { get; set; }
        public string VDP0 { get; set; }
        public string VDP1 { get; set; }
        public string VDP2 { get; set; }
        public string VDP3 { get; set; }
        public string VDP4 { get; set; }
        public string VDP5 { get; set; }
        public string Код1с { get; set; }
    }
}
