using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using VentWPF.Model.Calculations;
using VentWPF.ViewModel;

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

        [DllImport("EbmPapstFan.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public static extern int SEARCH_PRODUCTS([MarshalAs(UnmanagedType.AnsiBStr)] string fanDescription, ref string buffer);
        /*
         * работает лучше, определяет заранее подходящие вентиляторы
         * на вход строка:
         *VFlow;Давленее(общее);критерий поиска(в %);Ширина уст(мм);Длина уст(мм);критерий поиска(в %);тип; (последние два можно не вводить, уточняется)
         */

#pragma warning restore CS0618

        public static ProjectInfoVM ProjectInfo { get; set; } = ProjectVM.Current?.ProjectInfo;

        private string[] Keys;

        public List<FanK3GData> GetResponce(FanK3GRequest request,out string error)
        {
            error = null;
            try
            {
                Connection(request);
                Keys ??= GetIDs(request).ToArray();
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
            catch (Exception ex)
            {
                error = ex.Message;
                return null;
            }
        }

        public void Connection(FanK3GRequest request)
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

        //TODO оптимизировать нововведения
        public IEnumerable<string> GetIDs(FanK3GRequest request)
        {
            string bufferIDs = new String('0', 4000);
            //TODO: переделать высоту под два яруса
            string fanString = $"{ProjectInfo.Settings.VFlow};{request.RequiredPressure};50;1.15;" +
                $"{ProjectInfo.Settings.Width};{ProjectInfo.Settings.TopHeight};";
            int n = SEARCH_PRODUCTS(fanString, ref bufferIDs);
            var str = bufferIDs.ToString();            
            var splitstring = str.Split(new[] { ";0;", ";-5;"  }, StringSplitOptions.RemoveEmptyEntries);            
            for (int i = 0; i < splitstring.Length; i++)
            {
                var OUTIDs = splitstring[i].Split(new[] { ";" }, StringSplitOptions.RemoveEmptyEntries)[0];
                yield return OUTIDs;
            }
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