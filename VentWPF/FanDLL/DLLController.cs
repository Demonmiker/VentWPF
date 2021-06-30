using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text.Json;
using VentWPF.Model;
using VentWPF.ViewModel;

namespace VentWPF.FanDLL
{
    internal class DLLController
    {
        public static int RNums = 0;
        public ProjectVM Project = ProjectVM.Instance;
        public DLLRequest Request{ get; set; }


        public List<FanData> GetResponce()
        {
            string response = ZAJsonRequest(Request.ToString());
            return response[0] != '[' ? null : (List<FanData>)JsonSerializer.Deserialize(response, typeof(List<FanData>));
        }


        #region DLL import
        [DllImport("FANselect.dll", EntryPoint = "ZAJsonRequestW",
                                    CharSet = CharSet.Unicode, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        private static extern IntPtr _ZAJsonRequest([MarshalAs(UnmanagedType.LPWStr)] String req);

        private static string ZAJsonRequest(String req)
        {
            return Marshal.PtrToStringUni(_ZAJsonRequest(req));
        }
        #endregion


    }
}