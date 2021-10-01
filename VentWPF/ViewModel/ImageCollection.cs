using System.IO;

namespace VentWPF.ViewModel
{
    /// <summary>
    /// Класс для более удобного получения изображений
    ///  #TODO Сделать лучше и убрать его
    /// </summary>
    internal class ImageCollection
    {

        public string Empty { get; set; } = Path.GetFullPath("Assets/Images/Empty.png");

        public string Valves { get; set; } = Path.GetFullPath("Assets/Images/Valves/Valves.png");

        public string Heaters { get; init; } = Path.GetFullPath("Assets/Images/Heaters/Heaters.png");

        public string Coolers { get; set; } = Path.GetFullPath("Assets/Images/Coolers/Coolers.png");

        public string Muffers { get; init; } = Path.GetFullPath("Assets/Images/Mufflers/Mufflers.png");

        public string Filters { get; set; } = Path.GetFullPath("Assets/Images/Filters/Filters.png");

        public string Sections { get; set; } = Path.GetFullPath("Assets/Images/Sections/Sections.png");

        public string Humidifiers { get; set; } = Path.GetFullPath("Assets/Images/Humidifiers/Humidifiers.png");

        public string Recuperators { get; set; } = Path.GetFullPath("Assets/Images/Recuperators/Recuperators.png");

        public string Fans_C { get; set; } = Path.GetFullPath("Assets/Images/Fans/Fan_C.png");

        public string Fans_P { get; set; } = Path.GetFullPath("Assets/Images/Fans/Fan_P.png");

        public string Fans_K3G { get; set; } = Path.GetFullPath("Assets/Images/Fans/Fan_K3G.png");

    }
}