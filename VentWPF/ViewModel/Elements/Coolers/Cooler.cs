using PropertyTools.DataAnnotations;
using System;
using VentWPF.Model;


namespace VentWPF.ViewModel
{
    /// <summary>
    /// Представление Охладитель фреоновый
    /// </summary>
    internal class Cooler : Element
    {
        public Cooler()
        {
            Name = "<Охладитель> ";
            ShowPR = true;
            ShowPD = true;
        }

       


       
        [Category(Data)]
        #region Данные

        
        [SortIndex(-1)]
        [DisplayName("t наружного воздуха")]
        [FormatString("{0:0.0##}°")]
        public float tOutside { get; set; } =30;

        [SortIndex(-1)]
        [DisplayName("t воздуха на выходе")]
        [FormatString("{0:0.0}°")]
        public float tOut { get; set; } = 18;

        [SortIndex(-1)]
        [DisplayName("Влажность наружного воздуха")]
        [FormatString("{0:0.00}")]
        public float humidityOutSide { get; set; } = 42;

        #endregion Данные


        [Category(Info)]
        #region Информация


        [DisplayName("Падение давления расчётное")]
        [FormatString("{0:0.0# Па}")]
        public override float PressureDrop => (70 / (4 / (((float)Project.VFlow / 3600) / AB)));

        [DisplayName("Мощность воздухоохладителя")]
        [FormatString("{0:0.00} kВт")]
        public float Power => (float)(Project.VFlow * (353 / (273.15 + tOut)) / 3600000 * 1009 * Math.Abs(tOutside - tOut));


        [DisplayName("Абсолютная влажность воздуха на выходе")]
        [FormatString("{0:0.0}")]
        public float humidityOut => (float)((0.6222 * (humidityOutSide / 100) * pD) / (Project.PressOut - (humidityOutSide / 100) * pD / 1000));

        [DisplayName("Относительная влажность воздуха на выходе")]
        [FormatString("{0:0.00 %}")]
        public int humidityOutOtn => (int)((Project.PressOut / pD2 * 1000 / (0.6222 / humidityOut * 1000 + 1)) * 100);

        #endregion Информация

        [Category(Debug)]
        #region Debug
        [VisibleBy("ShowDebug")]
        public virtual float AB => (((float)Project.Width / 1000) * ((float)Project.Height / 1000));

        [VisibleBy("ShowDebug")]
        public virtual float pD => (float)(Math.Exp((1500.3 + 23.5 * tOutside) / (234 + tOutside)));

        [VisibleBy("ShowDebug")]
        public virtual float pD2 => (float)(Math.Exp((1500.3 + 23.5 * tOut) / (234 + tOut)));
        #endregion



    }
}