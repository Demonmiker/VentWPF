using PropertyTools.DataAnnotations;

namespace VentWPF.ViewModel
{
    internal class Valve_Ver_Heat : Valve
    {
        public Valve_Ver_Heat()
        {
            Name = "Воздушный клапан вертикальный с нагревателем";
            image = "Valves/Valve_Ver_Heat.png";
        }

        [Category(Data)]
        [DisplayName("Количество ТЭНов")]
        public int TEN_count { get; set; } = 3;
    }
}