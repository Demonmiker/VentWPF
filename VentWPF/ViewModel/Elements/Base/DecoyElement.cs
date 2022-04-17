namespace VentWPF.ViewModel
{
    internal class DecoyElement : Element , IDoubleSubElement
    {
        public string name;
        public string image;

        public override string Name => name;

        public override string Image => image;
    }

    internal class TestTopElement : Element, IDoubleSubElement
    {
        public string name;
        public string image;

        public override string Name => name;

        public override string Image => image;

    }
}