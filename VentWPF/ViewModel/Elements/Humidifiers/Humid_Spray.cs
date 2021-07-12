using PropertyTools.DataAnnotations; using static VentWPF.ViewModel.Strings;

namespace VentWPF.ViewModel
{
    internal class Humid_Spray : Humid
    {
        public Humid_Spray()
        {
            image = "Humidifiers/Humid_Spray.png";
        }

        public override string Name => "Увлажнитель форсуночный";


    }
}