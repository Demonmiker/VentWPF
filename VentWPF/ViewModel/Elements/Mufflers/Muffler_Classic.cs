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
    internal class Muffler_Classic : Muffler
    {
        public Muffler_Classic()
        {
            image = "Mufflers/Muffler.png";
        }

        public override string Name => "Шумоглушитель";

        protected override List<string> InfoProperties => new()
        {
            "FC",            
        };
        }
}