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
            var session = "temp";
            //Найти Session Id
            WebRequest webRequest = new WebRequest(request, session);
            throw new NotImplementedException();
        }
    }
}
