using valid = VentWPF.Tools;
using PropertyTools.DataAnnotations;
using VentWPF.ViewModel;
using VentWPF.Model.Calculations;
namespace VentWPF.Fans.Nicotra
{
    internal class FanPRequest : IRequest<double[]>
    {
        public static ProjectInfoVM Project { get; set; } = ProjectVM.Current?.ProjectInfo;
        public double Option { get; set; } = 1; //1 - Air volume and static pressure 2 - Air volume and total pressure

        public double InstType { get; set; } = 1; // 1 - free inlet free outlet  2 - free inlet ducted outlet

        public double AirDensity { get; set; } = 0; //0 - расчёт от высоты и температуры

        public double AirTemperature { get; set; } = 24; //температура

        public double Height { get; set; } = 1; //высота в метрах

        public double FlowRate { get; set; } = Project.VFlow; //VFlow

        public double StaticPressure { get; set; } = Project.PFlow; //Статическое сопр давления

        //TODO: GPD
        public double TotalPressure { get; set; } //Тотальное(?)

        public double Speed { get; set; } = 0; //оставить 0

        public double ShaftPower { get; set; } = 0; //оставить 0

        public double Efficiency { get; set; } = 0;//оставить 0

        public double SoundPowerLevel { get; set; } = 0;//оставить 0

        public double PowerCorrection { get; set; } = 0;  //оставить 0

        //
        public double[] GetRequest()
        {
            double[] IN =
            {
                Option, InstType, AirDensity,
                AirTemperature, Height, FlowRate,
                StaticPressure, TotalPressure, Speed,
                ShaftPower, Efficiency, SoundPowerLevel,
                PowerCorrection
            };
            return IN;
        }
    }
}

/* порядок в массиве IN[]:

Option
InstType
AirDensity
AirTemperature
Height
FlowRate
StaticPressure
TotalPressure
Speed
ShaftPower
Efficiency
SoundPowerLevel
PowerCorrection

*/