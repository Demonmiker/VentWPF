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
    class Recuperator_Platest : Recuperator
    {
        public override void UpdateQuery()
        {
            Query = new DatabaseQuery<ПластинчатыйРекуператор>
            {
                Source = from h in VentContext.Instance.ПластинчатыйРекуператорs select h
            };
        }

        [Browsable(false)]
        public override string TopImage => Path.GetFullPath($"Assets/Images/Icons/Sections/DoubleTop.png");
        
        public override Type DeviceType => typeof(ПластинчатыйРекуператор);

        public override string Image => ImagePath("Heaters/Water");

        public override int Width => (int)((DeviceData as ПластинчатыйРекуператор)?.With ?? 0); //Длина = Ширина, это не ошибка

        public override int Height => (int)((DeviceData as ПластинчатыйРекуператор)?.Height ?? 0);

        public override int Length => (int)((DeviceData as ПластинчатыйРекуператор)?.With ?? 0);

        public override string Name => $"Пластинчатый Рекуператор {(DeviceData as ПластинчатыйРекуператор)?.Маркировка}";



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
