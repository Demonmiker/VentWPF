using System.Windows;

namespace VentWPF.ViewModel
{
    internal abstract class SchemeBlock 
    {
        public bool First { get; set; }
    }
    internal class SchemeDoubleBlock : SchemeBlock
    {
        public DoubleSchemeElement[] Doubles { get; set; }
    }

    internal class SchemeSingleBlock : SchemeBlock
    {
        public SchemeElement[] Top{ get; set; }

        public SchemeElement[] Bottom { get; set; }

        public HorizontalAlignment Align { get; set; } = HorizontalAlignment.Center;
    }
}