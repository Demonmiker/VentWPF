namespace VentWPF.ViewModel
{
    /// <summary>
    /// Данные для графического представления каркаса
    /// </summary>
    internal class FrameVM : BaseViewModel
    {

        public FrameVM(int frameLength, int frameWidth, int frameHeight)
        {
            length = (uint)frameLength;
            width = (uint)frameWidth;
            height = (uint)frameHeight;
            Top = new(this);
            Right = new(this);
            Left = new(this);
            UpdateSides();
        }

        private uint height;

        private uint width;

        private uint length;

        public FrameSideVM Top { get; init; }

        public FrameSideVM Left { get; init; }

        public FrameSideVM Right { get; init; }

        public uint Height
        {
            get { return height; }
            set { height = value; UpdateSides(); }
        }

        public uint Width
        {
            get { return width; }
            set { width = value; UpdateSides(); }
        }

        public uint Length
        {
            get { return length; }
            set { length = value; UpdateSides(); }
        }

        private void UpdateSides()
        {
            Top.Side = width;
            Left.Side = height;
            Right.Side = height;

            Top.Length = length;
            Left.Length = length;
            Right.Length = length;
        }

    }
}