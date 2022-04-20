﻿using PropertyTools.DataAnnotations;
using System.IO;

namespace VentWPF.ViewModel
{
    internal class SectionDouble : Section, IDoubleMainElement
    {
        public override string Name => $"Секция рециркуляции";
        public override string Image => Path.GetFullPath($"Assets/Images/Icons/Sections/DoubleBottom.png");

        public Element GetNewTopElement()
        {
            return new DecoyElement()
            {
                name = this.Name,
                image = ImagePath($"Sections/DoubleTop")
            };
        }
    }


}