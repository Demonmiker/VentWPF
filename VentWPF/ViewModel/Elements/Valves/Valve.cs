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

        public override float GeneratedPressureDrop => 15;

        //[Category(Data)]

        #region Данные

        #endregion Данные

        //[Category(Info)]

        #region Информация

        
        

        #endregion Информация
    }
}