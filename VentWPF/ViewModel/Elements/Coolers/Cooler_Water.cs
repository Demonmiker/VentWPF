using PropertyChanged;
using PropertyTools.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using static VentWPF.ViewModel.Strings;

namespace VentWPF.ViewModel
{
    /// <summary>
    /// Представление Охладитель жидкостный
    /// </summary>
    internal class Cooler_Water : Cooler
    {
        public Cooler_Water()
        {
            image = "Coolers/Cooler_Water.png";
        }

        public override void UpdateQuery()
        {
            DeviceType = typeof(ВодаХолод);
            Query = new DatabaseQuery<ВодаХолод>
            {
                Source = from o in VentContext.Instance.ВодаХолодs select o
            };
        }

        public override int Length => 500;

        [DependsOn(nameof(DeviceData))]
        public override string Name => $"Охладитель жидкостный {(DeviceData as ВодаХолод)?.Типоряд}";

        /// <summary>
        /// Температура теплоносителя в начале
        /// </summary>
        [Category(Data)]
        [DisplayName("т. теплоносителя нач.")]
        public float TempBegin => 7;

        /// <summary>
        /// Температура теплоносителя в конце
        /// </summary>
        [DisplayName("т. теплоносителя кон.")]
        public float TempEnd => 12;

        /// <summary>
        /// Расход теплоносителя
        /// </summary>
        [Category(Info)]
        [Browsable(false)]
        [DisplayName("Расход теплоносителя")]
        [FormatString(MasFr)]
        public float Consumption => (float)(Power * 1000 / (4198 * Math.Abs(TempBegin - TempEnd))) * 3600;

        public override List<string> InfoProperties => new()
        {
            "TempIn",
            "TempOut",
            "TempBegin",
            "TempEnd",
            "HumidityIn",
            "Power",
            "HumidOutAbs",
            "HumidOutRel",
            "DeviceData.LВозд",
            "DeviceData.NКвт",
            "DeviceData.Скорость",
            "DeviceData.ВысотаГабарит",
            "DeviceData.ШиринаГабарит",
            "Fr",
        };
    }
}