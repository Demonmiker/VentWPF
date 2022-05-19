using PropertyTools.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using static VentWPF.ViewModel.Strings;

namespace VentWPF.ViewModel
{
    /// <summary>
    /// Клапан воздушный утеплённый вертикальный
    /// </summary>
    internal class ValveVerticalHeat : Valve
    {
        public override void UpdateQuery()
        {
            Query = new DatabaseQuery<Тэны>
            {
                Source = from o in VentContext.Instance.Tэныs select o,
            };
        }

        public override Type DeviceType => typeof(Тэны);
        public override string Image => ImagePath("Valves/VerticalHeat");

        public override int Length => 125;

        public override string Name => $"Воздушный клапан вертикальный с нагревателем {(DeviceData as Тэны)?.Маркировка}";

        public override List<string> InfoProperties => new()
        {
            "DeviceData.Маркировка",
            "DeviceData.КолВоПоШирине",
            "TEN_count",
        };

        [Category(Data)]
        [DisplayName("Количество ТЭНов")]
        public int TEN_count { get; set; } = 3;
    }
}