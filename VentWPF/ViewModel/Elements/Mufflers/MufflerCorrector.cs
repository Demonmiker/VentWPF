using System.Collections.Generic;
using PropertyTools.DataAnnotations;

namespace VentWPF.ViewModel
{
    /// <summary>
    /// Шумаглушитель с выравниванием
    /// </summary>
    internal class MufflerCorrector : Muffler
    {
        public MufflerCorrector()
        {
        }

        public override string Image => ImagePath("Mufflers/Corrector");

        public override string Name => "Шумоглушитель с выравниванием";
    }
}