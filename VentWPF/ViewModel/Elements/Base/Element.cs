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
using valid = System.ComponentModel.DataAnnotations;

namespace VentWPF.ViewModel
{
    internal class Element : ValidViewModel
    {
        #region Properties

        public static ProjectInfoVM Project { get; set; } = ProjectVM.Current?.ProjectInfo;

        /// <summary>
        /// Наименование элемента системы вентиляции
        /// </summary>
        [Browsable(false)]
        [DependsOn("DeviceIndex")]
        public virtual string Name => "";

        #endregion

        #region Генерация документации

        [Browsable(false)]
        public List<TableRow> Rows => GetRows(columns: 2);

        protected virtual List<string> InfoProperties => new() { };

        protected List<TableRow> GetRows(int columns = 1)
        {
            List<TableRow> rowList = new();
            var header = new TableRow();
            header.Cells.Add(new(new Paragraph(new Run(this.Name)) { FontSize = 20 }));
            rowList.Add(header);
            var infos = InfoLine.GenerateInfoLines(this, DeviceType, InfoProperties).ToList();
            while (infos.Count % columns > 0)
                infos.Add(null);
            int rows = infos.Count / columns;
            for (int i = 0; i < rows; i++)
            {
                var row = new TableRow();
                for (int j = 0; j < columns; j++)
                {
                    var par = infos?[i + j * rows]?.ToParagraph();
                    if (par is not null)
                        row.Cells.Add(new TableCell(par));
                }
                rowList.Add(row);
            }
            return rowList;
        }

        #endregion Генерация документации

        #region Управление изображением

        protected string image = "Empty.png";

        [Browsable(false)]
        [DependsOn("SubType")]
        public virtual string Image => Path.GetFullPath("Assets/Images/" + image);

        [Browsable(false)]
        public int SubType { get; set; } = 0;

        #endregion Управление изображением

        #region Отображением полей

        [SortIndex(-1)]
        [Category(Debug)]
        [VisibleBy("ShowDebug")]
        public bool ShowDebug { get; set; } = false;

        [Browsable(false)]
        public bool ShowPD { get; init; } = false;

        [Browsable(false)]
        public bool ShowPR { get; init; } = false;

        #endregion Отображением полей

        #region Общие свойства элементов

        [Category(Data)]
        [VisibleBy("ShowPR")]
        [SortIndex(-3)]
        [DisplayName("Производительность")]
        public virtual float Performance { get; set; } = Project.VFlow;

        #region Падение давления

        protected float pressureDrop = 0;

        [Browsable(false)]
        public virtual float GeneratedPressureDrop => 0;

        [Category(Info)]
        [VisibleBy("ShowPD")]
        [SortIndex(-2)]
        [Optional("ManualPD")]
        [DisplayName("Падение давления")]
        [FormatString(fkPa)]
        public virtual float PressureDrop
        {
            get
            {
                if (!ManualPD)
                    pressureDrop = GeneratedPressureDrop;
                return pressureDrop;
            }
            set
            {
                pressureDrop = value;
            }
        }

        [VisibleBy("ShowPD")]
        [Browsable(false)]
        public bool ManualPD { get; set; } = false;

        #endregion Падение давления

        #endregion Общие свойства элементов

        #region Модель

        protected Type DeviceType = null;

        [Category(Debug)]
        [VisibleBy("ShowDebug")]
        public int DeviceIndex { get; set; } = -1;

        [Browsable(false)]
        public object DeviceData => DeviceIndex >= 0 ? Query.Result[DeviceIndex] : null;

        #endregion Модель

        #region Запрос

        [Browsable(false)]
        [JsonIgnore]
        public Dictionary<string, IValueConverter> Format => Conditions.Get(this.GetType());

        [Browsable(false)]
        [JsonIgnore]
        public Query Query { get; init; }

        #endregion Запрос

        #region Methods

        public static T GetInstance<T>(T o) => (T)Activator.CreateInstance(o.GetType());

        protected override string OnValidation()
        {
            if (DeviceType != null && DeviceData == null)
                return "Не выбрана модель устройства";
            else
                return "";
        }

        #endregion
    }
}