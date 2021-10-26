using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VentWPF.Model
{
    public class Project
    {
        public int VFlow { get; set; }      = 6000;
        public int Resist { get; set; }
        public int Trend { get; set; }
        public int Humid { get; set; }      = 85;
        public float PD { get; set; }       = 500;
        public float PDd { get; set; }      = 0;
        public int With { get; set; }       = 500;
        public int Height { get; set; }     = 500;
        public int temp { get; set; }       = -30;
        public float PressOut { get; set; } = 100;
    }
}
