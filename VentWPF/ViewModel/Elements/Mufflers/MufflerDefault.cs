using System.Collections.Generic;
using PropertyTools.DataAnnotations;

namespace VentWPF.ViewModel
{
    /// <summary>
    /// Шумоглушитель
    /// </summary>
    internal class MufflerDefault : Muffler
    {
        public MufflerDefault()
        {
        }

        public override string Image => ImagePath("Mufflers/Default");

        public override string Name => "Шумоглушитель";
    }
}