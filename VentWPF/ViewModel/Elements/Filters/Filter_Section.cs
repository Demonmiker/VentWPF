using PropertyTools.DataAnnotations; using static VentWPF.ViewModel.Strings;
using VentWPF.Model;

namespace VentWPF.ViewModel
{
    /// <summary>
    /// Представление Фильтр секционный
    /// </summary>
    internal class Filter_Section : Filter
    {
        public Filter_Section()
        {
            image = "Filters/Filter_Section.png";
        }

        public override string Name => $"Фильтр секционный";

    }
}