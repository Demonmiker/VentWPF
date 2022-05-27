#nullable disable

using PropertyTools.DataAnnotations;

namespace VentWPF
{
    public partial class Привода
    {
        [DisplayName("Тип привода")]
        public string Привода1 { get; set; }

        [DisplayName("Момент Нм")]
        public double? МоментНМ { get; set; }

        [DisplayName("Оборудование")]
        public string Оборудование { get; set; }

        [Browsable(false)]
        public string Stervo => Оборудование;

        public double? Цена { get; set; }

        public double? ЦенаЭксперт { get; set; }

        public string ПриводаДляКж { get; set; }
    }
}