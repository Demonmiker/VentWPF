using PropertyTools.DataAnnotations;
using static VentWPF.ViewModel.Strings;

namespace VentWPF.Fans
{
    /// <summary>
    /// Информация по вентиляторам
    /// </summary>
    public class FanCData
    {
        public double CALC_AIR_DENSITY;

        public double CALC_ALTITUDE;

        public string CALC_LW5_OKT;

        public string CALC_LW6_OKT;

        public string CALC_LWA5_OKT;

        public string CALC_LWA6_OKT;

        public double CALC_N_RATED;

        //public string MOTOR_IE_CLASS { get; set; }
        public double CALC_NOZZLE_PRESSURE;

        public double CALC_PSYS_MAX;

        public string CAPACITOR_CAPACITANCE;

        public string CAPACITOR_VOLTAGE;

        public string CHART_VIEWER_URL;

        public string CIRCUIT;

        public string COSPHI;

        public string CURRENT_PHASE;

        public string DENSITY_INFLUENCE;

        public string DRAWING_FILE;

        public string EC_TYPE;

        public string EFFICIENCY_STAT;

        public string EFFICIENCY_TOT;

        public string ERP_CLASS;

        public string GRILL_INFLUENCE;

        public string INCREASE_OF_CURRENT;

        public string IS_EC;

        public double KFACTOR;

        public string MAX_CURRENT;

        public string MAX_FREQUENCY;

        public string MAX_TEMPERATURE_C;

        public string MAX_VOLTAGE;

        public string MIN_CURRENT;

        public string MIN_PSF;

        public string MIN_TEMPERATURE_C;

        public string MIN_VOLTAGE;

        public string NOMINAL_CURRENT;

        public double NOMINAL_FREQUENCY;

        public double NOMINAL_SPEED;

        public string NOMINAL_VOLTAGE;

        public string NOZZLE_GUARD;

        public string PHASE_DIFFERENCE;

        public string POWER_INPUT_HP;

        public string POWER_INPUT_KW;

        public string POWER_OUTPUT_KW;

        public string PRODUCT_IMG;

        public string PROTECTION_CLASS_IP;

        public string PROTECTION_CLASS_THCL;

        public string VOLTAGE_TOLERANCE;

        public string ZA_ERPKONFTEXT;

        public double ZA_ETAF;

        public double ZA_ETAF_L_MAINS_OPERATD;

        public double ZA_ETAF_SYS;

        public double ZA_ETAF_SYS_MAINS_OPERATED;

        public double ZA_ETAM;

        public double ZA_ETASF;

        public double ZA_ETASF_L;

        public double ZA_ETASF_L_MAINS_OPERATED;

        public double ZA_ETASF_SYS;

        public double ZA_ETASF_SYS_MAINS_OPERATED;

        public double ZA_I;

        public double ZA_LW5;

        public double ZA_LWA5;

        public double ZA_LWA6;

        public double ZA_PF_MAINS_OPERATED;

        public double ZA_PSF;

        public double ZA_PSF_MAINS_OPERATED;

        public double ZA_PSYS;

        public double ZA_QV;

        public double ZA_QV_MAINS_OPERATED;

        public double ZA_SFP;

        public string ZA_SFP_CLASS;

        public double ZA_U;

        public double ZA_WEIGHT;


        public int INDEX { get; set; }

        //[DisplayName("ID")]
        public string ARTICLE_NO { get; set; }

        [DisplayName("Тип")]
        public string TYPE { get; set; }

        [DisplayName("Мощность")]
        [FormatString(fkW)]
        public double POWER_OUTPUT_HP { get; set; }

        [DisplayName("Разница оборотов")]
        [FormatString(f2)]
        public double NDiff => ZA_NMAX - ZA_N;

        [DisplayName("Обороты колеса")]
        [FormatString(fRotate)]
        public double ZA_N { get; set; }

        [DisplayName("Номинальные обороты")]
        [FormatString(fRotate)]
        public double ZA_NMAX { get; set; }

        [DisplayName("Динамическое сопротивление")]
        [FormatString(fPa)]
        public double ZA_PD { get; set; }

        [DisplayName("Суммарное сопротивление")]
        [FormatString(fPa)]
        public double ZA_PF { get; set; }

        [DisplayName("КПД")]
        [FormatString(fper)]
        public double ZA_ETAF_L { get; set; }

        [DisplayName("Сеть")]
        [FormatString(fHzFS)]
        public double ZA_FBP { get; set; }

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
    }
}