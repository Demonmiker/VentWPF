using PropertyTools.DataAnnotations;
using static VentWPF.ViewModel.Strings;
using System.Collections;
using System.Collections.Generic;
using VentWPF.Tools;
using VentWPF.Fans.FanSelect;

namespace VentWPF.ViewModel
{
    internal class Fan_P : Fan
    {
        public Fan_P()
        {
        }

        public override string Name => "Вентилятор улиточный";

        protected override List<string> InfoProperties => new()
        {
            "PressureDropSystem",
            "PressureRaise",

        };
    }

    
}