using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;


namespace VentWPF.Fans.Nicotra
{
    class NICOTRAController : IController<NICOTRARequest, List<NICOTRAFanData>>
    {
        [DllImport(@"C:\Users\stig1\source\repos\3type\3type\bin\x86\Nicotra.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern int GET_CALCULATION_FANALONE(short s1, short s2, double[] IN, string KEY, short z1, short z2, double[] OUT);

        [DllImport(@"C:\Users\stig1\source\repos\3type\3type\bin\x86\Nicotra.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public static extern int GET_PRODUCTS([MarshalAsAttribute(UnmanagedType.VBByRefStr)] ref string LIST);



        public List<NICOTRAFanData> GetResponce(NICOTRARequest request)
        {            
            var ids = GetIDs();
            List<NICOTRAFanData> res = new();
            foreach (var id in ids)
            {
                var list = GetFanInfo(id, request);
                NICOTRAFanData data = new NICOTRAFanData(id, list);
                res.Add(data);
            }
            return res;
        }

        public IEnumerable<string> GetIDs()
        {
            var bufferIDs = new string(new Char(), 30000);
            int n = GET_PRODUCTS(ref bufferIDs);
            var str = bufferIDs.ToString();
            return str.Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries).Where(x => !x.StartsWith("K3G")); //исправить
        }

        public IEnumerable<string> GetFanInfo(string id, NICOTRARequest req)
        {
            req.ID = id;
            var bufferInfo = new string(new Char(), 4000);
            var r = req.GetRequest();

            var KEY = new string(new Char(), 15);
            KEY = "AT 7-7 S";
            double[] IN =
            {
                1, 1, 0, 24, 5, 600, 100, 150, 0, 0, 0, 0, 0
            };
            short s1 = 0;
            short s2 = 0;
            short z1 = 0;
            short z2 = 0;
            double[] OUT = new double[31];
            foreach (int i in OUT)
            {
                OUT[i] = 0;
            }

            GET_CALCULATION_FANALONE(s1, s2, IN, KEY, z1, z2, OUT);
            return bufferInfo.Split(new[] { ';' });
        }

        void test()
        {
            
                        

             
            int e = GET_CALCULATION_FANALONE(s1, s2, IN, KEY, z1, z2, OUT);
        }

    }
}
