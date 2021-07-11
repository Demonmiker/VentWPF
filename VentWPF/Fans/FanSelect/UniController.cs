using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VentWPF.Fans.FanSelect
{
    class UniController : IController<IRequest<string>, string>
    {
        public string GetResponce(IRequest<string> request)
        {
            return request switch
            {
                WebRequest => throw new NotImplementedException(),
                DllRequest => throw new NotImplementedException(),
                _ => throw new NotImplementedException(),
            };
        }
    }
}
