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
        public int HeightValve { get; set; } = Project.SizeType switch
        {
            SizeType.ТипоРазмер1 => (420),
            SizeType.ТипоРазмер2 => (310),
            SizeType.ТипоРазмер3 => (410),
            SizeType.ТипоРазмер4 => (510),
            SizeType.ТипоРазмер5 => (510),
            SizeType.ТипоРазмер6 => (610),
            SizeType.ТипоРазмер8 => (610),
            SizeType.ТипоРазмер10 => (810),
            SizeType.ТипоРазмер12 => (910),
            SizeType.ТипоРазмер16 => (1010),
            SizeType.ТипоРазмер20 => (1110),
            SizeType.ТипоРазмер25 => (1210),
            SizeType.ТипоРазмер30 => (1410),
            SizeType.ТипоРазмер40 => (1610),
            SizeType.ТипоРазмер50 => (1610),
            SizeType.ТипоРазмер60 => (2010),
            SizeType.ТипоРазмер80 => (2010),
            SizeType.ТипоРазмер100 => (2210),
            _ => (0)
        };
    }
}