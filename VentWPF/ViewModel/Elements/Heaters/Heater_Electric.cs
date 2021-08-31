using PropertyTools.DataAnnotations; 
using static VentWPF.ViewModel.Strings;
using System;
using System.Collections;
using System.Collections.Generic;
using VentWPF.Tools;
using System.Linq;
using VentWPF.Model;


namespace VentWPF.ViewModel
{
    internal class Heater_Electric : Heater
    {
        public Heater_Electric()
        {
            image = "Heaters/Heater_Electric.png";
            Query = new DatabaseQuery<Тэнры>
            {
                Source = from o in VentContext.Instance.Tэнрыs select o
            };
        }

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

        [Category(Data)]
        #region Данные
        [Browsable(false)]
        [DisplayName("т. теплоносителя начальная")]
        [FormatString(fT)]
        [Range(maximum: 100)]
        public float tBegin { get; set; } = 95;

        [Browsable(false)]
        [DisplayName("т. теплоносителя конечная")]
        [FormatString(fT)]
        [Range(minimum: 0)]
        public float tEnd { get;  set;} = 70;

        [DisplayName("Длина калорифера")]
        
        public int lengthKal => 50;

        [DisplayName("Ступеней нагрева")]
        public int heatSteps => 3;

        #endregion Данные

        [Category(Info)]
        #region Информация
        [Browsable(false)]
        [DisplayName("Горелка")]
        public TorchType TorchType { get; set; }

        #endregion Информация

    
    }
}