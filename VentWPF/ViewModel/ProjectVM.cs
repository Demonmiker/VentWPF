using PropertyTools.DataAnnotations;
using VentWPF.Model;

namespace VentWPF.ViewModel
{
    public class ProjectVM : BaseViewModel
    {
        private ProjectVM()
        {
        }

        public static ProjectVM Instance { get; private set; } = new ProjectVM();

        [Description("Описание")]
        public int VFlow { get; set; } = 6000;

        public int Resist { get; set; }
        public int Trend { get; set; }
        public int Humid { get; set; } = 85;
        public float PD { get; set; } = 500;
        public float PDd { get; set; } = 0;
        public int Width { get; set; } = 500;
        public int Height { get; set; } = 500;
        public int temp { get; set; } = -30;
        public float PressOut { get; set; } = 100;

        public Rows Rows { get; set; } = Rows.Row2;
    }
}