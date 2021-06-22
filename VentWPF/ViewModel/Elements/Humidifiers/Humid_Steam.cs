using PropertyTools.DataAnnotations;

namespace VentWPF.ViewModel
{
    internal class Humid_Steam : HasPerformance
    {
        public Humid_Steam()
        {
            Name = "Увлажнитель паровой";
        }

        [DisplayName("Влажность на входе")]
        [Category(c1), PropertyOrder(2)]
        public float AirSoftIn { get; set; } = (float)0.000;

        [DisplayName("Влажность на выходе")]
        [Category(c1), PropertyOrder(3)]
        public float AirSoftOut { get; set; } = (float)0.0015;

        [DisplayName("Расход воды")]
        [Category(c2), PropertyOrder(1)]
        public float Qv => (float)(Performance * 1.17 * (((float)AirSoftOut - (float)AirSoftIn)));
    }
}