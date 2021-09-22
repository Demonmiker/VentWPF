namespace VentWPF.ViewModel
{
    /// <summary>
    /// Представляет одну секцию стороны каркаса
    /// </summary>
    internal class Box : BaseViewModel
    {

        public Box(FrameSideVM parent, uint value = 300)
        {
            this.parent = parent;
            this.value = value;
        }

        private FrameSideVM parent;

        private uint value;

        private uint _Support;

        public FrameSideVM Parent
        {
            get { return parent; }
            set { parent = value; }
        }

        public uint Support
        {
            get => _Support;
            set => _Support = value > Parent.Side ? (uint)Parent.Side : value;
        }

        public uint Value
        {
            get { return value; }
            set { this.value = value; parent.ValuesChanged(); }
        }

    }
}