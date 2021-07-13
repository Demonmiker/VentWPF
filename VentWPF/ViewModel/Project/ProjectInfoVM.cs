using PropertyTools.DataAnnotations;
using VentWPF.Model;

namespace VentWPF.ViewModel
{
    public class ProjectInfoVM : BaseViewModel
    {

        public int Height { get; set; } = 500;

        public int Humid { get; set; } = 85;

        public float PD { get; set; } = 500;

        public float PDd { get; set; } = 0;

        public float PressOut { get; set; } = 100;

        public int Resist { get; set; }

        public Rows Rows { get; set; } = Rows.Row2;

        public int Temp { get; set; } = -30;

        public int Trend { get; set; }

        [Description("Описание")]
        public int VFlow { get; set; } = 6000;

        public int Width { get; set; } = 500;
    }
}