﻿using PropertyTools.DataAnnotations; using static VentWPF.ViewModel.Strings;

namespace VentWPF.ViewModel
{
    internal class Humid_Steam : Humid
    {
        public Humid_Steam()
        {
            Name = "Увлажнитель паровой";
            image = "Humidifiers/Humid_Steam.png";
        }
    }
}