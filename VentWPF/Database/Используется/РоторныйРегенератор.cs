using PropertyTools.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using VentWPF.ViewModel;

#nullable disable

namespace VentWPF
{
    public partial class РоторныйРегенератор
    {
        public int? _ { get; set; }

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

        [DisplayName("Высота")]
        public string Высота { get; set; }

        public string Длина1 { get; set; }

        public string Длина2 { get; set; }

        [DisplayName("Цена")]
        public string Цена { get; set; }        

        public string Код1с { get; set; }
    }
}