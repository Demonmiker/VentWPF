using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VentWPF.Fans.FanSelect
{
    class WebController : IController<DllRequest, string>
    {
        public string GetResponce(DllRequest request)
        {
            //Найти Session Id
            var session = "temp";
            WebRequest webRequest = request as WebRequest;
            webRequest.SessionID = session;
            throw new NotImplementedException();
        }
    }
}
