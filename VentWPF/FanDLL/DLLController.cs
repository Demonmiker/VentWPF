using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text.Json;
using VentWPF.Model;
using VentWPF.ViewModel;

namespace VentWPF.FanDLL
{
    internal class DLLController : IFanController
    {
        public static int RNums = 0;
        public ProjectInfoVM Project = ProjectInfoVM.Instance;
        public DLLRequest RequestInfo{ get; set; }


        public List<FanData> GetResponce()
        {
            string response = Request(RequestInfo.ToString());
            return response[0] != '[' ? null : JsonSerializer.Deserialize(response, typeof(List<FanData>)) as List<FanData>;
        }

        public string GetResponceString()
        {
            return Request(RequestInfo.ToString());
           
        }


        #region DLL import
        [DllImport(
            "FanDLL/FANselect.dll",
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