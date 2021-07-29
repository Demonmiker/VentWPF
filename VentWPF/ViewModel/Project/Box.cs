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

        private FrameSideVM parent;


        public FrameSideVM Parent
        {
            get { return parent; }
            set { parent = value; }
        }


        private uint value;

        public uint Support { get; set; }

        public uint Value
        {
            get { return value; }
            set { this.value = value; parent.ValuesChanged(); }
        }

        #endregion
    }
}