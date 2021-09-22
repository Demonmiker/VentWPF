using PropertyChanged;
using PropertyTools.DataAnnotations;
using System;
using System.Collections.ObjectModel;
using VentWPF.Model;
using static VentWPF.ViewModel.Strings;
using valid = VentWPF.Tools;

namespace VentWPF.ViewModel
{
    /// <summary>
    /// Информация о проекте
    /// </summary>
    public class ProjectInfoVM : ValidViewModel
    {

        /// <summary>
        /// Дата начала проекта
        /// </summary>
        [Category("Заказ|")]
        [DisplayName("Дата")]
        [FormatString(fDate)]
        public DateTime Date { get; set; } = DateTime.Now;

        /// <summary>
        /// Исполнитель
        /// </summary>
        [Category("Заказ|")]
        [DisplayName("Исполнитель")]
        [valid.Required]
        public string Worker { get; set; }

        /// <summary>
        /// Заказ
        /// </summary>
        [Category("Заказ|")]
        [DisplayName("Заказ")]
        [valid.Required]
        public string OrderName { get; set; }

        /// <summary>
        /// Обозначение установки
        /// </summary>
        [Category("Заказ|")]
        [DisplayName("Обозначение установки")]
        [valid.Required]
        public string BuildName { get; set; }

        /// <summary>
        /// Заказчик
        /// </summary>
        [Category("Заказ|")]
        [DisplayName("Заказчик")]
        [valid.Required]
        public string Customer { get; set; }

        /// <summary>
        /// Объект
        /// </summary>
        [Category("Заказ|")]
        [DisplayName("Объект")]
        [valid.Required]
        public string Object { get; set; }

        /// <summary>
        /// Номер телефона заказчика
        /// </summary>
        [Category("Заказ|")]
        [DisplayName("Номер")]
        //[valid.Phone]
        public string Number { get; set; }

        /// <summary>
        /// Объем притока
        /// </summary>
        [Category("Настройки|")]
        [DisplayName("Объём притока")]
        [FormatString(fm3)]
        public int VFlow { get; set; } = 6000;

        /// <summary>
        /// Сопротивление сети притока
        /// </summary>
        [Category("Настройки|")]
        [DisplayName("Сопр. сети притока")]
        [FormatString(fPa)]
        public float PFlow { get; set; } = 0;

        /// <summary>
        /// Объем вытяжки/резерва
        /// </summary>
        [Category("Настройки|")]
        [EnableBy("Rows", Rows.Двухярусный)]
        [DisplayName("Объём вытяжки/резерва")]
        [FormatString(fm3)]
        public int VReserv { get; set; } = 6000;

        /// <summary>
        /// Сопротивление сети вытяжки
        /// </summary>
        [Category("Настройки|")]
        [EnableBy("Rows", Rows.Двухярусный)]
        [DisplayName("Сопр. сети вытяжки")]
        [FormatString(fPa)]
        public float PReserv { get; set; } = 0;

        /// <summary>
        /// Количество блоков
        /// </summary>
        [Category("Настройки|")]
        [DisplayName("Кол-во блоков")]
        [FormatString(fc)]
        public int Blocks { get; set; } = 3;

        /// <summary>
        /// Ширина установки
        /// </summary>
        [DisplayName("Ширина")]
        [FormatString(fmm)]
        public int Width { get; set; } = 500;

        /// <summary>
        /// Высота установки
        /// </summary>
        [DisplayName("Высота")]
        [FormatString(fmm)]
        public int Height { get; set; } = 600;

        //+Толщина панели ?? @@stop

        /// <summary>
        /// Влажность
        /// </summary>
        [Category("Настройки|")]
        [DisplayName("Влажность")]
        [FormatString(fper)]
        public int Humid { get; set; } = 85;

        /// <summary>
        /// Количество рядов
        /// </summary>
        [Category("Вид|")]
        [DisplayName("Кол-во рядов")]
        [FormatString(fkPa)]
        public Rows Rows { get; set; } = Rows.Двухярусный;

        /// <summary>
        /// Реализация
        /// </summary>
        [Category("Вид|")]
        [DisplayName("Исполнение")]
        public Realization Realization { get; set; } = Realization.ТРЕНД;

        [DependsOn("Realization")]
        [Category("Вид|")]
        [DisplayName("Типоряд не сделано")]
        public ObservableCollection<string> Types
            => new ObservableCollection<string>() { $"{Realization}1", $"{Realization}2" };

        /// <summary>
        /// Сторона обслуживания
        /// </summary>
        [Category("Вид|")]
        [DisplayName("Сторона обслуживания")]
        public Maintenance Maintenance { get; set; } = Maintenance.Справа;

        /// <summary>
        /// Медицинское
        /// </summary>
        [Category("Вид|")]
        [DisplayName("Медицинское")]
        public bool Medic { get; set; } = false;

        /// <summary>
        /// Наружное
        /// </summary>
        [Category("Вид|")]
        [DisplayName("Наружное")]
        public bool Out { get; set; } = false;

        /// <summary>
        /// Взрывозащизённое
        /// </summary>
        [Category("Вид|")]
        [DisplayName("Взрывозащ.")]
        public bool ExpProof { get; set; } = false;

        /// <summary>
        /// Клапан Снаружи/Внутри
        /// </summary>
        [Category("Вид|")]
        [DisplayName("Клапан")]
        public ValvePos Valve { get; set; } = ValvePos.Снаружи;

        //Непонятно @@info
        [Browsable(false)]
        public float PressOut { get; set; } = 100;

        //Непонятно @@info
        [Browsable(false)]
        public int Temp { get; set; } = -30;

    }
}