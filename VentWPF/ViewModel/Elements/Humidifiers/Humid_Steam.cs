using PropertyTools.DataAnnotations; using static VentWPF.ViewModel.Strings;

namespace VentWPF.ViewModel
{
    internal class Humid_Steam : Humid
    {
        public Humid_Steam()
        {
            image = "Humidifiers/Humid_Steam.png";
        }

        public override string Name => "Увлажнитель паровой";
    }
}