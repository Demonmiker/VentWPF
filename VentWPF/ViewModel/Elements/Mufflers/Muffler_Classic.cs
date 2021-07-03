using PropertyTools.DataAnnotations;
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