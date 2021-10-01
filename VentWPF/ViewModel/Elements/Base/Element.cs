using Newtonsoft.Json;
using PropertyChanged;
using PropertyTools.DataAnnotations;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Data;
using System.Windows.Documents;
using VentWPF.ViewModel.Elements;
using static VentWPF.ViewModel.Strings;

namespace VentWPF.ViewModel
{
    /// <summary>
    /// Базовый класс элемента вентиляции
    /// </summary>
    internal class Element : ValidViewModel
    {

        /// <summary>
        /// Тип модели реализации класса
        /// </summary>
        protected Type DeviceType = null;

        private float pressureDrop = 0;

        /// <summary>
        /// Ссылка на Проект которому принадлежит элемент
        /// </summary>
        public static ProjectInfoVM Project { get; set; } = ProjectVM.Current?.ProjectInfo;

        /// <summary>
        /// Название элемента системы вентиляции
        /// </summary>
        [Browsable(false)]
        [DependsOn("DeviceIndex")]
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
        public virtual float Performance { get; set; } = Project.VFlow;

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
        public int DeviceIndex { get; set; }

        /// <summary>
        /// Информация о выбраной модели
        /// </summary>
        [Browsable(false)]
        public object DeviceData => DeviceIndex >= 0 ? Query.Result[DeviceIndex] : null;

        /// <summary>
        /// Содержит данные о форматировании этого элемента @@warn Можно убрать
        /// </summary>
        [Browsable(false)]
        [JsonIgnore]
        public Dictionary<string, IValueConverter> Format => Conditions.Get(this.GetType());

        /// <summary>
        /// Запрос моделей для этого элемента
        /// </summary>
        [Browsable(false)]
        [JsonIgnore]
        public Query Query { get; init; }

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
        /// Поле с изображением по умолчанию
        /// </summary>
        protected string image = "Empty.png";

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
        [DependsOn("SubType")]
        public virtual string Image => Path.GetFullPath("Assets/Images/" + image);

        /// <summary>
        /// Свойство под типа элемента
        /// </summary>
        [Browsable(false)]
        public int SubType { get; set; } = 0;

        /// <summary>
        /// Лист для определение полей информации а также их положения
        /// </summary>
        protected virtual List<string> InfoProperties => new() { };

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
            header.Cells.Add(new(new Paragraph(new Run(this.Name)) { FontSize = 20 }));
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
                        row.Cells.Add(new TableCell(par));
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

        public static T GetInstance<T>(T o) => (T)Activator.CreateInstance(o.GetType());

        protected override string OnValidation()
            => DeviceType != null && DeviceData == null ? "Не выбрана модель устройства" : "";

    }
}