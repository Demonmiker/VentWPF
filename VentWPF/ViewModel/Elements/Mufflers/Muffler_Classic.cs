using PropertyTools.DataAnnotations; using static VentWPF.ViewModel.Strings;
using VentWPF.Model;

namespace VentWPF.ViewModel
{
    internal class Muffler_Classic : Muffler
    {
        public Muffler_Classic()
        {
            image = "Mufflers/Muffler.png";
        }

        public override string Name => "Шумоглушитель";

    }
}