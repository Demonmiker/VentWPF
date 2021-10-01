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

        public Muffler()
        {
            image = "Mufflers/Muffler.png";
            ShowPR = true;
            ShowPD = true;
        }

        [Category(Data)]
        [DisplayName("Длинна секции")]
        public Section FC { get; set; }

        protected override float GeneratedPressureDrop => FC switch
        {
            Section.секция500 => 25,
            Section.секция1000 => 55,
            _ => 60,
        };

    }
}