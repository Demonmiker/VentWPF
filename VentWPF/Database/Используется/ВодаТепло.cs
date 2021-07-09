using PropertyTools.DataAnnotations; using static VentWPF.ViewModel.Strings;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using VentWPF.Model;
using VentWPF.Tools;
using VentWPF.ViewModel;

#nullable disable

namespace VentWPF
{
    public partial class ВодаТепло
    {
        [DisplayName("Типоряд")]
        public string Типоряд { get; set; }

        [DisplayName("L возд")]
        [FormatString("{0:00} м³/ч")]
        public double? LВозд { get; set; }

        [NotMapped]
        [DisplayName(null)]
        [FormatString("{0:0.00} м/с")]
        public double? Скорость => 278 * ProjectInfoVM.Instance.VFlow / (ШиринаЖс * ВысотаЖс);

        [DisplayName("Мощность")]
        [FormatString("{0:0.00} kВт")]
        public double? NКвт { get; set; }

        [DisplayName("Ширина г.")]
        [FormatString("{0} мм")]
        public double? ШиринаГабарит { get; set; }
        
        [DisplayName("Высота г.")]
        [FormatString("{0} мм")]
        public double? ВысотаГабарит { get; set; }

        [DisplayName("ДУ")]
        public string ДПрисоединения { get; set; }

        [DisplayName("Ширина Жс")]
        [FormatString("{0} мм")]
        public double? ШиринаЖс { get; set; }

        [DisplayName("Высота Жс")]
        [FormatString("{0} мм")]
        public double? ВысотаЖс { get; set; }

        [DisplayName("Цена")]
        [FormatString("{0} €")]
        public double? Цена { get; set; }
     

        public double? Код { get; set; }
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
