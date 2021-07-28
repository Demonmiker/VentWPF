namespace VentWPF.ViewModel
{
    internal class Box : BaseViewModel
    {
        #region Constructors

        public Box(FrameSideVM parent, int value = 50)
        {
            this.Parent = parent;
            this.Value = value;
        }

        #endregion

        #region Properties

        public int Value { get; set; }

        public FrameSideVM Parent { get; set; }

        #endregion
    }
}