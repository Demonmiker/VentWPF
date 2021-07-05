using PropertyTools.DataAnnotations;
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
        private static Dictionary<string, Column> format = new Dictionary<string, Column>()
        {
            { "Типоряд", new() },
            { "LВозд", new("L Возд", new Condition<double>(x => x >= Project.VFlow)) },
            { "ШиринаГабарит", new("Ширина габарит", new Condition<double>(x => x <= Project.Width)) },
            { "ВысотаГабарит", new("Высота габарит", new Condition<double>(x => x <= Project.Height)) },
            { "Cкорость", new("Скорость воздуха", new Condition<double>(x => x > 2.5 && x < 4.5)) },
            { "N Квт", new("N Квт") },
            { "Цена", new() },
        };
        public Cooler_Water()
        {
            //SELECT Типоряд, [L возд], [Ширина габарит], [Высота габарит], [N Квт], Цена FROM dbo.Вода_холод
            Name = "Охладитель жидкостный";
            image = "Coolers/Cooler_Water.png";
            Format = format;
            HasQuery = true;
        }

        public override IList Query => ((IQueryable<object>)(from h in VentContext.Instance.ВодаХолодs select h)).ToList();

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