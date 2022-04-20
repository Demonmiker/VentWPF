﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;

namespace VentWPF.Fans.Nicotra
{
    internal class FanPController : IController<FanPRequest, List<FanPData>>
    {
        #region Marshaling

#pragma warning disable CS0618
        
        /*
            string path = System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            [DllImport(@"\Fans\FanP\DLL\Nicotra.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
            public static extern int SETDLLPATH([MarshalAsAttribute(UnmanagedType.AnsiBStr)] string Path);
            
          */

        //Получение расчёта по одному вентилятору
        [DllImport(@"\Fans\FanP\DLL\Nicotra.DLL", CallingConvention = CallingConvention.StdCall)]
        public static extern int GET_CALCULATION_FANALONE(short s1, short s2, double[] IN, string KEY, short z1, short z2, double[] OUT);

        //получения списка вентиляторов
        [DllImport(@"\Fans\FanP\DLL\Nicotra.DLL", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public static extern int GET_PRODUCTS([MarshalAsAttribute(UnmanagedType.VBByRefStr)] ref string LIST);

#pragma warning restore CS0618

        #endregion

        private static string[] Keys;

        public List<FanPData> GetResponce(FanPRequest request,out string error)
        {
            error = null;
            try
            {
                Keys ??= GetKeys().ToArray();
                return Keys.Select(x => new FanPData(x, GetFanInfo(x, request))).Where(x => x.errors.Equals(0)).ToList();
            }
            catch (Exception ex)
            {
                error=ex.Message;
                return null; 
            }
        }

        public IEnumerable<string> GetKeys()
        {
            //int d = SETDLLPATH(path);
            var bufferIDs = new string(new Char(), 30000);
            int n = GET_PRODUCTS(ref bufferIDs);
            var str = bufferIDs.ToString();
            //TODO: @StiGGG тут нет проверки что выданы не модели вентиляторов а ошибка
            var lines = str.Split("\r\n");
            var keys = lines.Select(x => x.Split(',')[0]);
            keys = keys.Where(x => x.StartsWith("RDH") || x.StartsWith("ADH"));
            return keys;
        }

        public IEnumerable<double> GetFanInfo(string id, FanPRequest req)
        {            
            var r = req.GetRequest();
            short s1 = 0;
            short s2 = 0;
            short z1 = 0;
            short z2 = 0;
            double[] OUT = new double[32];
            foreach (int i in OUT)
            {
                OUT[i] = 0;
            }
            GET_CALCULATION_FANALONE(s1, s2, r, id, z1, z2, OUT);
            return OUT;
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