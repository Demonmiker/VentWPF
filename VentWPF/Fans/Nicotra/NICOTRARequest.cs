
namespace VentWPF.Fans.Nicotra
{
    internal class NICOTRARequest : IRequest<string>
    {
        public string KEY { get; set; }

        public double Option { get; set; } = 1; //1 - Air volume and static pressure 2 - Air volume and total pressure

        public double InstType { get; set; } = 1; // 1 - free inlet free outlet  2 - free inlet ducted outlet 

        public double AirDensity { get; set; } = 0; //0 - расчёт от высоты и температуры

        public double AirTemperature { get; set; } = 24; //температура

        public double Height { get; set; } = 1; //высота в метрах

        public double FlowRate { get; set; } = 600; //VFlow

        public double StaticPressure { get; set; } = 100; //Статическое сопр давления

        public double TotalPressure { get; set; } = 150; //Тотальное(?)

        public double Speed { get; set; } = 0; //оставить 0

        public double ShaftPower { get; set; } = 0; //оставить 0

        public double Efficiency { get; set; } = 0;//оставить 0

        public double SoundPowerLevel { get; set; } = 0;//оставить 0

        public double PowerCorrection { get; set; } = 0;  //оставить 0     

    }
}
