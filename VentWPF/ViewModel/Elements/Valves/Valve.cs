using PropertyTools.DataAnnotations;
using VentWPF.Model;
using static VentWPF.ViewModel.Strings;

namespace VentWPF.ViewModel
{
    /// <summary>
    /// Общий класс Клапан
    /// </summary>
    internal abstract class Valve : Element
    {
        public Valve()
        {
            ShowPR = true;
            ShowPD = true;
        }

        protected override float GeneratedPressureDrop => 15;

        [Category(Data)]
        [FormatString(fmm)]
        [DisplayName("Ширина")]
        public int WidthValve { get; set; } = Project.Width;

        [Category(Data)]
        [FormatString(fmm)]
        [DisplayName("Высота")]
        public SizeType HeightValve
        {
            get => Project.SizeType;
            set
            {
                Project.SizeType = value;
                HeightValve = value.GetSize();
            }
        }
    }
}