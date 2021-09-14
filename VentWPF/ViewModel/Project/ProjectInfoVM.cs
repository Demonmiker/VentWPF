using PropertyChanged;
using PropertyTools.DataAnnotations;
using System;
using System.Collections.ObjectModel;
using VentWPF.Model;
using static VentWPF.ViewModel.Strings;
using valid = VentWPF.Tools;

namespace VentWPF.ViewModel
{
    public class ProjectInfoVM : ValidViewModel
    {
        #region Properties

        [Category("Заказ|")]
        [DisplayName("Дата")]
        [FormatString(fDate)]
        public DateTime Date { get; set; } = DateTime.Now;

        [Category("Заказ|")]
        [DisplayName("Исполнитель")]
        [valid.Required]
        public string Worker { get; set; }

        [Category("Заказ|")]
        [DisplayName("Заказ")]
        [valid.Required]
        public string OrderName { get; set; }

        [Category("Заказ|")]
        [DisplayName("Обозначение установки")]
        [valid.Required]
        public string BuildName { get; set; }

        [Category("Заказ|")]
        [DisplayName("Заказчик")]
        [valid.Required]
        public string Customer { get; set; }

        [Category("Заказ|")]
        [DisplayName("Объект")]
        [valid.Required]
        public string Object { get; set; }

        [Category("Заказ|")]
        [DisplayName("Номер")]
        //[valid.Phone]
        public string Number { get; set; }

        [Category("Настройки|")]
        [DisplayName("Объём притока")]
        [FormatString(fm3)]
        public int VFlow { get; set; } = 6000;

        [Category("Настройки|")]
        [DisplayName("Сопр. сети притока")]
        [FormatString(fPa)]
        public float PFlow { get; set; } = 0;

        [Category("Настройки|")]
        [EnableBy("Rows", Rows.Двухярусный)]
        [DisplayName("Объём вытяжки/резерва")]
        [FormatString(fm3)]
        public int VReserv { get; set; } = 6000;

        [Category("Настройки|")]
        [EnableBy("Rows", Rows.Двухярусный)]
        [DisplayName("Сопр. сети вытяжки")]
        [FormatString(fPa)]
        public float PReserv { get; set; } = 0;

        [Category("Настройки|")]
        [DisplayName("Кол-во блоков")]
        [FormatString(fc)]
        public int Blocks { get; set; } = 3;

        [DisplayName("Ширина")]
        [FormatString(fmm)]
        public int Width { get; set; } = 500;

        [DisplayName("Высота")]
        [FormatString(fmm)]
        public int Height { get; set; } = 600;

        //+Толщина панели ?? @@stop

        [Category("Настройки|")]
        [DisplayName("Влажность")]
        [FormatString(fper)]
        public int Humid { get; set; } = 85;

        [Category("Вид|")]
        [DisplayName("Кол-во рядов")]
        [FormatString(fkPa)]
        public Rows Rows { get; set; } = Rows.Двухярусный;

        [Category("Вид|")]
        [DisplayName("Исполнение")]
        public Realization Realization { get; set; } = Realization.ТРЕНД;

        [DependsOn("Realization")]
        [Category("Вид|")]
        [DisplayName("Типоряд не сделано")]
        public ObservableCollection<string> Types
            => new ObservableCollection<string>() { $"{Realization}1", $"{Realization}2" };

        [Category("Вид|")]
        [DisplayName("Сторона обслуживания")]
        public Maintenance Maintenance { get; set; } = Maintenance.Справа;

        [Category("Вид|")]
        [DisplayName("Медицинское")]
        public bool Medic { get; set; } = false;

        [Category("Вид|")]
        [DisplayName("Наружное")]
        public bool Out { get; set; } = false;

        [Category("Вид|")]
        [DisplayName("Взрывозащ.")]
        public bool ExpProof { get; set; } = false;

        [Category("Вид|")]
        [DisplayName("Клапан")]
        public ValvePos Valve { get; set; } = ValvePos.Снаружи;

        //Непонятно @@info
        [Browsable(false)]
        public float PressOut { get; set; } = 100;

        //Непонятно @@info
        [Browsable(false)]
        public int Temp { get; set; } = -30;

        #endregion
    }
}