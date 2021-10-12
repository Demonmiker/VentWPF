using System;
using System.Linq;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.Json;
using VentWPF.ViewModel;

namespace VentWPF.Fans.K3G
{
    internal class K3GController : IController<K3GRequest, List<K3GFanData>>
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

        public List<K3GFanData> GetResponce(K3GRequest request)
        {
            Connection();
            var ids = GetIDs();
            List<K3GFanData> res = new();
            foreach (var id in ids)
            {
                var list = GetFanInfo(id, request);
                K3GFanData data = new K3GFanData(id, list);
                res.Add(data);
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

        public IEnumerable<string> GetFanInfo(string id, K3GRequest req)
        {
            req.ID = id;
            var bufferInfo = new string(new Char(), 4000);
            var r = req.GetRequest();
            GET_CCSI_DATA(r, ref bufferInfo);
            return bufferInfo.Split(new[] { ';' });
        }
    }
}