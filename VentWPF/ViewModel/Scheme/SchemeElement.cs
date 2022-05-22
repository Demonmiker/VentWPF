using System;
using System.Collections.Generic;
using System.Windows;

namespace VentWPF.ViewModel
{
    internal class SchemeElement
    {

        public SchemeImageVM Scheme { get; init; }
        public Element Element { get; set; }
        public Thickness Margin { get; set; }
        public bool TopValve { get; set; }

        public bool TopText { get; set; }

        private uint length;
        public uint Length
        {
            get => length;
            set 
            { 
                length = value;
                Scheme.UpdateSum();
            }
        }

        static Dictionary<(Type,int), Thickness> Margins = new Dictionary<(Type,int), Thickness>()
        {
            { (typeof(FanC),(int)FanDirection.LeftUp) , new Thickness(112,0,8,0)},
            { (typeof(FanC),(int)FanDirection.UpLeft) , new Thickness(8,0,112,0)},
            { (typeof(FanP),(int)FanDirection.LeftUpRight) , new Thickness(8,0,112,0)},
            { (typeof(FanP),(int)FanDirection.LeftUpLeft) , new Thickness(8,0,112,0)},
            { (typeof(FanP),(int)FanDirection.RightUpLeft) , new Thickness(8,0,112,0)},
            { (typeof(FanK3G),(int)FanDirection.LeftUp) , new Thickness(76,0,8,0)},
            { (typeof(Section),(int)SectionType.LeftUp) , new Thickness(0,0,0,0)},
        };

        public SchemeElement(SchemeImageVM scheme, Element el)
        {
            Scheme = scheme ?? throw new ArgumentNullException(nameof(scheme));
            Element = el ?? throw new ArgumentNullException(nameof(el));
            Length = el.Length > 0 ? (uint)el.Length : 0u;
            if (Margins.ContainsKey((Element.GetType(),Element.SubType)))
            {
                TopText = true;
                Margin = Margins[(Element.GetType(),Element.SubType)];
            }
            if (Element is Section sec && sec.Direction == SectionType.LeftUp)
            {
                TopValve = true;
            }
        }

    }

    internal class DoubleSchemeElement
    {
        public SchemeImageVM Scheme { get; init; }
        public Element Top { get; set; }
        public Element Bottom { get; set; }
        public DoubleSchemeElement(SchemeImageVM scheme,Element top, Element bottom)
        {
            Scheme = scheme ?? throw new ArgumentNullException(nameof(scheme));
            Top = top ?? throw new ArgumentNullException(nameof(top));
            Bottom = bottom ?? throw new ArgumentNullException(nameof(bottom));
            var max = Math.Max(Top.Length, Bottom.Length);
            Length = max > 0 ? (uint)max : 0u;
        }

        private uint length;
        public uint Length
        {
            get => length;
            set 
            {
                length = value;
                Scheme.UpdateSum();
            }
        }
    }

}