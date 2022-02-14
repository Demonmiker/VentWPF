using Newtonsoft.Json;
using PropertyChanged;
using PropertyTools.DataAnnotations;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Data;
using System.Windows.Documents;
using VentWPF.Tools;
using VentWPF.ViewModel.Elements;
using static VentWPF.ViewModel.Strings;

namespace VentWPF.ViewModel
{
    /// <summary>
    /// Базовый класс элемента вентиляции
    /// </summary>
    internal class Element : ValidViewModel
    {
        public Element()
        {
            CmdUpdateQuery = new Command<object>((x) => UpdateQuery());
        }

        /// <summary>
        /// Тип модели реализации класса
        /// </summary>
        [Browsable(false)]
        public Type DeviceType { get; protected set; }

        private float pressureDrop = 0;

        protected static ProjectInfoVM ProjectInfo { get; set; } = ProjectVM.Current?.ProjectInfo;
        protected static ProjectVM Project { get; set; } = ProjectVM.Current;

        /// <summary>
        /// Название элемента системы вентиляции
        /// </summary>
        [Browsable(false)]
        [DependsOn("DeviceData")]
        public virtual string Name => "";

        /// <summary>
        /// Определяет нужно ли показывать Мощность пользователю
        /// </summary>
        [Browsable(false)]
        public bool ShowPR { get; init; } = false;

        [Category(Data)]
        [VisibleBy(nameof(ShowPR))]
        [SortIndex(-3)]
        [DisplayName("Производительность")]
        public virtual float Performance { get; set; } = ProjectInfo.VFlow;

        /// <summary>
        /// Падение давления
        /// </summary>
        [Category(Info)]
        [VisibleBy("ShowPD")]
        [SortIndex(-2)]
        [Optional("ManualPD")]
        [DisplayName("Падение давления")]
        [FormatString(fkPa)]
        public virtual float PressureDrop
        {
            get => !ManualPD ? (pressureDrop = GeneratedPressureDrop) : pressureDrop;
            set => pressureDrop = value;
        }

        /// <summary>
        /// Определяет вводится ли Падение давления вручную
        /// </summary>
        [VisibleBy("ShowPD")]
        [Browsable(false)]
        public bool ManualPD { get; set; } = false;

        /// <summary>
        /// Индекс выбранной модели в коллекции запроса
        /// </summary>
        [Browsable(false)]
        public int DeviceIndex { get; set; } = -1;

        /// <summary>
        /// Информация о выбраной модели
        /// </summary>
        [Browsable(false)]
        public object DeviceData { get; set; } = null;

        /// <summary>
        /// Содержит данные о форматировании этого элемента @@warn Можно убрать
        /// </summary>
        ///

        // TODO можно везде вынести
        [Browsable(false)]
        [JsonIgnore]
        public Dictionary<string, IValueConverter> Format => Conditions.Get(this.GetType());

        /// <summary>
        /// Запрос моделей для этого элемента
        /// </summary>
        [Browsable(false)]
        [JsonIgnore]
        public Query Query { get; set; }

        /// <summary>
        /// Определяет нужно ли показывать Падения давления пользователю
        /// </summary>
        [Browsable(false)]
        protected bool ShowPD { get; init; } = false;

        /// <summary>
        /// Свойство для получения Падения давления по формуле
        /// </summary>
        [Browsable(false)]
        protected virtual float GeneratedPressureDrop => 0;

        /// <summary>
        /// Скрытое поле для свойства InfoTable (для кэширования)
        /// </summary>
        private Table _InfoTable = null;

        /// <summary>
        /// Свойство содержащее информацию о элементе в виде таблицы
        /// </summary>
        [Browsable(false)]
        public Table InfoTable
        {
            get
            {
                if (_InfoTable is null)
                    _InfoTable = GetTable(2, true);
                return _InfoTable;
            }
        }

        /// <summary>
        /// Свойство с изображением этого элемента в конструкторе
        /// </summary>
        [Browsable(false)]
        [DependsOn(nameof(SubType))]
        public virtual string Image => ImagePath("_Menu/Empty");

        [Browsable(false)]
        [DependsOn(nameof(SubType))]
        public virtual string SchemeImage => Image.Replace("Icons", "Scheme");

        protected string ImagePath(string path) // пример Heaters/Electric
        {
            return Path.GetFullPath("Assets/Images/Icons/" + path + ".png");
        }

        /// <summary>
        /// Свойство под типа элемента
        /// </summary>
        [Browsable(false)]
        public int SubType { get; set; } = 0;

        /// <summary>
        /// Лист для определение полей информации а также их положения
        /// </summary>
        [Browsable(false)]
        public virtual List<string> InfoProperties => new() { };

        /// <summary>
        /// Метод генерирующий таблицу для вывода в документ
        /// </summary>
        /// <param name="columns">Сколько в таблице будет столбцов</param>
        /// <param name="isDynamic">Будет ли информация в таблице обновлятся автоматически</param>
        /// <returns>Таблицу с данными</returns>
        public Table GetTable(int columns = 1, bool isDynamic = false)
        {
            List<TableRow> rowList = new();
            TableRow header = new();
            header.Cells.Add(new(new Paragraph(new Run(this.Name)) { FontSize = 20 ,TextAlignment=TextAlignment.Left}));
            rowList.Add(header);
            List<InfoLine> infos = InfoLine.GenerateInfoLines(this, DeviceType, InfoProperties).ToList();
            while (infos.Count % columns > 0)
                infos.Add(null);
            int rows = infos.Count / columns;
            for (int i = 0; i < rows; i++)
            {
                TableRow row = new();
                for (int j = 0; j < columns; j++)
                {
                    Paragraph par = infos?[i + j * rows]?.ToParagraph(isDynamic);
                    if (par is not null)
                    {
                        par.FontSize = 14;
                        row.Cells.Add(new TableCell(par));
                    }
                }
                rowList.Add(row);
            }
            Table table = new();
            for (int i = 0; i < columns; i++)
                table.Columns.Add(new TableColumn() { Width = new System.Windows.GridLength(600 / columns) });
            if (ProjectVM.Current.Grid.Selected is not null)
            {
                TableRowGroup tg = new();
                foreach (TableRow item in rowList)
                    tg.Rows.Add(item);
                table.RowGroups.Add(tg);
            }
            return table;
        }

        /// <summary>
        /// Обозначает что элемент можем быть только в установке с двумя рядами
        /// </summary>
        public bool TwoRowsOnly { get; init; } = false;

        public static T GetInstance<T>(T o)
        {
            return (T)Activator.CreateInstance(o.GetType());
        }

        protected override string OnValidation()
        {
            return (DeviceType is not null && DeviceData is null ? "Не выбрана модель устройства\n" : "") +
                          (!CorrectSize ? "Не подходит по размерам" : "");
        }

        [Browsable(false)]
        public virtual int Length => 0;

        [Browsable(false)]
        [DependsOn(nameof(DeviceData))]
        public virtual int Width => 0;

        [Browsable(false)]
        [DependsOn(nameof(DeviceData))]
        public virtual int Height => 0;

        [Browsable(false)]
        public bool CorrectSize => Width <= ProjectInfo.Width && Height <= ProjectInfo.Height;

        [Browsable(false)]
        public Command<object> CmdUpdateQuery { get; init; }

        public virtual void UpdateQuery()
        {
        }
    }
}