namespace VentWPF.ViewModel
{
    internal class DoubleFanK3G : FanK3G, IDoubleMainElement
    {
        public override string Image => ImagePath($"FanK3G/DoubleBottom");
        public Element GetNewTopElement() => new TopFanK3G();
    }
    internal class TopFanK3G : FanK3G , IDoubleSubElement
    {
        public override string Image => ImagePath($"FanK3G/DoubleTop");
    }
}