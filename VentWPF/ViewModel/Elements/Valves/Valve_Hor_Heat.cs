using PropertyTools.DataAnnotations; using static VentWPF.ViewModel.Strings;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using VentWPF.Model;
using VentWPF.Tools;

namespace VentWPF.ViewModel
{
    internal class Valve_Hor_Heat : Valve
    {
       
        public Valve_Hor_Heat()
        {
            image = "Valves/Valve_Hor_Heat.png";
            Query = new DatabaseQuery<Тэны>
            {
                Source = from o in VentContext.Instance.Tэныs select o
            };
        }
        public override string Name => $"Клапан воздушный утеплённый горизонтальный {(DeviceData as Тэны)?.Маркировка}";


        [Category(Data)]
        [DisplayName("Количество ТЭНов")]
        public int TEN_count { get; set; } = 3;
    }
}