using PropertyTools.DataAnnotations;
using System.Collections.Generic;
using VentWPF.Model;
using static VentWPF.ViewModel.Strings;

namespace VentWPF.ViewModel
{
    /// <summary>
    /// Нагреватель газовый
    /// </summary>
    internal class HeaterGas : Heater
    {
        public HeaterGas()
        {
        }

        public override string Image => ImagePath("Heaters/Gas");

        public override int Length => 400;

        public override string Name => "Нагреватель газовый";

        /// <summary>
        /// Тип горелки
        /// </summary>
        [Category(Data)]
        [DisplayName("Горелка")]
        public TorchType Torch { get; set; }

        public override List<string> InfoProperties => new()
        {
            "Performance",
            "TempIn",
            "TempOut",
            "torch",
        };
    }
}