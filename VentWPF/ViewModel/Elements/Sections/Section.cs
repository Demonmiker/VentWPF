﻿using PropertyChanged;
using PropertyTools.DataAnnotations;
using System.IO;

namespace VentWPF.ViewModel
{
    internal class Section : Element
    {
        public Section()
        {
            ShowPD = false;
        }

        [Browsable(false)]
        public SectionType Direction
        {
            get => (SectionType)SubType;
            set => SubType = (int)value;
        }

        [DependsOn(nameof(DeviceData))]
        public override string Name => $"Секция";

        public override string Image => Path.GetFullPath($"Assets/Images/Sections/Section_{Direction}.png");
    }
}