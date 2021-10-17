﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;


namespace VentWPF.Fans.Nicotra
{
    class NICOTRAController : IController<NICOTRARequest, List<NICOTRAFanData>>
    {
        //Получение расчёта по одному вентилятору
        [DllImport(@"C:\Users\stig1\source\repos\3type\3type\bin\x86\Nicotra.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern int GET_CALCULATION_FANALONE(short s1, short s2, double[] IN, string KEY, short z1, short z2, double[] OUT);

        //получения списка вентиляторов
        [DllImport(@"C:\Users\stig1\source\repos\3type\3type\bin\x86\Nicotra.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public static extern int GET_PRODUCTS([MarshalAsAttribute(UnmanagedType.VBByRefStr)] ref string LIST);



        public List<NICOTRAFanData> GetResponce(NICOTRARequest request)
        {
            var KEY = GetKEYs();
            List<NICOTRAFanData> res = new();
            foreach (var id in KEY)
            {
                var list = GetFanInfo(id, request);
                NICOTRAFanData data = new NICOTRAFanData(id, list);
                res.Add(data);
            }
            return res;
        }

        public IEnumerable<string> GetKEYs()
        {
            var bufferIDs = new string(new Char(), 30000);
            int n = GET_PRODUCTS(ref bufferIDs);
            var str = bufferIDs.ToString();
            return str.Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries).Where(x => !x.StartsWith("K3G")); //исправить
        }

        public IEnumerable<string> GetFanInfo(string id, NICOTRARequest req)
        {
            var bufferInfo = new string(new Char(), 4000);
            var r = req.GetRequest();

            //временные данные----------
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
            //временные данные конец-------

            GET_CALCULATION_FANALONE(s1, s2, IN, KEY, z1, z2, OUT);
            return bufferInfo.Split(new[] { ';' });
        }
    }
}

/*
 Справка по Nicotra данным:
GET_CALCULATION_FANALONE:
s1, s2, z1, z2 -не используются, значения могут быть любыми - на вычисления не влияют. Желательно оставлять 0
IN - массив double из входных параметров
KEY - string имя-ключ вентилятора (подобие ID в K3G)
OUT - выходные параметры массив double, после запроса массив OUT меняется
P.S. все имена даны согласно документации

GET_PRODUCTS возвращает строку вида:

NICOTRA\r\n
AT 7-7 S,600303,Fan with forward-curved wheel\r\n
AT 9-7 S,600306,Fan with forward-curved wheel\r\n
AT 9-9 S,600308,Fan with forward-curved wheel\r\n
AT 10-8 S,600312,Fan with forward-curved wheel\r\n
AT 10-10 S,600314,Fan with forward-curved wheel\r\n
AT 12-9 S,600318,Fan with forward-curved wheel\r\n
...
!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
Нужны будут не все вентидляторы, только RDH, ADH, возможно ещё какие-то, не отвечают какие именно. Надо придумать как учитывать этот момент
и не просчитывать ненужные
!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!


Расшифровка:
AT 7-7 S - имя, оно же KEY
600303 - кодовый номер (назначение неизвестно, предположительно - номер в каталоге)
Fan with forward-curved wheel - краткое описание

 */
