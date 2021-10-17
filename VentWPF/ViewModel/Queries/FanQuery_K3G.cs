using System.Collections;
using VentWPF.Fans.K3G;
using VentWPF.Tools;

namespace VentWPF.ViewModel
{
    internal class FanQuery_K3G : Query
    {
        protected override IList Fill(object q)//Request
        {
            return new K3GController().GetResponce(q as K3GRequest);
        }
    }
}