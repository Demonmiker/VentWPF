using PropertyTools.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using VentWPF.ViewModel;

#nullable disable

namespace VentWPF
{
    public partial class ФреонХолод
    {
        [DisplayName("Типоряд")]
        public string Типоряд { get; set; }

        [DisplayName("L возд")]
        [FormatString("{0:00} м³/ч")]
        public double? LВозд { get; set; }

        [NotMapped]
        [DisplayName("Скорость")]
        [FormatString("{0:0.00} м/с")]
        public double? Скорость => 278 * ProjectVM.Current.ProjectInfo.Settings.VFlow / (АШиринаЖс * ВВысотаЖс);

        [DisplayName("Мощность")]
        [FormatString("{0:0.00} kВт")]
        public double? NКвт { get; set; }

        [DisplayName("Ширина г.")]
        [FormatString("{0} мм")]
        public double? ШиринаГабарит { get; set; }

        [DisplayName("Высота г.")]
        [FormatString("{0} мм")]
        public double? ВысотаГабарит { get; set; }

        [DisplayName("Присоединительные размеры патрубков")]
        public string ДПрисоединения { get; set; }
        
        [DisplayName("Ширина Жс")]
        [FormatString("{0} мм")]
        public double? АШиринаЖс { get; set; }

        [DisplayName("Высота Жс")]
        [FormatString("{0} мм")]
        public double? ВВысотаЖс { get; set; }

        [DisplayName("Цена")]
        [FormatString("{0} €")]
        public double? Цена { get; set; }

        public int Код { get; set; }
                
        public double? КолВоКонтуров { get; set; }

        public string Код1с { get; set; }
    }
}