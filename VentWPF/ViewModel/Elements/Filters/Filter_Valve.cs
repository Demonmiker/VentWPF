using PropertyTools.DataAnnotations; using static VentWPF.ViewModel.Strings;
using VentWPF.Model;

namespace VentWPF.ViewModel
{
    /// <summary>
    /// Представление Фильтр клапанный
    /// </summary>
    internal class Filter_Valve : Filter
    {
        public Filter_Valve()
        {
            Name = "Фильтр клапанный";
            image = "Filters/Filter_Valve.png";
        }

    }
}