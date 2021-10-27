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
        }

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