namespace VentWPF.ViewModel
{
    internal class Valve_Ver : HasPerformance
    {
        public Valve_Ver()
        {
            Name = "Воздушный клапан вертикальный";
            image = "Valves/Valve_Ver.png";
        }

        public override float Performance => 15;
    }
}