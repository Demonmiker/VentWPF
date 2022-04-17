namespace VentWPF.ViewModel
{
    internal class DoubleFanK3G : FanK3G, IDoubleElement
    {
        public override string Image => ImagePath($"FanK3G/DoubleBottom");
        public Element GetNewTopElement() => new TopFanK3G();
    }
    internal class TopFanK3G : FanK3G , IDoubleLinkedElement
    {
        public override string Image => ImagePath($"FanK3G/DoubleTop");
    }
}