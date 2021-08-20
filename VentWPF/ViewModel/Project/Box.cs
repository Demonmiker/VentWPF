namespace VentWPF.ViewModel
{
    internal class Box : BaseViewModel
    {
        #region Constructors

        public Box(FrameSideVM parent, uint value = 300)
        {
            this.parent = parent;
            this.value = value;
        }

        #endregion

        #region Properties

        private FrameSideVM parent;


        public FrameSideVM Parent
        {
            get { return parent; }
            set { parent = value; }
        }


        private uint value;

        private uint _Support;

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

        #endregion
    }
}