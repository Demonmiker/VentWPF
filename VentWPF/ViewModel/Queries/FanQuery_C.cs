using System.Collections;
using VentWPF.Fans.FanSelect;
using VentWPF.Tools;

namespace VentWPF.ViewModel
{
    internal class FanQuery_C : Query
    {
        protected override IList Fill(object q)//Request
        {
            FanCRequest data = q as FanCRequest;
            FanCRequest req = IOManager.LoadAsJson<FanCRequest>("req.json");
            //
            req.PressureDrop = data.PressureDrop;
            //
            return new DllController().GetResponce(req);
        }
    }
}