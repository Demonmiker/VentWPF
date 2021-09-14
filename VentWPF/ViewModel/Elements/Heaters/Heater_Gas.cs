using PropertyTools.DataAnnotations;
using System.Collections.Generic;
using VentWPF.Model;
using static VentWPF.ViewModel.Strings;

namespace VentWPF.ViewModel
{
    /// <summary>
    /// Нагреватель газовый
    /// </summary>
    internal class Heater_Gas : Heater
    {
        #region Constructors

        public Heater_Gas()
        {
            image = "Heaters/Heater_Gas.png";
        }

        #endregion

        #region Properties

        public override string Name => "Нагреватель газовый";

        protected override List<string> InfoProperties => new()
        {
            "Performance",
            "TempIn",
            "TempOut",
            "torch",
        };

        #region Данные

        /// <summary>
        /// Тип горелки
        /// </summary>
        [Category(Data)]
        [DisplayName("Горелка")]
        public TorchType Torch { get; set; }

        #endregion Данные

        #endregion
    }
}