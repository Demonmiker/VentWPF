namespace VentWPF.ViewModel
{
    /// <summary>
    /// Клапан воздушный вертикальный
    /// </summary>
    internal class Valve_Ver : Valve
    {
        #region Constructors

        public Valve_Ver()
        {
            image = "Valves/Valve_Ver.png";
        }

        #endregion

        #region Properties

        public override string Name => "Клапан воздушный вертикальный";

        #endregion

    }
}