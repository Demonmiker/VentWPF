using PropertyTools.DataAnnotations;
using static VentWPF.ViewModel.Strings;
using System.Collections;
using System.Collections.Generic;
using VentWPF.Tools;
using VentWPF.Fans.FanSelect;

namespace VentWPF.ViewModel
{
    internal class Fan_K3G : Fan
    {
        private Fan_K3G()
        {
        }

        public override string Name => "Вентилятор поточный";

        protected override List<string> InfoProperties => new()
        {
            "PressureDropSystem",
            "PressureRaise",

        };
    }
}