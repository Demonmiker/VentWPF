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
    /// Представление Охладитель фреоновый
    /// </summary>
    internal class Cooler_Fr : Cooler
    {
        private static Dictionary<string, Column> format = new Dictionary<string, Column>()
        {
            { "Типоряд", new() },
            { "LВозд", new("L Возд", new Condition<double>(x => x >= Project.VFlow)) },
            { "ШиринаГабарит", new("Ширина габарит", new Condition<double>(x => x <= Project.Width)) },
            { "ВысотаГабарит", new("Высота габарит", new Condition<double>(x => x <= Project.Height)) },
            { "Cкорость", new("Скорость воздуха", new Condition<double>(x => x > 2.5 && x < 4.5)) },
            { "L возд", new("L возд") },
            { "Цена", new() },
        };
        public Cooler_Fr()
        {
            //SELECT Типоряд, [L возд], [Ширина габарит], [Высота габарит], [N Квт], Цена FROM dbo.Фреон_холод"
            Name = "Фреоновый охладитель";
            image = "Coolers/Cooler_Fr.png";
            Format = format;
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