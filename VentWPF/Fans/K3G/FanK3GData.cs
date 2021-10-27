﻿using PropertyTools.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using static VentWPF.ViewModel.Strings;

namespace VentWPF.Fans.K3G
{
    public class FanK3GData
    {
        public FanK3GData(string id, IEnumerable<string> info)
        {
            var details = info.ToArray();
            Id = id;
            nSoll = details[0];
            P1Soll = details[1];
            ISoll = details[2];
            EtaSoll = details[3];
            UstSoll = details[4];
            MdSoll = details[5];
            EtaMSoll = details[6];
            LwASoll = details[7];
            LwAssSoll = details[8];
            LwAdsSoll = details[9];
            PtotSoll = details[26];
        }

        [DisplayName("ID")]
        public string Id { get; set; }

        [DisplayName("Обороты в мин.")]
        [FormatString(fRotate)]
        public string nSoll { get; set; } //0 n/1/min

        [DisplayName("Pe/W")]
        [FormatString(fNull)]
        public string P1Soll { get; set; } //1 Pe/W

        [DisplayName("I/A")]
        [FormatString(fNull)]
        public string ISoll { get; set; } //2 I/A

        [DisplayName("КПД")]
        [FormatString(fper)]
        public string EtaSoll { get; set; }//3 nu o/%

        [DisplayName("Напряжение сети")]
        [FormatString(fV)]
        public string UstSoll { get; set; }//4 Voltage

        [DisplayName("Md/Ncm")]
        [FormatString(fNull)]
        public string MdSoll { get; set; }//5 Md/Ncm

        [DisplayName("КПД мотора")]
        [FormatString(fper)]
        public string EtaMSoll { get; set; }//6  nu o/% Motor

        [DisplayName("m^3/s")]
        [FormatString(fm3Ps)]
        public string LwASoll { get; set; }//7  (in+out) m^3/s

        [DisplayName("Шум на входе")]
        [FormatString(fdB)]
        public string LwAssSoll { get; set; }//8   dB in

        [DisplayName("Шум на выходе")]
        [FormatString(fdB)]
        public string LwAdsSoll { get; set; }//9 dB Out

        #region[Noize]

        //Lwss - in N Hz Lwds - out N Hz
        public string Lwss62_5_Soll;//10

        public string Lwss125_Soll;//11

        public string Lwss250_Soll;//12

        public string Lwss500_Soll;//13

        public string Lwss1000_Soll;//14

        public string Lwss2000_Soll;//15

        public string Lwss4000_Soll;//16

        public string Lwss8000_Soll;//17

        public string Lwds62_5_Soll;//18

        public string Lwds125_Soll;//19

        public string Lwds250_Soll;//20

        public string Lwds500_Soll;//21

        public string Lwds1000_Soll;//22

        public string Lwds2000_Soll;//23

        public string Lwds4000_Soll;//24

        public string Lwds8000_Soll;//25
        #endregion

        [DisplayName("pf/Pa")]
        [FormatString(fPa)]
        public string PtotSoll { get; set; }//26 pf/Pa
    }
}