using PropertyTools.DataAnnotations;
using System;
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

        protected override float GenPD() => 15;

        [Category(Data)]
        [FormatString(fmm)]
        [DisplayName("Ширина")]
        public int WidthValve { get; set; } = ProjectInfo.Settings.Width;


        [Browsable(false)]
        public bool GenHeightValve { get; set; }

        private int heightValve;

        [Category(Data)]
        [FormatString(fmm)]
        [DisplayName("Высота")]
        [Optional(nameof(GenHeightValve))]
        public virtual int HeightValve
        {
            get => !GenHeightValve ? (heightValve = GenHeight()) : heightValve;
            set => heightValve = value;
        }

        [Browsable(false)]
        [DisplayName("Сечение")]
        public string cut => Convert.ToString(WidthValve) + "" + Convert.ToString(HeightValve);

        private int GenHeight() => ProjectInfo.View.SizeType switch
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



        public override int Width => WidthValve;
        public override int Height => HeightValve;
    }
}