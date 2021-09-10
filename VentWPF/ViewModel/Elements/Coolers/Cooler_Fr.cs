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
    /// Представление Охладитель фреоновый
    /// </summary>
    internal class Cooler_Fr : Cooler
    {
        
      
        public Cooler_Fr()
        {
            //SELECT Типоряд, [L возд], [Ширина габарит], [Высота габарит], [N Квт], Цена FROM dbo.Фреон_холод"
            image = "Coolers/Cooler_Fr.png";
            Query = new DatabaseQuery<ФреонХолод>
            {
                Source = from o in VentContext.Instance.ФреонХолодs select o
            };
        }

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


        [Category(Data)]
        #region Данные
        [DisplayName("Тип Фреона")]
        public FrType Fr { get; set; }

        #endregion Данные


        //[Category(Info)]
        #region Информация

       
        #endregion Информация

       
    }
}