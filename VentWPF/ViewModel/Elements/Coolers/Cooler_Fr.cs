﻿using PropertyChanged;
using PropertyTools.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using VentWPF.Model;
using static VentWPF.ViewModel.Strings;

namespace VentWPF.ViewModel
{
    /// <summary>
    /// Представление Охладитель фреоновый
    /// </summary>
    internal class Cooler_Fr : Cooler
    {
        #region Constructors

        public Cooler_Fr()
        {
            image = "Coolers/Cooler_Fr.png";
            Query = new DatabaseQuery<ФреонХолод>
            {
                Source = from o in VentContext.Instance.ФреонХолодs select o
            };
        }

        #endregion

        #region Properties

        [DependsOn(nameof(DeviceData))]
        public override string Name => $"Фреоновый охладитель {(DeviceData as ФреонХолод)?.Типоряд}";

        protected override List<string> InfoProperties => new()
        {
            "TempIn",
            "TempOut",
            "HumidityIn",
            "Power",
            "HumidOutAbs",
            "HumidOutRel",
            "DeviceData.LВозд",
            "DeviceData.NКвт",
            "DeviceData.Скорость",
            "DeviceData.КолВоКонтуров",
            "DeviceData.ВысотаГабарит",
            "DeviceData.ШиринаГабарит",
            "Fr",
        };

        #region Данные

        /// <summary>
        /// Тип Фреона
        /// </summary>
        [Category(Data)]
        [DisplayName("Тип Фреона")]
        public FrType Fr { get; set; }

        

        #endregion

        #endregion
    }
}