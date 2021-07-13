using PropertyTools.DataAnnotations;
using static VentWPF.ViewModel.Strings;

namespace VentWPF.ViewModel
{
    internal abstract class Valve : Element
    {
        public Valve()
        {
            image = "Valves/Valve_Hor.png";
            ShowPR = true;
            ShowPD = true;
        }

        public override string Name => "Воздушный клапан горизонтальный";

        [Category(Info)]

        #region Информация

        [DisplayName("Падение давления")]
        [FormatString(fkPa)]
        public override float PressureDrop => 15;

        #endregion Информация
    }
}