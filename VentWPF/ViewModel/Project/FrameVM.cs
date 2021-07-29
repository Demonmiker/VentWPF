using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VentWPF.ViewModel
{
    internal class FrameVM : BaseViewModel
    {
        #region Constructors

        public FrameVM(int frameLength, int frameWidth, int frameHeight)
        {
            length = frameLength;
            width = frameWidth;
            height = frameHeight;
            Top = new(this);
            Right = new(this);
            Left = new(this);
            UpdateSides();
        }

        #endregion

        #region Fields

        private int height;

        private int width;

        private int length;

        #endregion

        #region Properties

        public FrameSideVM Top { get; init; }

        public FrameSideVM Left { get; init; }

        public FrameSideVM Right { get; init; }

        public int Height
        {
            get { return height; }
            set { height = value; UpdateSides(); }
        }

        public int Width
        {
            get { return width; }
            set { width = value; UpdateSides(); }
        }

        public int Length
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

        #endregion
    }
}