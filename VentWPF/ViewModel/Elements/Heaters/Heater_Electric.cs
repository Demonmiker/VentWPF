using PropertyTools.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using VentWPF.Model;
using VentWPF.Tools;


namespace VentWPF.ViewModel
{
    internal class Heater_Electric : Heater
    {
        //private float AB = (((float)Project.Width / 1000) * ((float)Project.Height / 1000));

        private static Dictionary<string, Column> format = new Dictionary<string, Column>()
        {
            { "Маркировка", new() },
            { "Мощность", new() },
        };
        public Heater_Electric()
        {
            //SELECT Маркировка, Мощность FROM dbo.TЭНРы
            Name = "Нагреватель электрический";
            image = "Heaters/Heater_Electric.png";
            QueryCollection = ((IQueryable<object>)(from h in VentContext.Instance.Tэнрыs select h)).ToList();
            Format = format;
        }

        [Category(Data)]
        #region Данные

        [DisplayName("т. теплоносителя начальная")]
        [FormatString(fT)]
        public float tBegin { get; } = 95;

        [DisplayName("т. теплоносителя конечная")]
        [FormatString(fT)]
        public float tEnd { get; } = 70;

        [DisplayName("Длина калорифера")]
        public int lengthKal => 50;

        [DisplayName("Ступеней нагрева")]
        public int heatSteps => 3;

        #endregion Данные

        [Category(Info)]
        #region Информация

        [DisplayName("Горелка")]
        public TorchType TorchType { get; set; }

        #endregion Информация

    
    }
}