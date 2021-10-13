using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text.Json;

namespace VentWPF.Fans.FanSelect
{
    internal class DllController : IController<DllRequest, List<FanCData>>
    {
        public List<FanCData> GetResponce(DllRequest request)
        {
            string response = Request(request.GetRequest());
            return response[0] != '[' ? null : JsonSerializer.Deserialize<List<FanCData>>(response);
        }

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
    }
}