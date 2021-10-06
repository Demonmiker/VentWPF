using System.Collections;
using VentWPF.Fans.K3G;
using VentWPF.Tools;

namespace VentWPF.ViewModel
{
    internal class FanQuery_K3G : Query
    {
        protected override IList Fill(object q)//Request
        {
            K3GRequest data = q as K3GRequest;
            K3GRequest req = IOManager.LoadAsJson<K3GRequest>("reqK3G.json");
            //
            req.ID = data.ID;
            //
            return new K3GController().GetResponce(req);
        }
    }
}
