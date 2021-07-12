
using PropertyTools.DataAnnotations;
using System;
using System.Collections.Generic;

#nullable disable

namespace VentWPF
{
    public partial class Тэны
    {
        [DisplayName(null)]
        public string Типоряд { get; set; }

        [DisplayName(null)]
        public string Маркировка { get; set; }

        [DisplayName("Кол-во по ширине")]
        public string КолВоПоШирине { get; set; }

        public int? Код { get; set; }
        public string Код1с { get; set; }
    }
}
