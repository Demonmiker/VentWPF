using PropertyTools.DataAnnotations; using static VentWPF.ViewModel.Strings;
using System.Collections;
using System.Collections.Generic;
using VentWPF.FanDLL;
using VentWPF.Tools;

namespace VentWPF.ViewModel
{
    internal class Fan_C : Fan
    {

        public Fan_C()
        {
            Name = "Вентилятор \"Обычный\"";
            ShowQuery = true;
        }

        public override IList Query => new DLLController() { RequestInfo = IOManager.LoadAsJson<FanDllRequest>("req.json") }.GetResponce();


    }
}