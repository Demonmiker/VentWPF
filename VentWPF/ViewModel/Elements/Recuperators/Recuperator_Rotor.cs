using PropertyTools.DataAnnotations;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using VentWPF.Model;
using VentWPF.Model.Calculations;
using static VentWPF.ViewModel.Strings;

namespace VentWPF.ViewModel
{
    class Recuperator_Rotor : Recuperator
    {
        public override void UpdateQuery()
        {
            Query = new DatabaseQuery<РоторныйРегенератор>
            {
                Source = from h in VentContext.Instance.РоторныйРегенераторs select h
            };
        }

        [Browsable(false)]
        public override string TopImage => Path.GetFullPath($"Assets/Images/Icons/Sections/DoubleTop.png");

        
        public override Type DeviceType => typeof(РоторныйРегенератор);

        public override string Image => ImagePath("Heaters/Water");

        public override int Width => (int)((DeviceData as РоторныйРегенератор)?.With ?? 0);

        public override int Height => (int)((DeviceData as РоторныйРегенератор)?.Heinht ?? 0);

        public override int Length => 400;

        public override string Name => $"Роторный Рекуператор {(DeviceData as ВодаТепло)?.Типоряд}";

        /// <summary>
        /// КПД
        /// </summary>
        [Category(Info)]
        [DisplayName("КПД")]
        [FormatString(Strings.fper)]
        public float KPD => -1f;

        /// <summary>
        /// Температура входа
        /// </summary>
        [Category(Data)]
        [DisplayName("Темп. входа")]
        [FormatString(Strings.fT)]
        public float Tinlet => -1f;

        /// <summary>
        /// Температура выхода
        /// </summary>
        [Category(Data)]
        [DisplayName("Темп. выхода")]
        [FormatString(Strings.fT)]
        public float Toutlet => -1f;

        /// <summary>
        /// Влажность входа
        /// </summary>
        [Category(Data)]
        [DisplayName("Влаж. входа")]
        [FormatString(Strings.fper)]
        public float Densinlet => -1f;

        /// <summary>
        /// Влажность выхода
        /// </summary>
        [Category(Data)]
        [DisplayName("Влаж. выхода")]
        [FormatString(Strings.fper)]
        public float Densoutlet => -1f;

        /// <summary>
        /// Р вытяжки
        /// </summary>
        [Category(Info)]
        [DisplayName("Сопр. вытяжки")]
        [FormatString(Strings.fper)]
        public float PFlow => -1f;
        
        //TODO: Demonmiker, смотри, тут сопротивление верхнего и нижнего ярусов разные и как-то считаются(уже спросил как). Но как
        //отправить эти числа в PDrops? Вариант: как-то пометить их и привязать одно к нижней половине элемента, другую к верхней. Подумай <3

        /// <summary>
        /// Р резерва
        /// </summary>
        [Category(Info)]
        [DisplayName("Сопр. притока")]
        [FormatString(Strings.fper)]
        public float Pflowreserv => -1f;


        public override List<string> InfoProperties => new()
        {

        };        
        
    }
}
