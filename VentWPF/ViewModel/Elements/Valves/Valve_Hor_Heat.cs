using PropertyTools.DataAnnotations;

namespace VentWPF.ViewModel
{
    internal class Valve_Hor_Heat : HasPerformance
    {
        public Valve_Hor_Heat()
        {
            Name = "Воздушный клапан горизонтальный с нагревателем";
            image = "Valves/Valve_Hor_Heat.png";
        }

        //public override float Performance => 15;

        [DisplayName("Количество ТЭНов")]
        
        public float TEN_count { get; set; } = 3;
    }
}