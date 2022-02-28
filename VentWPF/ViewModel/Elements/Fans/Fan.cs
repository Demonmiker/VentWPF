//using System.ComponentModel;
using System.IO;
using static VentWPF.ViewModel.Strings;
using VentWPF.Model.Calculations;
using PropertyTools.DataAnnotations;

namespace VentWPF.ViewModel
{
    /// <summary>
    /// Общий класс Вентиляторов
    /// </summary>
    internal class Fan : Element
    {
        public Fan()
        {
            ShowPD = false;
        }

        [Browsable(false)]
        public FanDirection Direction
        {
            get => (FanDirection)SubType;
            set => SubType = (int)value;
        }


        [Category(Info)]
        [FormatString(fkPa)]
        [DisplayName("Падение давления системы")] // TODO: Теперь это наверно яруса?
        public float PressureDropSystem => Calculations.GPD(Project.Grid.InTopRow(this));

        [Category(Info)]
        [FormatString(fm3Ph)]
        [DisplayName("Производительность")]
        public int Power => ProjectInfo.Settings.VFlow;

        [DisplayName("Падение давления общее")]
        [FormatString(fkPa)]
        public float PressureRaise => ProjectInfo.Settings.PFlow + Calculations.GPD(Project.Grid.InTopRow(this));

    }
}