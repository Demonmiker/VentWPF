using PropertyChanged;
using PropertyTools.DataAnnotations;
using System.IO;

namespace VentWPF.ViewModel
{
    internal class Section : Element
    {
        public Section()
        {
            ShowPD = false;
        }

        [DisplayName("Длина блока")]
        [FormatString(Strings.fmm)]
        public int SectionLength { get; set; } = 600;

        [DependsOn(nameof(SectionLength))]
        public override int Length => SectionLength;

        [Browsable(false)]
        public SectionType Direction
        {
            get => (SectionType)SubType;
            set => SubType = (int)value;
        }

        [DependsOn(nameof(SubType))]
        public override string Name => Direction switch
        {
            SectionType.LeftRight => $"Промежуточная секция",
            SectionType.LeftUpDown => $"Промежуточная секция поворот вверх/вниз",
            SectionType.LeftDown => $"Промежуточная секция поворот вниз",
            SectionType.LeftUp => $"Промежуточная секция поворот вверх",
            SectionType.RightDown => $"Промежуточная секция поворот внизу",
            SectionType.LeftUpRight => $"Секция смешения",
            SectionType.LeftRightDown => $"Секция смешения",
            SectionType.LeftRightShort => $"Промежуточная секция",
            SectionType.LeftRightValve => $"Промежуточная секция с клапаном",
            SectionType.LeftUpRightValve => $"Секция рециркуляции",
        };

        public override string Image => Path.GetFullPath($"Assets/Images/Icons/Sections/{Direction}.png");
    }
}