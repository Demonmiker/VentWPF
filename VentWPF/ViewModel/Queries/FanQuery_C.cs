using System.Collections;
using VentWPF.Fans.FanSelect;
using VentWPF.Tools;

namespace VentWPF.ViewModel
{
    internal class FanQuery_C : Query
    {
        protected override IList Fill(object q)//Request
        {
            DllRequest data = q as DllRequest;
            DllRequest req = IOManager.LoadAsJson<DllRequest>("req.json");
            //
            req.PressureDrop = data.PressureDrop;
            //
            return new DllController().GetResponce(req);
        }
    }
}