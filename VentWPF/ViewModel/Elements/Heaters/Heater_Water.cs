using PropertyTools.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using VentWPF.Model;
using VentWPF.Tools;

namespace VentWPF.ViewModel
{
    public class Heater_Water : HasPerformance
    {
        private float AB = (((float)project.Width / 1000) * ((float)project.Height / 1000));

        public Heater_Water()
        {
            Name = "Нагреватель жидкосный";
            image = "Heaters/Heater_Water.png";
            // ("SELECT Типоряд, [L возд], [Ширина габарит], [Высота габарит], [Ширина ЖС], [Высота ЖС], Цена  FROM dbo.Вода_тепло",
            Query = from h in VentContext.GetInstance().ВодаТеплоs select new
            {
                //нужно не оставлять double? менять а double если нужна сортировка по колонке
                Типоряд = h.Типоряд,
                LВозд = (double)h.LВозд,
                Скорость = (double)(278 * Performance / (h.ШиринаГабарит * h.ВысотаГабарит)),
                ШиринаГабарит = (double)h.ШиринаГабарит,
                ВысотаГабарит = (double)h.ВысотаГабарит,
                ШиринаЖс = (double)h.ШиринаЖс,
                ВысотаЖС = (double)h.ВысотаЖс,
                Цена = (double)h.Цена
            };
            // ColorColumn<double>("L возд", x => x>ProjectInfo.VFlow);
            //ColorColumn<double>("Ширина габарит", x => x <= ProjectInfo.With);
            //ColorColumn<double>("Высота габарит", x => x <= ProjectInfo.Height);
            //ColorColumn<double>("Скорость воздуха", x => x > 2.5 && x < 4.5 );


            
            Format = format;
            

        }

        private static Dictionary<string, (string name, System.Windows.Data.IValueConverter conv)> format = new()
        {
            { "LВозд", ("L возд", new Condition<double>(x => x >= project.VFlow)) },
            { "ШиринаГабарит", ("Ширина габарит", new Condition<double>(x => x <= project.Width)) },
            { "ВысотаГабарит", ("Высота габарит", new Condition<double>(x => x <= project.Height)) },
            { "Скорость", ("Скорость воздуха", new Condition<double>(x => x > 2.5 && x < 4.5)) },
        };

        #region Данные

        [DisplayName("Теплоноситель")]
        [Category(c1), PropertyOrder(7)]
        public CoolantType coolant { get; set; }

        [DisplayName("Влажность наружного воздуха")]
        [Category(c1), PropertyOrder(6)]
        public float humidityOutSide { get; set; } = project.Humid;

        [DisplayName("t теплоносителя начальная")]
        [Category(c1), PropertyOrder(4)]
        public float tBegin { get; set; } = 95;

        [DisplayName("t теплоносителя конечная")]
        [Category(c1), PropertyOrder(5)]
        public float tEnd { get; set; } = 70;

        [DisplayName("t воздуха на выходе")]
        [Category(c1), PropertyOrder(3)]
        public float tOut { get; set; } = 18;

        [DisplayName("t наружного воздуха")]
        [Category(c1), PropertyOrder(2)]
        public float tOutside => project.temp;

        #endregion Данные

        #region Информация

        [DisplayName("Расход теплоносителя")]
        [Category(c2), PropertyOrder(2)]
        public float consumption => (float)((Power * 1000) / (4200 * Math.Abs(tOutside - tOut)) * 3600);

        [DisplayName("Абсолютная влажность воздуха на выходе")]
        [Category(c2), PropertyOrder(4)]
        public float humidityOut => (float)((0.6222 * (humidityOutSide / 100) * pD) / (project.PressOut - (humidityOutSide / 100) * pD / 1000));

        [DisplayName("Относительная влажность воздуха на выходе")]
        [Category(c2), PropertyOrder(4)]
        public int humidityOutOtn => (int)((project.PressOut / pD2 * 1000 / (0.6222 / humidityOut * 1000 + 1)) * 100);

        [Browsable(false)]
        public float pD => (float)(Math.Exp((1500.3 + 23.5 * tOutside) / (234 + tOutside)));

        [DisplayName("Мощность воздухонагревателя, кВТ")]
        [Category(c2), PropertyOrder(3)]
        public float Power => (float)(project.VFlow * (353 / (273.15 + tOut)) / 3600000 * 1009 * Math.Abs(tOutside - tOut));

        [DisplayName("Падение давления расчётное")]
        [Category(c2), PropertyOrder(1)]
        public override float PressureDrop => (70 / (4 / (((float)project.VFlow / 3600) / AB)));

        [DisplayName("Падение давл. теплоносителя")]
        [Category(c2), PropertyOrder(5)]
        public float PressureDropT { get { return (float)12.5; } }

        #endregion Информация

        [Browsable(false)]
        public float pD2 => (float)(Math.Exp((1500.3 + 23.5 * tOut) / (234 + tOut)));
    }

  

}