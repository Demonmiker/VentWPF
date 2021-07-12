using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace VentWPF.Fans.FanSelect
{
    class DllController : IController<DllRequest,List<FanData>>
    {
        public List<FanData> GetResponce(DllRequest request)
        {
            string response = Request(request.GetRequest());
            return response[0] != '[' ? null : JsonSerializer.Deserialize<List<FanData>>(response);
        }

        #region DLL import
        [DllImport(
            "Fans/FanSelect/DLL/FANselect.dll",
            EntryPoint = "ZAJsonRequestW",
            CharSet = CharSet.Unicode,
            ExactSpelling = true,
            CallingConvention = CallingConvention.StdCall)
        ]
        private static extern IntPtr _ZAJsonRequest([MarshalAs(UnmanagedType.LPWStr)] String req);

        private static string Request(String req)
        {
            return Marshal.PtrToStringUni(_ZAJsonRequest(req));
        }
        #endregion
    }
}
