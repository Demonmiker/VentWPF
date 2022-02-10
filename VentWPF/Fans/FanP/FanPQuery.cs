using System.Collections;
using VentWPF.Fans.K3G;
using VentWPF.ViewModel;

namespace VentWPF.Fans.Nicotra
{
    internal class FanPQuery : Query
    {
        protected override QueryResult Fill(object q)//Request
        {
            var resp = new FanPController().GetResponce(q as FanPRequest,out string error);
            return new QueryResult() { ErrorMessage = error,List= resp };
        }
    }
}