using PropertyTools.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using static VentWPF.ViewModel.Strings;

namespace VentWPF.ViewModel
{
    /// <summary>
    /// Клапан воздушный утеплённый
    /// </summary>
    internal class Valve_Hor_Heat : Valve
    {
        #region Constructors

        public Valve_Hor_Heat()
        {
            image = "Valves/Valve_Hor_Heat.png";
            Query = new DatabaseQuery<Тэны>
            {
                Source = from o in VentContext.Instance.Tэныs select o
            };
        }

        #endregion

        #region Properties

        public override string Name => $"Клапан воздушный утеплённый горизонтальный {(DeviceData as Тэны)?.Маркировка}";

        protected override List<string> InfoProperties => new()
        {
            "DeviceData.Маркировка",
            "DeviceData.КолВоПоШирине",
            "TEN_count",
        };

        #region Данные
        /// <summary>
        /// Количество нагревателей
        /// </summary>
        [Category(Data)]
        [DisplayName("Количество ТЭНов")]
        public int TEN_count { get; set; } = 3;

      
        #endregion

        #endregion
    }
}