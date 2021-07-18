using PropertyTools.DataAnnotations; using static VentWPF.ViewModel.Strings;
using VentWPF.Model;

namespace VentWPF.ViewModel
{
    internal abstract class Muffler : Element
    {
        public Muffler()
        {
            image = "Mufflers/Muffler.png";
            ShowPR = true;
            ShowPD = true;
        }

        public override float GeneratedPressureDrop => FC switch
        {
            Section.секция500 => 25,
            Section.секция1000 => 55,
            _ => 60,
        };

        [Category(Data)]
        #region Данные

        [DisplayName("Длинна секции")]
        
        public Section FC { get; set; }

        #endregion Данные

        //[Category(Info)]
        #region Информация

       
      
        #endregion Информация
    }
}