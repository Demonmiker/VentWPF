namespace VentWPF.ViewModel
{
    /// <summary>
    /// Представление Фильтр клапанный
    /// </summary>
    internal class FilterValve : Filter
    {
        public FilterValve()
        {
        }

        public override string Image => ImagePath("Filters/Valve");

        public override int Length => 680;

        public override string Name => "Фильтр карманный";
    }
}