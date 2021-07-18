using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VentWPF.ViewModel
{
    class FrameVM : BaseViewModel
    {
        public FrameSideVM Top { get; init; } = new() {IsTop=true };

        public FrameSideVM Left { get; init; } = new();

        public FrameSideVM Right { get; init; } = new();

        public int FrameLength { get; set; } = 500;

    }
}
