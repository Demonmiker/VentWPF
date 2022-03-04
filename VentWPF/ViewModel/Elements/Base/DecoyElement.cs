namespace VentWPF.ViewModel
{
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