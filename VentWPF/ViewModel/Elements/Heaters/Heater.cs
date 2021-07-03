﻿using PropertyTools.DataAnnotations;
using System;

namespace VentWPF.ViewModel
{
    internal abstract class Heater : Element
    {
        

        public Heater()
        {
            Name = "Нагреватель электрический";
            image = "Heaters/Heater_Electric.png";
            ShowPR = true;
            ShowPD = true;
        }

        [Category(Data)]
        #region Данные
       
        [SortIndex(-1)]
        [DisplayName("т. на выходе")]
        [FormatString(fT)]
        public float TempOut { get; set; } = 18;

        [SortIndex(-1)]
        [DisplayName("т. на входе")]
        [FormatString(fT)]
        public float TempIn => Project.temp;

        [SortIndex(-1)]
        [DisplayName("Влажность воздуха")]
        [FormatString(f2)]
        [Resettable]
        public float HumidIn { get; set; } = 85;


        #endregion Данные

        [Category(Info)]
        #region Информация

        [DisplayName("Падение давления")]
        [FormatString(fP)]
        public override float PressureDrop => 70f / (4f / (Project.VFlow / 3600f / AB));

        [DisplayName("Абс. влажность на выходе")]
        [FormatString(f2)]
        public float HumidOutAbs => (float)(0.6222f * (HumidIn / 100f) * pD / (Project.PressOut - HumidIn / 100f * pD / 1000f));

        [DisplayName("Отн. влажность на выходе")]
        [FormatString(fF)]
        public float HumidOutRel => Project.PressOut / pD2 * 1000f / (0.6222f / HumidOutAbs * 1000f + 1f) * 100f;

        [DisplayName("Мощность")]
        [FormatString(fW)]
        public float Power => (float)(Project.VFlow * (353f / (273.15f + TempOut)) / 3600000f * 1009f * Math.Abs(TempIn - TempOut));



        #endregion Информация

        [Category(Debug)]
        #region Отладка
        [VisibleBy("ShowDebug")]
        public float AB => Project.Width / 1000f * (Project.Height / 1000f);

        [VisibleBy("ShowDebug")]
        public float pD2 => (float)Math.Exp((1500.3 + 23.5 * TempOut) / (234 + TempOut));

        [VisibleBy("ShowDebug")]
        public float pD => (float)Math.Exp((1500.3 + 23.5 * TempIn) / (234 + TempIn));
        #endregion



    }
}