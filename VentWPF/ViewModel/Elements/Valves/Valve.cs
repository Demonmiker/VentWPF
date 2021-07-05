using PropertyTools.DataAnnotations; using static VentWPF.ViewModel.Strings;

namespace VentWPF.ViewModel
{
    internal abstract class Valve : Element
    {
        public Valve()
        {
            Name = "Воздушный клапан горизонтальный";
            image = "Valves/Valve_Hor.png";
            ShowPR = true;
            ShowPD = true;
        }

        

        [Category(Info)]
        #region Информация

        [DisplayName("Падение давления")]
        [FormatString(fP)]
        public override float PressureDrop => 15;

        #endregion Информация
    }
}