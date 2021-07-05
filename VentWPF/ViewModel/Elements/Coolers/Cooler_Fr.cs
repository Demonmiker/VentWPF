using PropertyTools.DataAnnotations; using static VentWPF.ViewModel.Strings;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using VentWPF.Model;
using VentWPF.Tools;


namespace VentWPF.ViewModel
{
    /// <summary>
    /// Представление Охладитель фреоновый
    /// </summary>
    internal class Cooler_Fr : Cooler
    {
      
        public Cooler_Fr()
        {
            //SELECT Типоряд, [L возд], [Ширина габарит], [Высота габарит], [N Квт], Цена FROM dbo.Фреон_холод"
            Name = "Фреоновый охладитель";
            image = "Coolers/Cooler_Fr.png";
            ShowQuery = true;
        }

        public override IList Query => ((IQueryable<object>)(from h in VentContext.Instance.ФреонХолодs select h)).ToList();



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