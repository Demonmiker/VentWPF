
namespace VentWPF.Fans.Nicotra
{
    internal class NICOTRARequest : IRequest<string>
    {
        public string KEY { get; set; }

        public float Volumenstrom { get; set; } = 0;                

        public float AirDens { get; set; }

        public float Altitude { get; set; }

        public float AirTemperature { get; set; }

        public float RequiredPressure { get; set; } = 0;

        public int V { get; set; } = 0;
        
    }
}
