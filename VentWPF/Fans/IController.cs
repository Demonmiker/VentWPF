using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VentWPF.Fans
{
    interface IController<Tin,Tout>
    {
        Tout GetResponce(Tin request);
    }
}
