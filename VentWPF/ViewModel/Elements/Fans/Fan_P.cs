using System.Collections.Generic;

namespace VentWPF.ViewModel
{
    internal class Fan_P : Fan
    {
        public Fan_P()
        {
        }

        public override string Name => "Вентилятор улиточный";

        public override List<string> InfoProperties => new()
        {
            "PressureDropSystem",
            "PressureRaise",
        };
    }
}