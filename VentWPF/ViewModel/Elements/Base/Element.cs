using Newtonsoft.Json;
using PropertyChanged;
using PropertyTools.DataAnnotations; using static VentWPF.ViewModel.Strings;
using System;
using System.Collections;
using System.Collections.Generic;

using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Data;
using VentWPF.Tools;
using VentWPF.ViewModel.Elements;

namespace VentWPF.ViewModel
{
    internal class Element : BaseViewModel
    {
        [Browsable(false)]
        public string Name { get; protected set; } = "";

        public static ProjectInfoVM Project { get; set; } = ProjectInfoVM.Instance;

        #region Управление изображением
        protected string image = "Empty.png";
        [Browsable(false)]
        public int SubType { get; set; } = 0;

        [Browsable(false)]
        [DependsOn("SubType")]
        public virtual string Image => Path.GetFullPath("Assets/Images/" + image);
        #endregion

        #region отображением полей
        [Browsable(false)]
        public bool ShowQuery { get; init; } = false;

        [Browsable(false)]
        public bool ShowPR { get; init; } = false;

        [Browsable(false)]
        public bool ShowPD { get; init; } = false;

        [Browsable(true)]
        [DisplayName("Тест")]
        public bool EnablePD { get; init; } = false;

        private float? pdlocal = null;

        [EnableBy("EnablePD")]
        [HeaderPlacement(HeaderPlacement.Collapsed)]
        public virtual float PreessureTest
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

        #endregion

        #region Общие свойства элементов
        [Category(Data)]
        [VisibleBy("ShowPR")]
        [SortIndex(-3)]
        
        [DisplayName("Производительность")]
        public virtual float Performance { get; set; } = Project.VFlow;

        [VisibleBy("ShowPD")]
        [SortIndex(-2)]
        public virtual float PressureDrop => 0;
        #endregion

        #region Запрос

        [Browsable(false)]
        public IList QueryCache { get; set; }

        [Browsable(false)]
        public virtual IList Query => null;

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

        [Category(Debug)]
        [VisibleBy("ShowDebug")]
        public int DeviceIndex { get; set; } = -1;

        [Browsable(false)]
        public object DeviceData => DeviceIndex >= 0 ? QueryCollection[DeviceIndex] : null;

        #endregion

        [Browsable(false)]
        [JsonIgnore]
        public Dictionary<string, IValueConverter> Format => Conditions.Get(this.GetType());

        public static T GetInstance<T>(T o) => (T)Activator.CreateInstance(o.GetType());


    }
}