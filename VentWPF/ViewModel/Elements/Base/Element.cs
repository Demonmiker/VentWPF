﻿using System.Collections;
using System.ComponentModel;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using VentWPF.Model;
using System.Collections.ObjectModel;
using System.Windows.Controls;

namespace VentWPF.ViewModel
{
    public class Element : BaseViewModel
    {
        public const string c1 = "Данные";
        public const string c2 = "Информация";

        protected string image = "Empty.png";

        public static ProjectVM project { get; set; } = new();

        [Browsable(false)]
        public virtual string Image => Path.GetFullPath("Assets/Images/" + image);

        [Browsable(false)]
        public string Name { get; protected set; } = "";

        [Browsable(false)]
        public virtual float Performance { get; set; }

        [Browsable(false)]
        public virtual float PressureDrop => 0;

        [Browsable(false)]
        public ICollection QueryCollection => Query != null ? Query.ToList() : null;

        [Browsable(false)]
        protected IQueryable<object> Query { get; init; }

    }
}