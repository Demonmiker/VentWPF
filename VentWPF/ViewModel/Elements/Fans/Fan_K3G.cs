using System.Collections.Generic;

namespace VentWPF.ViewModel
{
    internal class Fan_K3G : Fan
    {
        private Fan_K3G()
        {
        }

        public override string Name => "Вентилятор поточный";

        
        public override List<string> InfoProperties => new()
        {
            "PressureDropSystem",
            "PressureRaise",
        };
    }
}