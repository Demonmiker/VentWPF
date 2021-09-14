using PropertyTools.DataAnnotations;
using static VentWPF.ViewModel.Strings;

namespace VentWPF.ViewModel
{
    /// <summary>
    /// Общий класс Клапан
    /// </summary>
    internal abstract class Valve : Element
    {
        public Valve()
        {
            image = "Valves/Valve_Hor.png";
            ShowPR = true;
            ShowPD = true;
        }

        protected override float GeneratedPressureDrop => 15;

    }
}