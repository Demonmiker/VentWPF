using PropertyTools.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using static VentWPF.ViewModel.Strings;

namespace VentWPF.ViewModel
{
    /// <summary>
    /// Клапан воздушный утеплённый вертикальный
    /// </summary>
    internal class Valve_Ver_Heat : Valve
    {
        public Valve_Ver_Heat()
        {
            image = "Valves/Valve_Ver_Heat.png";
            DeviceType = typeof(Тэны);
            Query = new DatabaseQuery<Тэны>
            {
                Source = from o in VentContext.Instance.Tэныs select o,
            };
            Length = 125;
        }

        public override string Name => $"Клапан воздушный утеплённый вертикальный {(DeviceData as Тэны)?.Маркировка}";

        [Browsable(false)]
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