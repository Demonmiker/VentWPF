using PropertyTools.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using VentWPF.ViewModel;
using static VentWPF.ViewModel.Strings;

namespace VentWPF.Fans.K3G
{
    internal class FanK3GData
    {
        public FanK3GData(string id, IEnumerable<string> info)
        {
            var details = info.ToArray();
            Id = id;
            Type = details[40];
            LwASoll = details[28];
            RotateNom = details[39];
            nSoll = details[0];
            IPower = details[1];
            P1Soll = details[33];
            motorPower = details[37];
            EtaSoll = details[3];
            EtaMSoll = details[32];
            KPDAll = details[6];
            KPDImp = details[35];
            PressSum = details[26];
            PressStat = details[27];
            Noise = details[9];
            NoiseAtDP = details[30];

            IVolt = details[52];
            IPol = details[53];
            UstSoll = details[36];
            Freq = details[42];
            VoltDP = details[4];
            AmpDP = details[2];
        }
        public static ProjectInfoVM ProjectInfo { get; set; } = ProjectVM.Current?.ProjectInfo;
        
        public string Id { get; set; }

        [DisplayName("Вентилятор")]
        public string Type { get; set; }

        [DisplayName("Производительность")]
        [FormatString(fm3Ps)]
        public string LwASoll { get; set; }

        [DisplayName("Номинальные обороты")]
        [FormatString(fRotate)]
        public string RotateNom { get; set; }

        [DisplayName("Обороты колеса")]
        [FormatString(fRotate)]
        public string nSoll { get; set; } //0 n/1/min

        [DisplayName("Мощность в раб.точке")]
        [FormatString(fW)]
        public string IPower { get; set; }

        [DisplayName("Расчётная мощность")]
        [FormatString(fW)]
        public string P1Soll { get; set; } //1 Pe/W

        [DisplayName("Мощность номинальная")]
        [FormatString(fW)]
        public string motorPower { get; set; }

        [DisplayName("КПД общее")]
        [FormatString(fper)]
        public string EtaSoll { get; set; }

        [DisplayName("КПД системы в раб.точке")]
        [FormatString(fper)]
        public string EtaMSoll { get; set; }

        [DisplayName("КПД в раб.точке")]
        [FormatString(fper)]
        public string KPDAll { get; set; }

        [DisplayName("КПД лопасти")]
        [FormatString(fper)]
        public string KPDImp { get; set; }

        [DisplayName("Давление динамическое")]
        [FormatString(fPa)]
        public string PressSum { get; set; }

        [DisplayName("Давление статичное")]
        [FormatString(fPa)]
        public string PressStat { get; set; }

        [DisplayName("Шум")]
        [FormatString(fdB)]
        public string Noise { get; set; }

        [DisplayName("Шум в раб.точке")]
        [FormatString(fdB)]
        public string NoiseAtDP { get; set; }

        [DisplayName("Сеть")]
        //[FormatString(fNull)]
        public string Connect => IPol + " " + UstSoll + "V " + Freq + "Hz";

        [DisplayName("Контрольные токи в раб. точке")]
        //[FormatString(fNull)]
        public string ConnectAtDP => IPol + " " + IVolt + "V " + AmpDP + "A ";
              
        public string VoltDP { get; set; }

        public string AmpDP { get; set; }

        public string IVolt { get; set; }

        //частота сети
        public string Freq { get; set; }

        //[DisplayName("полярность")]
        //[FormatString(fNull)]
        public string IPol { get; set; } //2 I/A

        //[DisplayName("Напряжение диап")]
        //[FormatString(fV)]
        public string UstSoll { get; set; }

        
    }
}