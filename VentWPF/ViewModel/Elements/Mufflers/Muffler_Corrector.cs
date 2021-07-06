using PropertyTools.DataAnnotations; using static VentWPF.ViewModel.Strings;
using VentWPF.Model;

namespace VentWPF.ViewModel
{
    internal class Muffler_Corrector : Muffler
    {
        public Muffler_Corrector()
        {
            Name = "Шумоглушитель с выравниванием";
            image = "Mufflers/Muffler_Corrector.png";
        }

        
    }
}