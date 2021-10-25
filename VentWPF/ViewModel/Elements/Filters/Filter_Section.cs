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

        public override int Length => 680;

        public override string Name => $"Фильтр секционный";
    }
}