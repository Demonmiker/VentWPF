using System.ComponentModel;

namespace VentWPF.ViewModel
{
    internal class HasPerformance : Element
    {
        [DisplayName("Производительность")]
        [Category(c1), PropertyOrder(1)]
        public override float Performance { get; set; } = Project.VFlow;
    }


}