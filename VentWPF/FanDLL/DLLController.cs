using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using VentWPF.Model;
using VentWPF.ViewModel;

namespace VentWPF.FanDLL
{
    internal class DLLController
    {
        public static int RNums = 0;
        public ProjectVM Project = ProjectVM.Instance;

        public static string ZAJsonRequest(String req)
        {
            return Marshal.PtrToStringUni(_ZAJsonRequest(req));
        }

        public List<FanData> Test()
        {
            string sRequest, sResponse;
            /*
            // Min. request:
            sRequest = "{'cmd': 'status'}";

            sResponse = ZAJsonRequest(sRequest);
            Status = sResponse;*/
            string UsernameEdit = "ZAFS19946";
            string PasswdEdit = "bnexg5";
            string psf = Convert.ToString(Project.PD);
            string qv = Convert.ToString(Project.VFlow);
            string InstH = Convert.ToString(Project.Height);
            string InstW = Convert.ToString(Project.Width); 
            string tolerance = "10";
            // Login & Search:
            sRequest = "{";
            sRequest += "'username': '" + UsernameEdit + "',";
            sRequest += "'password': '" + PasswdEdit + "',";
            //sRequest += "'installation_height_mm': '" + InstH + "',";
            //sRequest += "'installation_width_mm': '" + InstW + "',";
            sRequest += "'language': 'RU',";
            sRequest += "'unit_system': 'm',";
            sRequest += "'product_design': 'ER',";
            sRequest += "'cmd': 'search',";
            sRequest += "'psf': '" + psf + "',";
            sRequest += "'qv': '" + qv + "',";
            //sRequest += "'insert_aircalc': 'true',";
            sRequest += "'insert_nominal_values': 'true',";
            // sRequest += "'insert_customer_data': 'i_aircalc',";
            sRequest += "'insert_geo_data': 'true',";
            sRequest += "'insert_motor_data': 'true',";
            sRequest += "'search_tolerance': '" + tolerance + "',";
            sRequest += "}";
            sResponse = ZAJsonRequest(sRequest);
            if (sResponse[0] != '[')
            {
                return null;
            }
            else
            {
                //var serializer = new JavaScriptSerializer();
                //var aResult = serializer.Deserialize<List<FanData>>(sResponse);
                //return aResult;
                return new List<FanData>();
            }
        }

        [DllImport("FANselect.dll", EntryPoint = "ZAJsonRequestW",
                                    CharSet = CharSet.Unicode, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        private static extern IntPtr _ZAJsonRequest([MarshalAs(UnmanagedType.LPWStr)] String req);
    }
}