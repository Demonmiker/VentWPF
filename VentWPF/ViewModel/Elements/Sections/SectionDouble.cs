using PropertyTools.DataAnnotations;
using System;
using System.IO;

namespace VentWPF.ViewModel
{
    internal class SectionDouble : Section , IDoubleElement
    {
        public override string Name => $"Секция рециркуляции";
        public override string Image => Path.GetFullPath($"Assets/Images/Icons/Sections/DoubleBottom.png");


        [Browsable(false)]
        public string TopImage => Path.GetFullPath($"Assets/Images/Icons/Sections/DoubleTop.png");

        [Browsable(false)]
        public Element TopElement => new TestTopElement() {name=this.Name,
            image = Path.GetFullPath($"Assets/Images/Icons/Sections/DoubleTop.png") };
    }
}