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
            FrameLength = frameLength;
            FrameWidth = frameWidth;
            FrameHeight = frameHeight;
            Top = new(this) { IsTop = true };
            Right = new(this);
            Left = new(this);
        }

        #endregion

        #region Properties

        public FrameSideVM Top { get; init; }

        public FrameSideVM Left { get; init; }

        public FrameSideVM Right { get; init; }

        public int FrameLength { get; set; }

        public int FrameWidth { get; set; }

        public int FrameHeight { get; set; }

        #endregion
    }
}