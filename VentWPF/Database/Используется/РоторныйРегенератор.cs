using PropertyTools.DataAnnotations;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using VentWPF.ViewModel;

#nullable disable

namespace VentWPF
{
    public partial class РоторныйРегенератор
    {
        public int? _ { get; set; }

        [DisplayName("Исполнение")]
        public string Исполнение { get; set; }

        [DisplayName("Маркировка")]
        public string Маркировка { get; set; }

        [DisplayName("D Ротора")]
        public string DРотора { get; set; }

        [DisplayName("Vmax")]
        [FormatString("{0:00} м³/ч")]
        public string VМ3Ч { get; set; }        

        [DisplayName("N")]
        [FormatString("{0:00} КВт")]
        public string NКВт { get; set; }

        [DisplayName("Ширина")]
        public string Ширина { get; set; }

        [NotMapped]
        [Browsable(false)]
        public double With => Convert.ToDouble(Ширина);

        [DisplayName("Высота")]
        public string Высота { get; set; }

        [NotMapped]
        [Browsable(false)]
        public double Heinht => Convert.ToDouble(Высота);

        public string Длина1 { get; set; }

        public string Длина2 { get; set; }

        [DisplayName("Цена")]
        public string Цена { get; set; }        

        public string Код1с { get; set; }
    }
}