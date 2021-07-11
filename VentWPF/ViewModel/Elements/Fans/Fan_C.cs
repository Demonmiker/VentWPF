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
            Name = "Вентилятор \"Обычный\"";
            ShowQuery = true;
        }

        public override IList Query => new DllController().GetResponce(IOManager.LoadAsJson<DllRequest>("req.json"));


    }
}