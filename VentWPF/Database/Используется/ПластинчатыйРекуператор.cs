using PropertyTools.DataAnnotations;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using VentWPF.ViewModel;

#nullable disable

namespace VentWPF
{
    public partial class ПластинчатыйРекуператор
    {
        public int? _ { get; set; }

        [DisplayName("Исполнение")]
        public string Исполнение { get; set; }

        [DisplayName("Маркировка")]
        public string Маркировка { get; set; }

        [DisplayName("Vmax")]
        [FormatString("{0:00} м³/ч")]
        public string VМ3Ч { get; set; }

        [NotMapped]
        [DisplayName("Скорость")]
        [FormatString("{0:0.00} м/с")]
        public double? Скорость => 0f;

        [DisplayName("LГрани")]
        [FormatString("{0:00} мм")]
        public string LГраниМм { get; set; }

        [DisplayName("LПакета")]
        [FormatString("{0:00} мм")]
        public string LПакетаМм { get; set; }

        [DisplayName("Высота")]
        public string Высота { get; set; }

        [NotMapped]
        [Browsable(false)]
        public double Height => Convert.ToDouble(Высота);

        [DisplayName("Длина")]
        public string Длина { get; set; }

        [NotMapped]
        [Browsable(false)]
        public double With => Convert.ToDouble(Длина);

        [DisplayName("Цена")]
        public string Цена { get; set; }

        public string Код1с { get; set; }
    }
}