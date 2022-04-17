using System;

namespace VentWPF.Model
{
    [Flags]
    public enum ElementConnection
    {
        None = 0,
        Left = 1,
        Right = 2,
        Up = 4,
        Down = 8,
        UpOutside = 16,
        DownOutside = 32,
    }

}