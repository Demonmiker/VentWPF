﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text.Json;

namespace VentWPF.Fans.FanSelect
{
    internal class FanCController : IController<FanCRequest, List<FanCData>>
    {
        //TODO удалить дубликаты
        public List<FanCData> GetResponce(FanCRequest request,out string error)
        {
            error = null;
            try
            {
                string response = Request(request.GetRequest());

                var result = response[0] != '[' ? null : JsonSerializer.Deserialize<List<FanCData>>(response);
                result = result.Distinct().ToList();
                return result;
            }
            catch (Exception ex)
            {
                error = ex.Message;
                return null;
            }
        }

        [DllImport(
            "Fans/FanC/DLL/FANselect.dll",
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