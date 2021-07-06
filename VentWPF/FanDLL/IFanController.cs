using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VentWPF.FanDLL
{
    interface IFanController
    {
        List<FanData> GetResponce();

        string GetResponceString();
    }
}
