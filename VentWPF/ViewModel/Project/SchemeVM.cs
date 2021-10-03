using System;
using System.Collections.Generic;
using System.Linq;

namespace VentWPF.ViewModel
{
    internal class SchemeVM : BaseViewModel
    {
        public List<ElementPair> Elements { get; init; } = new List<ElementPair>();

        public bool TwoRows { get; set; } = true;

        public int Sum { get; private set; } = 9999;

        public int WidthTop { get; set; } = 400;

        public int WidthBottom { get; set; } = 500;

        public int WidthSum { get; private set; } = 1500;

        public SchemeVM()
        {
            Elements.Add(new ElementPair() { Top = new Heater_Water(), Bottom = new Humid_Cell(), TwoRows = true });
            Elements.Add(new ElementPair() { Top = new Humid_Cell(), Bottom = new Heater_Water(), TwoRows = true });
            Init();
        }

        public void Init()
        {
            Sum = Elements.Select(x => Math.Max(x.Top.Length, x.Bottom.Length)).Sum();
            WidthSum = WidthTop + WidthBottom;
        }
    }

    internal struct ElementPair
    {
        public Element Top { get; init; }

        public Element Bottom { get; init; }

        public bool TwoRows { get; init; }
    }
}