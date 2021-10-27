﻿using PropertyTools.DataAnnotations;
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
            DeviceType = typeof(Тэны);
            Query = new DatabaseQuery<Тэны>
            {
                Source = from o in VentContext.Instance.Tэныs select o
            };
        }

        public override string Image => ImagePath("Valves/HorizontalHeat");

        public override string Name => $"Клапан воздушный утеплённый горизонтальный {(DeviceData as Тэны)?.Маркировка}";

        /// <summary>
        /// Количество нагревателей
        /// </summary>
        [Category(Data)]
        [DisplayName("Количество ТЭНов")]
        public int TEN_count { get; set; } = 3;

        public override List<string> InfoProperties => new()
        {
            "DeviceData.Маркировка",
            "DeviceData.КолВоПоШирине",
            "TEN_count",
        };
    }
}