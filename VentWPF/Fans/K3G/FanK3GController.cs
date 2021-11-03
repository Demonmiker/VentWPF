using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;

namespace VentWPF.Fans.K3G
{
    internal class FanK3GController : IController<FanK3GRequest, List<FanK3GData>>
    {
#pragma warning disable CS0618

        //Подключение
        [DllImport(@"Fans/K3G/DLL/EbmPapstFan.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public static extern int SET_XML_PATH_PC([MarshalAsAttribute(UnmanagedType.AnsiBStr)] string pfad);

        //получение списка ID
        [DllImport(@"Fans/K3G/DLL/EbmPapstFan.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public static extern int GET_PRODUCTS_PC([MarshalAsAttribute(UnmanagedType.AnsiBStr)] ref string pfad);

        //получение по ID информации по вентилятору
        [DllImport(@"Fans/K3G/DLL/EbmPapstFan.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public static extern int GET_CCSI_DATA([MarshalAsAttribute(UnmanagedType.AnsiBStr)] string fanDescription, ref string buffer);

#pragma warning restore CS0618

        private string[] Keys;

        public List<FanK3GData> GetResponce(FanK3GRequest request)
        {
            Connection();
            Keys ??= GetIDs().ToArray();
            List<FanK3GData> res = new();
            foreach (var id in Keys)
            {
                var list = GetFanInfo(id, request);
                var details = list.ToArray();
                if (details[0] != "0,00")
                {
                    FanK3GData data = new FanK3GData(id, list);
                    res.Add(data);
                }
            }
            return res;
        }

        public void Connection()
        {
            string path = System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            path += @"\Fans\K3G\DLL";
            if (File.Exists(path + @"\Data.sqlite") && File.Exists(path + @"\EbmPapstFan.dll"))
            {
                path += ";";
                _ = SET_XML_PATH_PC(path);
            }
            else
            {
                throw new FileNotFoundException("Файл не найден", path + @"Fans\K3G\DLL\Data.sqlite");
            }
        }

        public IEnumerable<string> GetIDs()
        {
            var bufferIDs = new string(new Char(), 4000);
            int n = GET_PRODUCTS_PC(ref bufferIDs);
            var str = bufferIDs.ToString();
            return str.Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries).Where(x => !x.StartsWith("K3G"));
        }

        public IEnumerable<string> GetFanInfo(string id, FanK3GRequest req)
        {
            req.ID = id;
            var bufferInfo = new string(new Char(), 4000);
            var r = req.GetRequest();
            GET_CCSI_DATA(r, ref bufferInfo);
            return bufferInfo.Split(new[] { ';' });
        }
    }
}