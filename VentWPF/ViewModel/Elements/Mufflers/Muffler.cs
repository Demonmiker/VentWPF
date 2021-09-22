using PropertyTools.DataAnnotations;
using VentWPF.Model;
using static VentWPF.ViewModel.Strings;

namespace VentWPF.ViewModel
{
    /// <summary>
    /// Общий класс шумоглушитель
    /// </summary>
    internal abstract class Muffler : Element
    {
        #region Constructors

        public Muffler()
        {
            image = "Mufflers/Muffler.png";
            ShowPR = true;
            ShowPD = true;
        }

        #endregion

        #region Properties

        [Category(Data)]
        [DisplayName("Длинна секции")]
        public Section FC { get; set; }

        protected override float GeneratedPressureDrop => FC switch
        {
            Section.секция500 => 25,
            Section.секция1000 => 55,
            _ => 60,
        };

        #endregion
    }
}