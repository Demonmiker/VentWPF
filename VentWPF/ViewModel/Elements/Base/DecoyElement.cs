namespace VentWPF.ViewModel
{
    internal class DecoyElement : Element , IDoubleLinkedElement
    {
        public string name;
        public string image;

        public override string Name => name;

        public override string Image => image;
    }

    internal class TestTopElement : Element, IDoubleLinkedElement
    {
        public string name;
        public string image;

        public override string Name => name;

        public override string Image => image;

    }
}