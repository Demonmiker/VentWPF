using System.ComponentModel;
using System.IO;
using static VentWPF.ViewModel.Strings;

namespace VentWPF.ViewModel
{
    internal class Fan : Element
    {
        public Fan()
        {
            ShowPD = false; ;
        }

        protected override float GeneratedPressureDrop => -500;


        [Browsable(false)]
        public Fan_Direction Direction
        {
            get => (Fan_Direction)SubType;
            set => SubType = (int)value;
        }

        public override string Image => Path.GetFullPath($"Assets/Images/Fans/Directions/{Direction}.png");

        [Category(Data)]
        [DisplayName("Данные уточняющие запрос")]
        public float Test { get; set; } = 4;

        [Category(Info)]
        [DisplayName("Падение давления системы")]
        public float PressureDropSystem => 999; // тут типо вычисляяю всё

        

        [DisplayName("Повышение давления")]
        public float PressureRaise => -PressureDrop;


    }
}