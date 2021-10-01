﻿using System.Collections.Generic;

namespace VentWPF.ViewModel
{
    /// <summary>
    /// Шумаглушитель с выравниванием
    /// </summary>
    internal class Muffler_Corrector : Muffler
    {

        public Muffler_Corrector()
        {
            image = "Mufflers/Muffler_Corrector.png";
        }

        public override string Name => "Шумоглушитель с выравниванием";

        protected override List<string> InfoProperties => new()
        {
            "FC",
        };

    }
}