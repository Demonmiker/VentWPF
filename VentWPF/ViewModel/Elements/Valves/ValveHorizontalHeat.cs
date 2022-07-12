using PropertyTools.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using static VentWPF.ViewModel.Strings;

namespace VentWPF.ViewModel
{
    /// <summary>
    /// Клапан воздушный утеплённый
    /// </summary>
    internal class ValveHorizontalHeat : Valve
    {
        public override void UpdateQuery()
        {
            Query = new DatabaseQuery<Тэны>
            {
                Source = from o in VentContext.Instance.Tэныs select o
            };
        }

        public override Type DeviceType => typeof(Тэны);
        public override string Image => ImagePath("Valves/HorizontalHeat");

        public override string Name => $"Воздушный клапан горизонтальный с нагревателем {(DeviceData as Тэны)?.Маркировка}";

        /// <summary>
        /// Количество нагревателей
        /// </summary>
        [Category(Data)]
        [DisplayName("Количество ТЭНов")]
        public int TEN_count { get; set; } = 3;

        public override List<string> InfoProperties => new()
        {
            "cut",
            "DeviceData.Маркировка",
            "DeviceData.КолВоПоШирине",
            "TEN_count",
        };
    }
}