using PropertyTools.DataAnnotations; using static VentWPF.ViewModel.Strings;

namespace VentWPF.ViewModel
{
    internal class Humid_Cell : Humid
    {
        public Humid_Cell()
        {
            image = "Humidifiers/Humid_Cell.png";
        }

        public override string Name => "Увлажнитель сотовый";

    }
}