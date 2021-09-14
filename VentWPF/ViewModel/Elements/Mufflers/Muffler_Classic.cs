using System.Collections.Generic;

namespace VentWPF.ViewModel
{
    /// <summary>
    /// Шумоглушитель
    /// </summary>
    internal class Muffler_Classic : Muffler
    {
        #region Constructors

        public Muffler_Classic()
        {
            image = "Mufflers/Muffler.png";
        }

        #endregion

        #region Properties

        public override string Name => "Шумоглушитель";

        protected override List<string> InfoProperties => new()
        {
            "FC",
        };

        #endregion
    }
}