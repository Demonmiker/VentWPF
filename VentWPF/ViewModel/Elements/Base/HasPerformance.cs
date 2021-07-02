using PropertyTools.DataAnnotations;
using PropertyTools.Wpf;

namespace VentWPF.ViewModel
{
    internal class HasPerformance : Element
    {
        [Category(c1)]
        [SortIndex(-1)]
        [DisplayName("Производительность")]
        public override float Performance { get; set; } = Project.VFlow;
    }


}