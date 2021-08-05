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
            Query = new FanQuery_C()
            {
                Source = new DllRequest()
                {
                    PressureDrop = 123,
                }
            };
        }

        public override string Name => "Вентилятор";

        


    }
}