using System.Collections.Generic;

namespace VentWPF.ViewModel
{
    /// <summary>
    /// Шумоглушитель
    /// </summary>
    internal class Muffler_Classic : Muffler
    {

        public Muffler_Classic()
        {
            image = "Mufflers/Muffler.png";
        }

        public override string Name => "Шумоглушитель";

        protected override List<string> InfoProperties => new()
        {
            "FC",
        };

    }
}