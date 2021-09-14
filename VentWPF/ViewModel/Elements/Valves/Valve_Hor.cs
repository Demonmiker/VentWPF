namespace VentWPF.ViewModel
{
    /// <summary>
    /// Воздушый клапан горизонтальный
    /// </summary>
    internal class Valve_Hor : Valve
    {
        #region Constructors

        public Valve_Hor()
        {
            image = "Valves/Valve_Hor.png";
        }

        #endregion

        #region Properties

        public override string Name => "Клапан воздушный горизонтальный";

        #endregion
    }
}