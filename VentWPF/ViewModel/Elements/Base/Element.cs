﻿using Newtonsoft.Json;
using PropertyChanged;
using PropertyTools.DataAnnotations;
using System;
using System.Collections;
using System.Collections.Generic;

using System.IO;
using System.Linq;

namespace VentWPF.ViewModel
{
    internal class Element : BaseViewModel
    {
        public const string Data = "Данные";
        public const string Info = "Информация";
        public const string Debug = "Отладка";

        public const string f1 = "{0:0.0}";
        public const string f2 = "{0:0.00}";
        public const string fT = "{0:0.0}°";
        public const string fW = "{0:0.00}kВт";
        public const string fP = "{0:0.00}Па";
        public const string fF = "{0:0.00}%";
        
       

        protected string image = "Empty.png";

        public static ProjectInfoVM Project { get; set; } = ProjectInfoVM.Instance;

        public bool ShowPR { get; init; } = false;

        public bool ShowPD { get; init; } = false;

        public bool ShowDebug { get; set; } = true;

        [Browsable(false)]
        [DependsOn("SubType")]
        public virtual string Image => Path.GetFullPath("Assets/Images/" + image);

        [Browsable(false)]
        public string Name { get; protected set; } = "";
        
        [Category(Data)]
        [VisibleBy("ShowPR")]
        [SortIndex(-1)]
        [DisplayName("Производительность")]
        public virtual float Performance { get; set; } = Project.VFlow;

        [VisibleBy("ShowPD")]
        public virtual float PressureDrop => 0;

        [Browsable(false)]
        public int SubType { get; set; } = 0;

        [Browsable(false)]
        public object DeviceData => DeviceIndex >= 0 ? QueryCollection[DeviceIndex] : null;

        [VisibleBy("ShowDebug")]
        [Category(Debug)]
        public int DeviceIndex { get; set; } = -1;

        [Browsable(false)]
        [JsonIgnore]
        public Dictionary<string, Column> Format { get; init; }

        [Browsable(false)]
        public List<object> QueryCollection => Query != null ? Query.ToList() : null;

        [Browsable(false)]
        [JsonIgnore]
        protected IQueryable<object> Query { get; init; }


        public static T GetInstance<T>(T o) => (T)Activator.CreateInstance(o.GetType());
    }
}