using PropertyTools.DataAnnotations;
using System;
using System.Collections.Generic;

#nullable disable

namespace VentWPF
{
    public partial class Tэнры
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
