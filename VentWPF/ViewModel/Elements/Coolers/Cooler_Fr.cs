using PropertyTools.DataAnnotations;
using System;
using VentWPF.Model;


namespace VentWPF.ViewModel
{
    /// <summary>
    /// Представление Охладитель фреоновый
    /// </summary>
    internal class Cooler_Fr : Cooler
    {
        public Cooler_Fr()
        {
            Name = "Охладитель фреоновый";
            image = "Coolers/Cooler_Fr.png";
        }

        [Category(Data)]
        #region Данные
        [DisplayName("Тип Фреона")]
        public FrType Fr { get; set; }

        #endregion Данные


        //[Category(Info)]
        #region Информация

       
        #endregion Информация

       
    }
}