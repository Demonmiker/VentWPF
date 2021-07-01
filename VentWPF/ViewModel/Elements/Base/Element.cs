using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;

namespace VentWPF.ViewModel
{
    internal class Element : BaseViewModel
    {
        public const string c1 = "Данные";
        public const string c2 = "Информация";

        protected string image = "Empty.png";

        public static ProjectInfoVM Project { get; set; } = ProjectInfoVM.Instance;

        [Browsable(false)]
        public virtual string Image => Path.GetFullPath("Assets/Images/" + image);

        [Browsable(false)]
        public string Name { get; protected set; } = "";

        [Browsable(false)]
        public virtual float Performance { get; set; }

        [Browsable(false)]
        public virtual float PressureDrop => 0;

        [Browsable(false)]
        public int SubType = 0;

        #region DataGrid

        [Browsable(false)]
        public object DeviceData => DeviceIndex >= 0 ? QueryCollection[DeviceIndex] : null;

        [DisplayName("Индекс")]
        [Category(c2), PropertyOrder(10)]
        public int DeviceIndex { get; set; } = 0;

        [Browsable(false)]
        [JsonIgnore]
        public Dictionary<string, Column> Format { get; init; }

        [Browsable(false)]
        public List<object> QueryCollection => Query != null ? Query.ToList() : null;

        [Browsable(false)]
        [JsonIgnore]
        protected IQueryable<object> Query { get; init; }
        #endregion DataGrid

        public static T GetInstance<T>(T o) => (T)Activator.CreateInstance(o.GetType());
    }
}