using PropertyTools.DataAnnotations;

namespace VentWPF.ViewModel
{
    internal class Valve_Hor_Heat : Valve
    {
        public Valve_Hor_Heat()
        {
            Name = "Воздушный клапан горизонтальный с нагревателем";
            image = "Valves/Valve_Hor_Heat.png";
        }

        [Category(Data)]
        [DisplayName("Количество ТЭНов")]
        public int TEN_count { get; set; } = 3;
    }
}