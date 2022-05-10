using System.Collections.Generic;
using VentWPF.Fans.FanSelect;
using PropertyTools.DataAnnotations;
using VentWPF.Fans;
using VentWPF.Model.Calculations;
using VentWPF.Model;
using PropertyChanged;
using static VentWPF.ViewModel.Strings;
using System;

namespace VentWPF.ViewModel
{
    internal class FanC : Fan
    {
        public override void UpdateQuery()
        {
            Query = new FanCQuery()
            {
                Source = new FanCRequest()
                {
                    InsertGeoData = true,
                    InsertMotorData = true,
                    InsertNominalValues = true,
                    Language = "RU",
                    Password = "bnexg5",
                    Username = "ZAFS19946",
                    PressureDrop = Calculations.GPD(Project.Grid.InTopRow(this)) + ProjectInfo.Settings.PFlow,
                    SearchTolerance = 10,
                    UnitSystem = "m",
                    Voltage = (int)Voltage,
                    VFlow = ProjectInfo.Settings.VFlow,
                    Freq = Freq,
                    Spec = "PF_57",
                    FanType = FanType,
                }
            };
        }

        public override Type DeviceType => typeof(FanCData);

        [Category(Data)]
        [FormatString(fm3Ph)]
        [DisplayName("Вольтаж")]
        public VoltageType Voltage { get; set; } = VoltageType.V400;

        [Category(Data)]
        [DisplayName("Частота")]
        public string Freq { get; set; } = "50";

        [Category(Data)]        
        [DisplayName("Поисковый запрос")]
        public string FanType { get; set; } = "ER*C*DN*1R";

        public override int Width => (int)((DeviceData as FanCData)?.INSTALLATION_WIDTH_MM ?? 0);

        public override int Height => (int)((DeviceData as FanCData)?.INSTALLATION_HEIGHT_MM ?? 0);

        public override int Length => (int)((DeviceData as FanCData)?.INSTALLATION_LENGTH_MM ?? 980);

        [DependsOn(nameof(DeviceData),nameof(SubType))]
        public override string Name => $"Вентилятор с прямым приводом " +
                                        Direction switch
                                        {
                                            FanDirection.LeftRight => "выхлоп по оси ",
                                            FanDirection.RightLeft => "выхлоп по оси ",
                                            FanDirection.LeftUp => "выхлоп вверх ",
                                            FanDirection.UpLeft => "забор сверху ",
                                            _ => throw new Exception("Такого направления не предусмотренно"),
                                        } +
                                        (DeviceData as FanCData)?.ARTICLE_NO;

        public override string Image => ImagePath($"FanC/{Direction}");

        public override List<string> InfoProperties => new()
        {
            //"DeviceData.TYPE",
            "DeviceData.FANNAME",
            "Power",
            "PressureDropSystem",
            "PressureRaise",            
            "DeviceData.ZA_N",
            "DeviceData.POWER_OUTPUT_HP",
            "DeviceData.POWER_CALC_KW",
            "DeviceData.NOMINAL_SPEED",
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