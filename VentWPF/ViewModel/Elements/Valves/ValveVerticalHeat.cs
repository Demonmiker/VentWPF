﻿using PropertyTools.DataAnnotations;
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
        public ValveVerticalHeat()
        {
<<<<<<< HEAD:VentWPF/ViewModel/Elements/Valves/Valve_Ver_Heat.cs
            image = "Valves/Valve_Ver_Heat.png";
        }

        public override void UpdateQuery()
        {
=======
>>>>>>> ptb-update:VentWPF/ViewModel/Elements/Valves/ValveVerticalHeat.cs
            DeviceType = typeof(Тэны);
            Query = new DatabaseQuery<Тэны>
            {
                Source = from o in VentContext.Instance.Tэныs select o,
            };
        }

        public override string Image => ImagePath("Valves/VerticalHeat");

        public override int Length => 125;

        public override string Name => $"Клапан воздушный утеплённый вертикальный {(DeviceData as Тэны)?.Маркировка}";

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