namespace VentWPF.ViewModel
{
    internal class Box : BaseViewModel
    {
        #region Constructors

        public Box(FrameSideVM parent, uint value = 50)
        {
            this.parent = parent;
            this.value = value;
        }

        #endregion

        #region Properties

        public FrameSideVM parent;

        private uint value;

        public uint Support { get; set; } = 10;

        public uint Value
        {
            get { return value; }
            set { this.value = value; parent.ValuesChanged(); }
        }

        #endregion
    }
}