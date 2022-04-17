namespace VentWPF.ViewModel
{
    internal class DoubleFanP : FanP, IDoubleMainElement
    {
        public override string Image => ImagePath($"FanP/DoubleBottom");
        public Element GetNewTopElement() => new TopFanP();
    }
    internal class TopFanP : FanP , IDoubleSubElement
    {
        public override string Image => ImagePath($"FanP/DoubleTop");
    }

}