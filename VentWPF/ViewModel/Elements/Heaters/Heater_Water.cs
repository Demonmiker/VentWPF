using PropertyTools.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using VentWPF.Model;
using VentWPF.Tools;

namespace VentWPF.ViewModel
{
    internal class Heater_Water : Heater
    {
        private static Dictionary<string, Column> format = new Dictionary<string, Column>()
        {
            { "Типоряд", new() },
            { "LВозд", new("L Возд", new Condition<double>(x => x >= Project.VFlow)) },
            { "ШиринаГабарит", new("Ширина габарит", new Condition<double>(x => x <= Project.Width)) },
            { "ВысотаГабарит", new("Высота габарит", new Condition<double>(x => x <= Project.Height)) },
            { "Cкорость", new("Скорость воздуха", new Condition<double>(x => x > 2.5 && x < 4.5)) },
            { "ШиринаЖС", new("Ширина ЖС") },
            { "ВысотаЖС", new("Высота ЖС") },
            { "Цена", new() },
        };

        public Heater_Water()
        {
            Name = "Нагреватель жидкосный";
            image = "Heaters/Heater_Water.png";
            // ("SELECT Типоряд, [L возд], [Ширина габарит], [Высота габарит], [Ширина ЖС], [Высота ЖС], Цена  FROM dbo.Вода_тепло",
            //QueryCollection = ((IQueryable<object>)(from h in VentContext.Instance.ВодаТеплоs select h)).ToList();
            Format = format;
        }

        [Category(Data)]
        #region Данные

        [DisplayName("Теплоноситель")]
        public CoolantType Coolant { get; set; }

        [DisplayName("т. теплоносителя нач.")]
        public float tBegin { get; set; } = 95;

        [DisplayName("т. теплоносителя кон.")]
        public float tEnd { get; set; } = 70;

        #endregion Данные

        [Category(Info)]
        #region Информация

        [DisplayName("Расход теплоносителя")]
        [FormatString(fNull)]
        public float Consumption => (float)(Power * 1000 / (4200 * Math.Abs(TempIn - TempOut)) * 3600);


        [DisplayName("Падение давл. теплоносителя")]
        [FormatString(fP)]
        public float CoolantPressureDrop => 12.5f;

        #endregion Информация

     
    }
}