using System.Collections.Generic;
using PropertyTools.DataAnnotations;

namespace VentWPF.ViewModel
{
    /// <summary>
    /// Шумоглушитель
    /// </summary>
    internal class Muffler_Classic : Muffler
    {
        public Muffler_Classic()
        {
        }

        public override string Name => "Шумоглушитель";
    }
}