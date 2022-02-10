using System.Collections;
using VentWPF.Fans.K3G;
using VentWPF.Tools;
using VentWPF.ViewModel;

namespace VentWPF.Fans.K3G
{
    internal class FanK3GQuery : Query
    {
        protected override QueryResult Fill(object q)//Request
        {
            var resp = new FanK3GController().GetResponce(q as FanK3GRequest,out string error);
            return new QueryResult() { List = resp ,ErrorMessage=error};

        }
    }
}