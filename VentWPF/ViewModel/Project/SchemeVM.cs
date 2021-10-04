using System;
using System.Collections.Generic;
using System.Linq;

namespace VentWPF.ViewModel
{
    internal class SchemeVM : BaseViewModel
    {
        public List<ElementPair> Elements { get; init; } = new List<ElementPair>();

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