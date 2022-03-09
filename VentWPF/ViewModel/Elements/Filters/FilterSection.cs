namespace VentWPF.ViewModel
{
    /// <summary>
    /// Представление Фильтр секционный
    /// </summary>
    internal class FilterSection : Filter
    {
        public FilterSection()
        {
        }

        public override string Image => ImagePath("Filters/Section");

        public override int Length => 680;

        public override string Name => $"Фильтр ячейковый";
    }
}