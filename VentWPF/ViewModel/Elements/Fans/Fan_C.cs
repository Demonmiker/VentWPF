using PropertyTools.DataAnnotations; using static VentWPF.ViewModel.Strings;
using System.Collections;
using System.Collections.Generic;
using VentWPF.Tools;
using VentWPF.Fans.FanSelect;

namespace VentWPF.ViewModel
{
    internal class Fan_C : Fan
    {

        public Fan_C()
        {
            //public override IList Query => new DllController()
            //.GetResponce(IOManager.LoadAsJson<DllRequest>("req.json"));

        }

        public override string Name => "Вентилятор";

        protected override List<string> InfoProperties => new()
        {
            "PressureDropSystem",
            "PressureRaise",
            
        };

    }
}