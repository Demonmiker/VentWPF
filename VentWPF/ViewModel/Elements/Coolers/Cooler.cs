﻿using PropertyTools.DataAnnotations;
using System;
using VentWPF.Model;


namespace VentWPF.ViewModel
{
    /// <summary>
    /// Представление Охладитель фреоновый
    /// </summary>
    internal abstract class Cooler : Element
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
        [DisplayName("т. на входе")]
        [FormatString("{0:0.0##}°")]
        public float TempIn { get; set; } = 30;

        [SortIndex(-1)]
        [DisplayName("т. на выходе")]
        [FormatString("{0:0.0}°")]
        public float TempOut { get; set; } = 18;

        [SortIndex(-1)]
        [DisplayName("Влажность воздуха")]
        [FormatString("{0:0.00}")]
        public float HumidityIn { get; set; } = 42;

        #endregion Данные


        [Category(Info)]
        #region Информация


        [DisplayName("Падение давления")]
        [FormatString("{0:0.0# Па}")]
        public override float PressureDrop => (70f / (4f / ((Project.VFlow / 3600f) / AB)));

        [DisplayName("Мощность")]
        [FormatString("{0:0.00} kВт")]
        public float Power => (Project.VFlow * (353f / (273.15f + TempOut)) / 3600000f * 1009f * Math.Abs(TempIn - TempOut));


        [DisplayName("Абс. влажность на выходе")]
        [FormatString("{0:0.0}")]
        public float HumidOutAbs => ((0.6222f * (HumidityIn / 100f) * pD) / (Project.PressOut - (HumidityIn / 100f) * pD / 1000f));

        [DisplayName("Отн. влажность на выходе")]
        [FormatString("{0:0.00 %}")]
        public float HumidOutRel => ((Project.PressOut / pD2 * 1000f / (0.6222f / HumidOutAbs * 1000f + 1)) * 100f);

        #endregion Информация

        [Category(Debug)]
        #region Debug
        [VisibleBy("ShowDebug")]
        public virtual float AB => (((float)Project.Width / 1000) * ((float)Project.Height / 1000));

        [VisibleBy("ShowDebug")]
        public virtual float pD => (float)(Math.Exp((1500.3 + 23.5 * TempIn) / (234 + TempIn)));

        [VisibleBy("ShowDebug")]
        public virtual float pD2 => (float)(Math.Exp((1500.3 + 23.5 * TempOut) / (234 + TempOut)));
        #endregion



    }
}