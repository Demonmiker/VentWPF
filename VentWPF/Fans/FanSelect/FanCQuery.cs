using System.Collections;
using VentWPF.Fans.FanSelect;
using VentWPF.Tools;

namespace VentWPF.ViewModel
{
    internal class FanCQuery : Query
    {
        protected override IList Fill(object q)//Request
        {
            return new DllController().GetResponce(q as FanCRequest);
        }
    }
}