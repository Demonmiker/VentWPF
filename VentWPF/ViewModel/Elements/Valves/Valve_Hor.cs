namespace VentWPF.ViewModel
{
    /// <summary>
    /// Воздушый клапан горизонтальный
    /// </summary>
    internal class Valve_Hor : Valve
    {

        public Valve_Hor()
        {
            image = "Valves/Valve_Hor.png";
        }

        public override string Name => "Клапан воздушный горизонтальный";

    }
}