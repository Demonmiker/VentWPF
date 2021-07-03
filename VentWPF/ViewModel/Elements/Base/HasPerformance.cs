using PropertyTools.DataAnnotations;
using cm=System.ComponentModel;

namespace VentWPF.ViewModel
{
    internal class HasPerformance : Element
    {
        [Category(Data)]
        [SortIndex(-1)]
        [DisplayName("Производительность")]
        public override float Performance { get; set; } = Project.VFlow;
    }


}