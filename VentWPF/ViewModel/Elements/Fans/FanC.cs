using System.Collections.Generic;
using VentWPF.Fans.FanSelect;
using PropertyTools.DataAnnotations;
using VentWPF.Fans;
using VentWPF.Model.Calculations;
using PropertyChanged;
using static VentWPF.ViewModel.Strings;

namespace VentWPF.ViewModel
{
    internal class FanC : Fan
    {
        public override void UpdateQuery()
        {
            DeviceType = typeof(FanCData);
            Query = new FanCQuery()
            {
                Source = new FanCRequest()
                {
                    InsertGeoData = true,
                    InsertMotorData = true,
                    InsertNominalValues = true,
                    Language = "RU",
                    //TODO: Безопасность на высшем уровне
                    Password = "bnexg5",
                    Username = "ZAFS19946",
                    InstHeight = ProjectInfo.Height,
                    InstWidth = ProjectInfo.Width,
                    //TODO: GPD
                    PressureDrop = Calculations.GPD(Project.Grid.InTopRow(this)) + ProjectInfo.PFlow,
                    SearchTolerance = 10,
                    UnitSystem = "m",
                    Voltage = Voltage, // TODO Не динамично нельзя будет изменить
                    VFlow = ProjectInfo.VFlow,
                    FanType = "ER"
                }
            };
        }
        //TODO надо enum на выбор вольтажа (в скобках)
        [Category(Data)]
        [FormatString(fm3Ph)]
        [DisplayName("Вольтаж (230/460)")]
        public int Voltage { get; set; } = 230;


        public override int Width => (int)((DeviceData as FanCData)?.INSTALLATION_WIDTH_MM ?? 0);

        public override int Height => (int)((DeviceData as FanCData)?.INSTALLATION_HEIGHT_MM ?? 0);

        public override int Length => (int)((DeviceData as FanCData)?.INSTALLATION_LENGTH_MM ?? 0);

        [DependsOn(nameof(DeviceData))]
        public override string Name => $"Вентилятор {(DeviceData as FanCData)?.ARTICLE_NO}";

        public override string Image => ImagePath($"FanC/{Direction}");

        public override List<string> InfoProperties => new()
        {
            "DeviceData.TYPE",
            "Power",
            "PressureDropSystem",
            "PressureRaise",            
            "DeviceData.ZA_N",
            "DeviceData.POWER_OUTPUT_HP",
            "DeviceData.POWER_CALC_KW",            
            "DeviceData.ZA_NMAX",
            "DeviceData.ZA_PD",
            "DeviceData.ZA_PF",
            "DeviceData.ZA_ETAF_L",            
            "DeviceData.ZA_LW6",
            "DeviceData.MAX_FREQUENCY",
            "DeviceData.NOMINAL_FREQUENCY",
            "DeviceData.ZA_UN",
        };
    }
}