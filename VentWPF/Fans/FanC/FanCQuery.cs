using System.Collections;
using VentWPF.Fans.FanSelect;
using VentWPF.Tools;

namespace VentWPF.ViewModel
{
    internal class FanCQuery : Query
    {
        protected override QueryResult Fill(object q)//Request
        {
            var resp = new DllController().GetResponce(q as FanCRequest,out string error);
                return new QueryResult() { ErrorMessage = error ,List = resp };

        }
    }
}