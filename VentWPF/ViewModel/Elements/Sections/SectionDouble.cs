using PropertyTools.DataAnnotations;
using System.IO;

namespace VentWPF.ViewModel
{
    internal class SectionDouble : Section , IDoubleElement
    {
        public override string Name => $"Секция рециркуляции";
        public override string Image => Path.GetFullPath($"Assets/Images/Icons/Sections/DoubleBottom.png");

        public override bool TwoRowsOnly => true;

        [Browsable(false)]
        public string TopImage => Path.GetFullPath($"Assets/Images/Icons/Sections/DoubleTop.png");
    }
}