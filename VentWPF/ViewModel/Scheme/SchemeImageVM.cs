namespace VentWPF.ViewModel
{
    internal class SchemeImageVM : BaseViewModel
    {
        public ProjectVM Project { get; init; } = ProjectVM.Current;
        public SchemeBlock[] Blocks { get; set; }
    }
}