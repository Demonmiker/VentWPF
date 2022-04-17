namespace VentWPF.ViewModel
{
    internal class DoubleFanP : FanP, IDoubleElement
    {
        public override string Image => ImagePath($"FanP/DoubleBottom");
        public Element GetNewTopElement() => new TopFanP();
    }
    internal class TopFanP : FanP , IDoubleLinkedElement
    {
        public override string Image => ImagePath($"FanP/DoubleTop");
    }

}