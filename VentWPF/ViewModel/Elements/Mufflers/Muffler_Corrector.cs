using PropertyTools.DataAnnotations;
using static VentWPF.ViewModel.Strings;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using VentWPF.Model;
using VentWPF.Tools;
using PropertyChanged;

namespace VentWPF.ViewModel
{
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