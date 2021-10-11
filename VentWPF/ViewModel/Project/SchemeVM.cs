using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using VentWPF.Tools;

namespace VentWPF.ViewModel
{
    internal class SchemeVM : BaseViewModel
    {
        public bool Visible { get; set; } = false;

        public ObservableCollection<ElementPair> Elements { get; init; } = new ObservableCollection<ElementPair>();

        public bool TwoRows { get; set; } = true;

        public int Sum { get; private set; }

        public int WidthTop { get; set; }

        public int WidthBottom { get; set; }

        public int WidthSum { get; private set; }

        public void Init()
        {
            Sum = Elements.Select(x => Math.Max(x.Top?.Length ?? 0, x.Bottom?.Length ?? 0)).Sum();
            if (TwoRows)
                WidthSum = WidthTop + WidthBottom;
            else
                WidthSum = WidthBottom;
        }
    }

    internal struct ElementPair
    {
        public Element Top { get; init; }

        public Element Bottom { get; init; }

        public bool TwoRows { get; init; }
    }
}