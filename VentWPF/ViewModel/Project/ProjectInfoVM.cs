using PropertyChanged;
using PropertyTools.DataAnnotations;
using System;
using VentWPF.Model;
using static VentWPF.ViewModel.Strings;
using valid = VentWPF.Tools;

namespace VentWPF.ViewModel
{
    internal class Order : ValidViewModel
    {

        [Browsable(false)]
        public ProjectInfoVM Parent { get; private set; } //Нельзя открывать будет цикл

        public void InitParent(ProjectInfoVM parent)
        {
            Parent = parent;
        }

        /// <summary>
        /// Заказ
        /// </summary>
        [Category("Заказ")]
        [DisplayName("Заказ")]
        [valid.Required]
        public string OrderName { get; set; }

        /// <summary>
        /// Дата начала проекта
        /// </summary>
        // TODO: Формат вводишь mm/dd/yyyy а получаешь dd/mm/yyyy Конфузит?!
        [Category("Заказ")]
        [DisplayName("Дата")]
        [FormatString(fDate)]
        public DateTime Date { get; set; } = DateTime.Now;

        /// <summary>
        /// Исполнитель
        /// </summary>
        [Category("Заказ")]
        [DisplayName("Исполнитель")]
        [valid.Required]
        public string Worker { get; set; }


        /// <summary>
        /// Обозначение установки
        /// </summary>
        [Category("Заказ")]
        [DisplayName("Обозначение установки")]
        [valid.Required]
        public string BuildName { get; set; }

        /// <summary>
        /// Заказчик
        /// </summary>
        [Category("Заказ")]
        [DisplayName("Заказчик")]
        [valid.Required]
        public string Customer { get; set; }

        /// <summary>
        /// Объект
        /// </summary>
        [Category("Заказ")]
        [DisplayName("Объект")]
        [valid.Required]
        public string Object { get; set; }

        /// <summary>
        /// Номер телефона заказчика
        /// </summary>
        [Category("Заказ")]
        [DisplayName("Номер")]
        public string Number { get; set; }
    }

    internal class Settings : ValidViewModel
    {
        [Browsable (false)]
        public Rows Rows { get; set; }

        [Browsable(false)]
        public ProjectInfoVM Parent { get; private set; } //Нельзя открывать будет цикл

        public void InitParent(ProjectInfoVM parent)
        {
            Parent = parent;
        }
        /// <summary>
        /// Объем притока
        /// </summary>
        [Category("Настройки")]
        [DisplayName("Объём притока")]
        [FormatString(fm3)]
        public int VFlow
        {
            get => vFlow;
            set
            {
                vFlow = value;
                Parent.View.SizeType = value switch
                {
                    < 1200 => SizeType.ТипоРазмер1,
                    < 2200 => SizeType.ТипоРазмер2,
                    < 3200 => SizeType.ТипоРазмер3,
                    < 4200 => SizeType.ТипоРазмер4,
                    < 5200 => SizeType.ТипоРазмер5,
                    < 6500 => SizeType.ТипоРазмер6,
                    < 7200 => SizeType.ТипоРазмер8,
                    < 9700 => SizeType.ТипоРазмер10,
                    < 12000 => SizeType.ТипоРазмер12,
                    < 15000 => SizeType.ТипоРазмер16,
                    < 20300 => SizeType.ТипоРазмер20,
                    < 25000 => SizeType.ТипоРазмер25,
                    < 30000 => SizeType.ТипоРазмер30,
                    < 40000 => SizeType.ТипоРазмер40,
                    < 50000 => SizeType.ТипоРазмер50,
                    < 60000 => SizeType.ТипоРазмер60,
                    < 70000 => SizeType.ТипоРазмер80,
                    _ => SizeType.ТипоРазмер100,
                };
            }
        }

        private int vFlow = 6000;


        /// <summary>
        /// Сопротивление сети притока
        /// </summary>
        [Category("Настройки")]
        [DisplayName("Сопр. сети притока")]
        [FormatString(fPa)]
        public float PFlow { get; set; } = 0;

        /// <summary>
        /// Объем вытяжки/резерва
        /// </summary>
        [Category("Настройки")]
        [VisibleBy(nameof(Rows), Rows.Двухярусный)]
        [DisplayName("Объём вытяжки/резерва")]
        [FormatString(fm3)]
        public int VReserv { get; set; } = 6000;

        /// <summary>
        /// Сопротивление сети вытяжки
        /// </summary>
        [Category("Настройки")]
        [VisibleBy(nameof(Rows), Rows.Двухярусный)]
        [DisplayName("Сопр. сети вытяжки")]
        [FormatString(fPa)]
        public float PReserv { get; set; } = 0;

        /// <summary>
        /// Количество блоков
        /// </summary>
        [Category("Настройки")]
        [DisplayName("Кол-во блоков")]
        [FormatString(fc)]
        public int Blocks { get; set; } = 3;

        /// <summary>
        /// Ширина установки
        /// </summary>
        [DisplayName("Ширина")]
        [FormatString(fmm)]
        public int Width { get; set; } = 1050;

        /// <summary>
        /// Высота установки
        /// </summary>
        [DisplayName("Высота")]
        [FormatString(fmm)]
        public int Height { get; set; } = 700;

        [Category("Настройки")]
        [DisplayName("Толщина панели")]
        [FormatString(fmm)]
        public int PanelWidth { get; set; } = 45;

        /// <summary>
        /// Влажность
        /// </summary>
        [Category("Настройки")]
        [DisplayName("Влажность")]
        [FormatString(fper)]
        public int Humid { get; set; } = 85;

        [Browsable(false)]
        [DisplayName("Атмосферное давление")]
        public float PressOut { get; set; } = 95;


        [Browsable(false)]
        public int Temp { get; set; } = -30;
    }

    internal class View : ValidViewModel
    {
        public void InitParent(ProjectInfoVM parent)
        {
            Parent = parent;
        }

        [Browsable(false)]
        public ProjectInfoVM Parent { get; private set; } //Нельзя открывать будет цикл

        [Category("Вид")]
        [DisplayName("Кол-во рядов")]
        public Rows Rows
        { 
            get => rows; 
            set 
            {
                if(Parent is not null)
                    Parent.Settings.Rows = value;
                rows = value;
                ProjectVM.Current.Grid.Init(value); 
            } 
        }

        /// <summary>
        /// Количество рядов
        /// </summary>
        private Rows rows = Rows.Одноярусный;

        /// <summary>
        /// Реализация
        /// </summary>
        [Category("Вид")]
        [DisplayName("Ярус притока")]
        [VisibleBy(nameof(Rows),Rows.Двухярусный)]
        public MainRow FlowRow { get; set; } = MainRow.Верхний;

        [Category("Вид")]
        [DisplayName("Типоразмер")]
        public SizeType SizeType
        {
            get => sizeType;
            set
            {
                sizeType = value;
                (Parent.Settings.Width,Parent.Settings.Height) = value.GetSize();
            }
        }

        private SizeType sizeType = SizeType.ТипоРазмер6;

        /// <summary>
        /// Сторона обслуживания
        /// </summary>
        [Category("Вид")]
        [DisplayName("Сторона обслуживания")]
        public Maintenance Maintenance { get; set; } = Maintenance.Справа;

        /// <summary>
        /// Медицинское
        /// </summary>
        [Category("Вид")]
        [DisplayName("Медицинское")]
        public bool Medic { get; set; } = false;

        /// <summary>
        /// Наружное
        /// </summary>
        [Category("Вид")]
        [DisplayName("Наружное")]
        public bool Out { get; set; } = false;

        /// <summary>
        /// Взрывозащизённое
        /// </summary>
        [Category("Вид")]
        [DisplayName("Взрывозащ.")]
        public bool ExpProof { get; set; } = false;

        /// <summary>
        /// Клапан Снаружи/Внутри
        /// </summary>
        [Category("Вид")]
        [DisplayName("Клапан")]
        public ValvePos Valve { get; set; } = ValvePos.Снаружи;

    }

    /// <summary>
    /// Информация о проекте
    /// </summary>
    internal class ProjectInfoVM : ValidViewModel
    {

        public ProjectInfoVM()
        {
            Order = new(); Order.InitParent(this);
            Settings = new(); Settings.InitParent(this);
            View = new(); View.InitParent(this);
        }

        public Order Order { get; set; }

        public Settings Settings { get; set; }

        public View View { get; set; }
    }
}