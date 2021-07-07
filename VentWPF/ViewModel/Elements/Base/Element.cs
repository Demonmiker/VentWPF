using Newtonsoft.Json;
using PropertyChanged;
using PropertyTools.DataAnnotations;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
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

        [Browsable(false)]
        public string Name { get; protected set; } = "null";

        #region Info

        [DependsOn("DeviceData")]
        public IEnumerable<InfoLine> InfoLines => InfoLine.GenerateInfoLines(this, InfoProperties);

        protected virtual List<string> InfoProperties => new() { };

        public Paragraph Info = new Paragraph(new Run() {Bin);
        #endregion;

        #region Управление изображением

        protected string image = "Empty.png";

        [Browsable(false)]
        [DependsOn("SubType")]
        public virtual string Image => Path.GetFullPath("Assets/Images/" + image);

        [Browsable(false)]
        public int SubType { get; set; } = 0;

        #endregion Управление изображением

        #region отображением полей

        private float? pdlocal = null;

        [Browsable(true)]
        [DisplayName("Тест")]
        public bool EnablePD { get; init; } = false;

        [EnableBy("EnablePD")]
        [HeaderPlacement(HeaderPlacement.Collapsed)]
        public virtual float PressureTest
        {
            get
            {
                if (EnablePD && pdlocal != null)
                    return (float)pdlocal;
                else
                    return PressureDrop;
            }
            set
            {
                pdlocal = value;
            }
        }

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

        #endregion отображением полей

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

        #region Запрос

        [Browsable(false)]
        public object DeviceData => DeviceIndex >= 0 ? QueryCollection[DeviceIndex] : null;

        [Category(Debug)]
        [VisibleBy("ShowDebug")]
        public int DeviceIndex { get; set; } = -1;

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