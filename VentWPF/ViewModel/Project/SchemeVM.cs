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
        public ProjectVM Parent { get; set; }

        public bool Visible { get; set; } = false;

        public ObservableCollection<Element> TopElements { get; set; } = new ObservableCollection<Element>();

        public ObservableCollection<Element> BottomElements { get; set; } = new ObservableCollection<Element>();

        public bool TwoRows { get; set; } = true;

        public int Sum { get; private set; }

        public int WidthTop { get; set; }

        public int WidthBottom { get; set; }

        public int WidthSum { get; private set; }

        public void Init()
        {
            Sum = BottomElements.Select(x => x.Length).Sum();
            if (TwoRows)
                WidthSum = WidthTop + WidthBottom;
            else
                WidthSum = WidthBottom;
        }
    }
}