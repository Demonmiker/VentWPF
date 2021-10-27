using System.ComponentModel;
using System.IO;
using static VentWPF.ViewModel.Strings;
using VentWPF.Model.Calculations;

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

        [Category(Data)]
        [DisplayName("Данные уточняющие запрос")]
        public float Test { get; set; } = 4;

        [Category(Info)]
        [DisplayName("Падение давления системы")]
        public float PressureDropSystem => Calculations.GPD();

        [DisplayName("Повышение давления")]
        public float PressureRaise => PressureDrop;

        protected override float GeneratedPressureDrop => 0;

        // тут типо вычисляяю всё
    }
}