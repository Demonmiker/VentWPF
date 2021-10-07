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

        public Heater_Gas()
        {
            image = "Heaters/Heater_Gas.png";
        }

        public override string Name => "Нагреватель газовый";

        /// <summary>
        /// Тип горелки
        /// </summary>
        [Category(Data)]
        [DisplayName("Горелка")]
        public TorchType Torch { get; set; }

        [Browsable(false)]
        public override List<string> InfoProperties => new()
        {
            "Performance",
            "TempIn",
            "TempOut",
            "torch",
        };

    }
}