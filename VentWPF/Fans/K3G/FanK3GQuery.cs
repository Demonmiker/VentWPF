using System.Collections;
using VentWPF.Fans.K3G;
using VentWPF.Tools;
using VentWPF.ViewModel;

namespace VentWPF.Fans.K3G
{
    internal class FanK3GQuery : Query
    {
        protected override IList Fill(object q)//Request
        {
            return new FanK3GController().GetResponce(q as FanK3GRequest);
        }
    }
}