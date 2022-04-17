namespace VentWPF.ViewModel
{
    internal class DoubleFanC : FanC, IDoubleElement
    {
        public override string Image => ImagePath($"FanC/DoubleBottom");

        public Element GetNewTopElement() => new TopFanC();
    }
    internal class TopFanC : FanC , IDoubleLinkedElement
    {
        public override string Image => ImagePath($"FanC/DoubleTop");
    }

}