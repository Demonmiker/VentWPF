using PropertyTools.DataAnnotations; using static VentWPF.ViewModel.Strings;
using VentWPF.Model;

namespace VentWPF.ViewModel
{
    internal abstract class Muffler : Element
    {
        public Muffler()
        {
            Name = "Шумоглушитель";
            image = "Mufflers/Muffler.png";
            ShowPR = true;
            ShowPD = true;
        }

        [Category(Data)]
        #region Данные

        [DisplayName("Длинна секции")]
        
        public Section FC { get; set; }

        #endregion Данные

        [Category(Info)]
        #region Информация

        [DisplayName("Падение давления")]

        public override float PressureDrop => FC switch
        {
            Section.секция500 => 25,
            Section.секция1000 => 55,
            _ => 60,
        };
      
        #endregion Информация
    }
}