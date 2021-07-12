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
    /// Представление Охладитель жидкостный
    /// </summary>
    internal class Cooler_Water : Cooler
    {
       
        public Cooler_Water()
        {
            //SELECT Типоряд, [L возд], [Ширина габарит], [Высота габарит], [N Квт], Цена FROM dbo.Вода_холод
            Name = "Охладитель жидкостный";
            image = "Coolers/Cooler_Water.png";
            Query = new DatabaseQuery<ВодаХолод>
            {
                Source = from o in VentContext.Instance.ВодаХолодs select o
            };
        }

        //public override IList Query => ((IQueryable<object>)(from h in VentContext.Instance.ВодаХолодs select h)).ToList();

        [Category(Data)]
        #region Данные

        [DisplayName("т. теплоносителя нач.")]
        public float TempBegin => 7;

        [DisplayName("т. теплоносителя кон.")]
        public float TempEnd => 12;

        #endregion Данные

        //[Category(Info)]
        #region Информация

        

        #endregion Информация

    }
}