using System;

namespace VentWPF.ViewModel
{
    internal class SchemeElement
    {
        public Element Element { get; set; }
        public int Length { get; set; }

        public SchemeElement(Element el)
        {
            Element = el;
            Length = el.Length;
        }

    }

    internal class DoubleSchemeElement
    {
        public Element Top { get; set; }
        public Element Bottom { get; set; }
        public int Length { get; set; }

        public DoubleSchemeElement(Element top, Element bottom)
        {
            Top = top;
            Bottom = bottom;
            Length = Math.Max(Top.Length, Bottom.Length);
        }

    }

}