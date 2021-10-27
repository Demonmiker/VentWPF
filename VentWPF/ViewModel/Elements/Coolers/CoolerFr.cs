using PropertyChanged;
using PropertyTools.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using VentWPF.Model;
using static VentWPF.ViewModel.Strings;

namespace VentWPF.ViewModel
{
    /// <summary>
    /// Представление Охладитель фреоновый
    /// </summary>
    internal class CoolerFr : Cooler
    {
        public CoolerFr()
        {
<<<<<<< HEAD:VentWPF/ViewModel/Elements/Coolers/Cooler_Fr.cs
            image = "Coolers/Cooler_Fr.png";
        }

        public override void UpdateQuery()
        {
=======
>>>>>>> ptb-update:VentWPF/ViewModel/Elements/Coolers/CoolerFr.cs
            DeviceType = typeof(ФреонХолод);
            Query = new DatabaseQuery<ФреонХолод>
            {
                Source = from o in VentContext.Instance.ФреонХолодs select o
            };
        }

<<<<<<< HEAD:VentWPF/ViewModel/Elements/Coolers/Cooler_Fr.cs
        public override int Width => (int)((DeviceData as ФреонХолод)?.ШиринаГабарит ?? 0);

        public override int Height => (int)((DeviceData as ФреонХолод)?.ВысотаГабарит ?? 0);
=======
        public override string Image => ImagePath("Coolers/Fr");
>>>>>>> ptb-update:VentWPF/ViewModel/Elements/Coolers/CoolerFr.cs

        public override int Length => 500;

        [DependsOn(nameof(DeviceData))]
        public override string Name => $"Фреоновый охладитель {(DeviceData as ФреонХолод)?.Типоряд}";

        /// <summary>
        /// Тип Фреона
        /// </summary>
        [Category(Data)]
        [DisplayName("Тип Фреона")]
        public FrType Fr { get; set; }

        public override List<string> InfoProperties => new()
        {
            "TempIn",
            "TempOut",
            "HumidityIn",
            "Power",
            "HumidOutAbs",
            "HumidOutRel",
            "DeviceData.LВозд",
            "DeviceData.NКвт",
            "DeviceData.Скорость",
            "DeviceData.КолВоКонтуров",
            "DeviceData.ВысотаГабарит",
            "DeviceData.ШиринаГабарит",
            "Fr",
        };
    }
}