using PropertyChanged;
using PropertyTools.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using VentWPF.Model;
using VentWPF.Tools;
using static VentWPF.ViewModel.Strings;

namespace VentWPF.ViewModel
{
    internal class Heater_Electric : Heater
    {
        #region Constructors

        public Heater_Electric()
        {
            image = "Heaters/Heater_Electric.png";
            Query = new DatabaseQuery<Тэнры>
            {
                Source = from o in VentContext.Instance.Tэнрыs select o
            };
        }

        #endregion

        #region Properties

        [DependsOn(nameof(DeviceData))]
        public override string Name => $"Нагреватель электрический {(DeviceData as Тэнры)?.Маркировка}";

        protected override List<string> InfoProperties => new()
        {
            "Performance",
            "TempIn",
            "TempOut",
            "tBegin",
            "tEnd",
            "lengthKal",
            "heatSteps",
            "TorchType",
            "DeviceData.Типоряд",
            "DeviceData.Маркировка",
            "DeviceData.Мощность",
        };

        #region Данные

        /// <summary>
        /// Температура теплоносителя начальная
        /// </summary>
        [Category(Data)]
        [Browsable(false)]
        [DisplayName("т. теплоносителя начальная")]
        [FormatString(fT)]
        [Range(maximum: 100)]
        public float tBegin { get; set; } = 95;

        /// <summary>
        /// Температура теплоносителя конечная
        /// </summary>
        [Browsable(false)]
        [DisplayName("т. теплоносителя конечная")]
        [FormatString(fT)]
        [Range(minimum: 0)]
        public float tEnd { get; set; } = 70;

        /// <summary>
        /// Длина калорифера
        /// </summary>
        [DisplayName("Длина калорифера")]
        public int lengthKal => 50;

        /// <summary>
        /// Количество ступеней нагрева
        /// </summary>
        [DisplayName("Ступеней нагрева")]
        public int heatSteps => 3;

        #endregion Данные

        #region Информация

        /// <summary>
        /// Тип горелки
        /// </summary>
        [Category(Info)]
        [Browsable(false)]
        [DisplayName("Горелка")]
        public TorchType TorchType { get; set; }

        #endregion Информация

        #endregion
    }
}