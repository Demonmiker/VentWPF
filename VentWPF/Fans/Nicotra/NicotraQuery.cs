using System.Collections;
using VentWPF.Fans.K3G;
using VentWPF.ViewModel;

namespace VentWPF.Fans.Nicotra
{
    internal class NicotraQuery : Query
    {
        protected override IList Fill(object q)//Request
        {
            return new NicotraController().GetResponce(q as NicotraRequest);
        }
    }
}