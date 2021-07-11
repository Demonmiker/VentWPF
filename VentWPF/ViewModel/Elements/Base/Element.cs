using Newtonsoft.Json;
using PropertyChanged;
using PropertyTools.DataAnnotations;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Data;
using System.Windows.Documents;
using VentWPF.Tools;
using VentWPF.ViewModel.Elements;
using static VentWPF.ViewModel.Strings;

namespace VentWPF.ViewModel
{
    internal class Element : BaseViewModel
    {

        public static ProjectInfoVM Project { get; set; } = ProjectInfoVM.Instance;

        /// <summary>
        /// Наименование элемента системы вентиляции
        /// </summary>
        [Browsable(false)]
        public string Name { get; protected set; } = "";

        #region Генерация документации

        protected virtual List<string> InfoProperties => new() { };

        [Browsable(false)]
        public List<TableRow> Rows => GetRows(columns: 2);

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

        [Browsable(false)]
        public bool ShowQuery { get; init; } = false;

        #endregion Отображением полей

        #region Общие свойства элементов

        [Category(Data)]
        [VisibleBy("ShowPR")]
        [SortIndex(-3)]
        [DisplayName("Производительность")]
        public virtual float Performance { get; set; } = Project.VFlow;

        [VisibleBy("ShowPD")]
        [SortIndex(-2)]
        public virtual float PressureDrop => 0;

        #endregion Общие свойства элементов

        #region Модель

        [Category(Debug)]
        [VisibleBy("ShowDebug")]
        public int DeviceIndex { get; set; } = -1;

        [Browsable(false)]
        public object DeviceData => DeviceIndex >= 0 ? QueryCollection[DeviceIndex] : null;

        protected Type DeviceType = null;

        #endregion Модель

        #region Запрос

        [Browsable(false)]
        [JsonIgnore]
        public Dictionary<string, IValueConverter> Format => Conditions.Get(this.GetType());

        [Browsable(false)]
        public virtual IList Query => null;

        [Browsable(false)]
        public IList QueryCache { get; set; }

        [Browsable(false)]
        [DependsOn("QueryCache")]
        public IList QueryCollection
        {
            get
            {
                if (ShowQuery)
                    if (QueryCache == null)
                        TaskManager.Add(() =>
                        {
                            if (QueryCache == null)
                                QueryCache = Query;
                        });
                return QueryCache;
            }
        }

        #endregion Запрос

        public static T GetInstance<T>(T o) => (T)Activator.CreateInstance(o.GetType());
    }
}