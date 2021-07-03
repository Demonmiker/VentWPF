using PropertyTools.DataAnnotations;
using System;

namespace VentWPF.ViewModel
{
    /// <summary>
    /// Представление Охладитель жидкостный
    /// </summary>
    internal class Cooler_Water : Cooler
    {
        public Cooler_Water()
        {
            Name = "Охладитель жидкостный";
            image = "Coolers/Cooler_Water.png";
        }

        [Category(Data)]
        #region Данные

        [DisplayName("т. теплоносителя нач.")]
        public float tBegin => 7;

        [DisplayName("т. теплоносителя кон.")]
        public float tEnd => 12;

        #endregion Данные

        //[Category(Info)]
        #region Информация

        

        #endregion Информация

    }
}