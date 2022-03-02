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

        [Browsable(false)]
        public SectionType Direction
        {
            get => (SectionType)SubType;
            set => SubType = (int)value;
        }

        // TODO: Добавить изменение названия из-за подтипа
        [DependsOn(nameof(DeviceData))]
        public override string Name => $"Секция";

        public override string Image => Path.GetFullPath($"Assets/Images/Icons/Sections/{Direction}.png");
    }

    internal class SectionDouble : Section , IDoubleElement
    {
        public override string Name => $"Двухярусная секция";
        public override string Image => Path.GetFullPath($"Assets/Images/Icons/Sections/DoubleBottom.png");

        public override bool TwoRowsOnly => true;

        [Browsable(false)]
        public string TopImage => Path.GetFullPath($"Assets/Images/Icons/Sections/DoubleTop.png");
    }

    internal interface IDoubleElement
    {
        string TopImage { get; }
    }


    internal class DecoyElement : Element
    {

        public DecoyElement(Element parent)
        {
            this.parent = parent;
        }
        override public string Name => parent.Name;

        private Element parent;

        public override string Image => (parent as IDoubleElement).TopImage;

    }
}