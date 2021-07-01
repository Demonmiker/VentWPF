using PropertyTools.DataAnnotations;

namespace VentWPF.ViewModel
{
    internal class Valve_Ver_Heat : HasPerformance
    {
        public Valve_Ver_Heat()
        {
            Name = "Воздушный клапан вертикальный с нагревателем";
            image = "Valves/Valve_Ver_Heat.png";
        }

        //public override float Performance => 15;

        [DisplayName("Количество ТЭНов")]
        [Category(c1), PropertyOrder(2)]
        public float TEN_count { get; set; } = 3;
    }
}