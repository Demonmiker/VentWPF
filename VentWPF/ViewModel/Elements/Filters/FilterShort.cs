namespace VentWPF.ViewModel
{
    /// <summary>
    /// Представление Фильтр Короткий  f
    /// </summary>
    internal class FilterShort : Filter
    {
        public FilterShort()
        {
        }

        public override string Image => ImagePath("Filters/Short");

        public override int Length => 480;

        public override string Name => "Фильтр карманный укороченый";
    }
}