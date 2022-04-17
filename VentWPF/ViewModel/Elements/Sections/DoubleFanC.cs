namespace VentWPF.ViewModel
{
    internal class DoubleFanC : FanC, IDoubleMainElement
    {
        public override string Image => ImagePath($"FanC/DoubleBottom");

        public Element GetNewTopElement() => new TopFanC();
    }
    internal class TopFanC : FanC , IDoubleSubElement
    {
        public override string Image => ImagePath($"FanC/DoubleTop");
    }

}