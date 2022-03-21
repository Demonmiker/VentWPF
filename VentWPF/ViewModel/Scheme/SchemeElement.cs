using System;

namespace VentWPF.ViewModel
{
    internal class SchemeElement
    {

        public SchemeImageVM Scheme { get; init; }
        public Element Element { get; set; }

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


        public SchemeElement(SchemeImageVM scheme, Element el)
        {
            Scheme = scheme ?? throw new ArgumentNullException(nameof(scheme));
            Element = el ?? throw new ArgumentNullException(nameof(el));
            Length = el.Length > 0 ? (uint)el.Length : 0u;
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