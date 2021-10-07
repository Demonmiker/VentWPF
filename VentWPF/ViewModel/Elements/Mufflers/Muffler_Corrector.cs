using System.Collections.Generic;
using PropertyTools.DataAnnotations;

namespace VentWPF.ViewModel
{
    /// <summary>
    /// Шумаглушитель с выравниванием
    /// </summary>
    internal class Muffler_Corrector : Muffler
    {

        public Muffler_Corrector()
        {
            image = "Mufflers/Muffler_Corrector.png";
        }

        public override string Name => "Шумоглушитель с выравниванием";

        [Browsable(false)]
        public override List<string> InfoProperties => new()
        {
            "FC",
        };

    }
}