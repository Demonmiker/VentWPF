using PropertyTools.DataAnnotations;
using System;
using static VentWPF.ViewModel.Strings;

namespace VentWPF.Fans
{
    /// <summary>
    /// Информация по вентиляторам
    /// </summary>
    public class FanCData : IEquatable<FanCData>
    {
        public int CALC_PL_MAX { get; set; }

        //[DisplayName("ID")]
        public string ARTICLE_NO { get; set; }

        [DisplayName("Тип")]
        public string TYPE { get; set; }

        [DisplayName("Номинальная мощность")]
        [FormatString(fkW)]
        public double POWER_OUTPUT_KW { get; set; }

        [DisplayName("Механическая мощность")]
        [FormatString(fkW)]
        public double POWER_CALC_KW => CALC_PL_MAX / 1000f;

        [DisplayName("Разница оборотов")]
        [FormatString(f2)]
        public double NDiff => Convert.ToDouble(NOMINAL_SPEED) - ZA_N;

        [DisplayName("Обороты колеса")]
        [FormatString(fRotate)]
        public double ZA_N { get; set; }

        [DisplayName("Номинальные обороты")]
        [FormatString(fRotate)]
        public string NOMINAL_SPEED { get; set; }

        [DisplayName("Частота номинальная")]
        [FormatString(fHz)]
        public string NOMINAL_FREQUENCY { get; set; }

        [DisplayName("Частота расчетная")]
        [FormatString(fHz)]
        public int MAX_FREQUENCY { get; set; }

        [DisplayName("Сеть")]
        [FormatString(fFS)]
        public int ZA_UN { get; set; }

        [DisplayName("Динамическое сопротивление")]
        [FormatString(fPa)]
        public double ZA_PD { get; set; }

        [DisplayName("Суммарное сопротивление")]
        [FormatString(fPa)]
        public double ZA_PF { get; set; }

        [DisplayName("КПД")]
        [FormatString(fper)]
        public double ZA_ETAF_L { get; set; }

        [DisplayName("Шум на выходе дБ")]
        [FormatString(fdB)]
        public double ZA_LW6 { get; set; }

        [DisplayName("Длина установки")]
        [FormatString(fmm)]
        [Browsable(false)]
        public double INSTALLATION_LENGTH_MM { get; set; }

        [DisplayName("Высота установки")]
        [FormatString(fmm)]
        [Browsable(false)]
        public double INSTALLATION_HEIGHT_MM { get; set; }

        [DisplayName("Ширина установки")]
        [FormatString(fmm)]
        [Browsable(false)]
        public double INSTALLATION_WIDTH_MM { get; set; }

        [DisplayName("Размер")]
        [FormatString(fmm)]
        public double ZA_BG { get; set; }

        public string ZA_MAINS_SUPPLY { get; set; }

        [DisplayName("Колесо")]
        [Browsable(false)]
        public string FANNAME { get; set; }

        public bool Equals(FanCData other)
        {
            if (
                 CALC_PL_MAX == other.CALC_PL_MAX &&
                 ARTICLE_NO == other.ARTICLE_NO &&
                 TYPE == other.TYPE &&
                 POWER_OUTPUT_KW == other.POWER_OUTPUT_KW &&
                 ZA_N == other.ZA_N &&
                 NOMINAL_SPEED == other.NOMINAL_SPEED &&
                 NOMINAL_FREQUENCY == other.NOMINAL_FREQUENCY &&
                 MAX_FREQUENCY == other.MAX_FREQUENCY &&
                 ZA_UN == other.ZA_UN &&
                 ZA_PD == other.ZA_PD &&
                 ZA_PF == other.ZA_PF &&
                 ZA_ETAF_L == other.ZA_ETAF_L &&
                 ZA_LW6 == other.ZA_LW6 &&
                 INSTALLATION_LENGTH_MM == other.INSTALLATION_LENGTH_MM &&
                 INSTALLATION_HEIGHT_MM == other.INSTALLATION_HEIGHT_MM &&
                 INSTALLATION_WIDTH_MM == other.INSTALLATION_WIDTH_MM &&
                 ZA_BG == other.ZA_BG &&
                 ZA_MAINS_SUPPLY == other.ZA_MAINS_SUPPLY &&
                 FANNAME == other.FANNAME)
                return true;
            else
                return false;
        }

        public override int GetHashCode()
        {
             int hash = 23;
             hash = hash * 59 + (CALC_PL_MAX.GetHashCode());
             hash = hash * 59 + (ARTICLE_NO.GetHashCode());
             hash = hash * 59 + (TYPE.GetHashCode());
             hash = hash * 59 + (POWER_OUTPUT_KW.GetHashCode());
             hash = hash * 59 + (ZA_N.GetHashCode());
             hash = hash * 59 + (NOMINAL_SPEED.GetHashCode());
             hash = hash * 59 + (NOMINAL_FREQUENCY.GetHashCode());
             hash = hash * 59 + (MAX_FREQUENCY.GetHashCode());
             hash = hash * 59 + (ZA_UN.GetHashCode());
             hash = hash * 59 + (ZA_PD.GetHashCode());
             hash = hash * 59 + (ZA_PF.GetHashCode());
             hash = hash * 59 + (ZA_ETAF_L.GetHashCode());
             hash = hash * 59 + (ZA_LW6.GetHashCode());
             hash = hash * 59 + (INSTALLATION_LENGTH_MM.GetHashCode());
             hash = hash * 59 + (INSTALLATION_HEIGHT_MM.GetHashCode());
             hash = hash * 59 + (INSTALLATION_WIDTH_MM.GetHashCode());
             hash = hash * 59 + (ZA_BG.GetHashCode());
             hash = hash * 59 + (ZA_MAINS_SUPPLY.GetHashCode());
             //hash = hash * 59 + (FANNAME.GetHashCode());
            return hash;
        }


    }
}