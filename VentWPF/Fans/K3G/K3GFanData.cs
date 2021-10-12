using PropertyTools.DataAnnotations;

namespace VentWPF.Fans.K3G
{
    public class K3GFanData
    {
        public string nSoll; //0 n/1/min

        public string P1Soll; //1 Pe/W

        public string ISoll; //2 I/A

        public string EtaSoll;//3 nu o/%

        public string UstSoll;//4 Voltage

        public string MdSoll;//5 Md/Ncm

        public string EtaMSoll;//6  nu o/% Motor

        public string LwASoll;//7  (in+out) m^3/s

        public string LwAssSoll;//8   dB in

        public string LwAdsSoll;//9 dB Out

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
        public string PtotSoll;//26 pf/Pa

        //TODO не содержится в ответе, но выводить нужно
        //[DisplayName("ID")]
        //public string Descripts1 { get; set; }
    }
}