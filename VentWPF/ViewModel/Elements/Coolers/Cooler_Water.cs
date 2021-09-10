using PropertyTools.DataAnnotations; using static VentWPF.ViewModel.Strings;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using VentWPF.Model;
using VentWPF.Tools;

namespace VentWPF.ViewModel
{
    /// <summary>
    /// Представление Охладитель жидкостный
    /// </summary>
    internal class Cooler_Water : Cooler
    {
       
        public Cooler_Water()
        {
            
            image = "Coolers/Cooler_Water.png";
            Query = new DatabaseQuery<ВодаХолод>
            {
                Source = from o in VentContext.Instance.ВодаХолодs select o
            };
        }
        public override string Name => $"Охладитель жидкостный {(DeviceData as ВодаХолод)?.Типоряд}";


        protected override List<string> InfoProperties => new()
        {
            "TempIn",
            "TempOut",
            "TempBegin",
            "TempEnd",           
            "HumidityIn",
            "Power",
            "HumidOutAbs",
            "HumidOutRel",
            "DeviceData.LВозд",
            "DeviceData.NКвт",
            "DeviceData.Скорость",
            "DeviceData.ВысотаГабарит",
            "DeviceData.ШиринаГабарит",
            "Fr",
        };

        [Category(Data)]
        #region Данные

        [DisplayName("т. теплоносителя нач.")]
        public float TempBegin => 7;

        [DisplayName("т. теплоносителя кон.")]
        public float TempEnd => 12;

        #endregion Данные

        [Category(Info)]
        #region Информация
        [Browsable(false)]
        [DisplayName("Расход теплоносителя")]
        [FormatString(MasFr)]
        public float Consumption => (float)(((Power * 1000) / (4198 * Math.Abs(TempBegin - TempEnd)))) * 3600;



        #endregion Информация

    }
}