using System.IO;
using System.Windows;

namespace VentWPF.ViewModel
{
    internal abstract class SchemeBlock 
    {
        public ProjectVM Project { get; init; } = ProjectVM.Current;
        public bool First { get; set; }
    }
    internal class SchemeDoubleBlock : SchemeBlock
    {
        public DoubleSchemeElement[] Doubles { get; set; }
    }

    internal class SchemeSingleBlock : SchemeBlock
    {
        public string BackImage => Path.GetFullPath("Assets/Images/Scheme/Back.png");

        public bool TwoRows { get; init; }

        public SchemeElement[] Top{ get; set; }

        public SchemeElement[] Bottom { get; set; }

        public HorizontalAlignment Align { get; set; } = HorizontalAlignment.Stretch;
    }
}