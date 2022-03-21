using System.Linq;

namespace VentWPF.ViewModel
{
    internal class SchemeImageVM : BaseViewModel
    {
        public ProjectVM Project { get; init; } = ProjectVM.Current;
        public SchemeBlock[] Blocks { get; set; }
        public uint Sum { get; set; } = 0;
        public void UpdateSum()
        {
            if (Blocks is null) 
                Sum= 0; 
            else
                Sum = (uint)Blocks.Sum(x => x.Sum());
        }
    }
}