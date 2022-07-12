//using System.ComponentModel;
using PropertyTools.DataAnnotations;
using VentWPF.Model;
using VentWPF.Model.Calculations;
using static VentWPF.Model.ElementConnection;
using static VentWPF.ViewModel.Strings;

namespace VentWPF.ViewModel
{
    /// <summary>
    /// Общий класс Вентиляторов
    /// </summary>
    internal class Fan : Element
    {
        public Fan()
        {
            ShowPD = true;
            ShowPR = true;
        }

        [Browsable(false)]
        public FanDirection Direction
        {
            get => (FanDirection)SubType;
            set => SubType = (int)value;
        }

        public override ElementConnection Connection => Direction switch
        {
            FanDirection.LeftRight => Left | Right,
            FanDirection.RightLeft => Left | Right,
            FanDirection.LeftUp => Left | UpOutside,
            FanDirection.UpLeft => UpOutside | Left,
            FanDirection.LeftUpRight => Left | UpOutside | Right,
            FanDirection.LeftUpLeft => Left | UpOutside | Left,
            FanDirection.RightUpLeft => Right | UpOutside | Left
        };

        [Category(Info)]
        [FormatString(fPa)]
        [DisplayName("Полное давление")]
        public float PressureDropSystem => ProjectInfo.Settings.PFlow + Calculations.GPD(Project.Grid.InTopRow(this));

        [Category(Info)]
        [FormatString(fm3Ph)]
        [DisplayName("Производительность")]
        public int Power => ProjectInfo.Settings.VFlow;

        [DisplayName("Давление яруса")]
        [FormatString(fPa)]
        public float PressureRaise => Calculations.GPD(Project.Grid.InTopRow(this));

        [DisplayName("Давление сети")]
        [FormatString(fPa)]
        public float PressureFloor => Calculations.PressureInfo(Project.Grid.InTopRow(this));
    }
}