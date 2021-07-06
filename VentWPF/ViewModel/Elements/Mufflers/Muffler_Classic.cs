using PropertyTools.DataAnnotations; using static VentWPF.ViewModel.Strings;
using VentWPF.Model;

namespace VentWPF.ViewModel
{
    internal class Muffler_Classic : Muffler
    {
        public Muffler_Classic()
        {
            Name = "Шумоглушитель";
            image = "Mufflers/Muffler.png";
        }
   
    }
}