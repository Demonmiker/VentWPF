using System.Collections.Generic;

namespace VentWPF.ViewModel
{
    /// <summary>
    /// Шумаглушитель с выравниванием
    /// </summary>
    internal class Muffler_Corrector : Muffler
    {
        #region Constructors

        public Muffler_Corrector()
        {
            image = "Mufflers/Muffler_Corrector.png";
        }

        #endregion

        #region Properties

        public override string Name => "Шумоглушитель с выравниванием";

        protected override List<string> InfoProperties => new()
        {
            "FC",
        };

        #endregion
    }
}