using System.Collections;
using VentWPF.Fans.K3G;
using VentWPF.ViewModel;

namespace VentWPF.Fans.Nicotra
{
    internal class FanPQuery : Query
    {
        protected override IList Fill(object q)//Request
        {
            return new FanPController().GetResponce(q as FanPRequest);
        }
    }
}