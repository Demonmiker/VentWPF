namespace VentWPF.ViewModel
{
    internal record PackedProject
    {
        public Order Order { get; init; }

        public Settings Settings {get; init;} 

        public View View { get; init; }

        public Element[] Elements { get; init; }
        
    }
}