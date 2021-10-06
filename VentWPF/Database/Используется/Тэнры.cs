using PropertyTools.DataAnnotations;

#nullable disable

namespace VentWPF
{
    public partial class Тэнры
    {
        [DisplayName(null)]
        public string Типоряд { get; set; }

        [DisplayName(null)]
        public string Маркировка { get; set; }

        [DisplayName(null)]
        [FormatString("{0:0.00} kВт")]
        public double? Мощность { get; set; }

        public int? Код { get; set; }

        public string Код1с { get; set; }
    }
}