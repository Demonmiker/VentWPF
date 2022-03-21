using System;
using System.IO;
using System.Linq;
using System.Windows;

namespace VentWPF.ViewModel
{
    internal abstract class SchemeBlock 
    {

        public abstract string BackImage { get; }
        abstract public uint Sum();
        public ProjectVM Project { get; init; } = ProjectVM.Current;
        public bool First { get; set; }
        public bool Last { get; set; }
    }
    internal class SchemeDoubleBlock : SchemeBlock
    {
        public DoubleSchemeElement[] Doubles { get; set; }

        public override uint Sum() => (uint)Doubles.Sum(x => x.Length);
        public override string BackImage => Path.GetFullPath("Assets/Images/Scheme/Back2.png");
    }

    internal class SchemeSingleBlock : SchemeBlock
    {
        public override string BackImage => Path.GetFullPath("Assets/Images/Scheme/Back.png");

        public bool TwoRows { get; init; }

        public SchemeElement[] Top{ get; set; }

        public SchemeElement[] Bottom { get; set; }

        public HorizontalAlignment Align { get; set; } = HorizontalAlignment.Stretch;
        public override uint Sum() => (uint)Bottom.Sum(x => x.Length);
    }
}