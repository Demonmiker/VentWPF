using PropertyTools.DataAnnotations;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using VentWPF.Model;
using VentWPF.Model.Calculations;
using static VentWPF.ViewModel.Strings;

namespace VentWPF.ViewModel.Elements.Recuperators
{
    internal class Recuperator_Glicol : Recuperator
    {
        public override void UpdateQuery()
        {
            Query = new DatabaseQuery<ВодаТепло>
            {
                Source = from h in VentContext.Instance.ВодаТеплоs select h
            };
        }
        /*
         *TODO: Demonmiker подключить
        public override Type DeviceType => typeof(ВодаТепло);

        public override string Image => ImagePath("Heaters/Water");

        public override int Width => (int)((DeviceData as ВодаТепло)?.ШиринаГабарит ?? 0);

        public override int Height => (int)((DeviceData as ВодаТепло)?.ВысотаГабарит ?? 0);

        public override int Length => 400;

        public override string Name => $"Нагреватель жидкостный {(DeviceData as ВодаТепло)?.Типоряд}";
        */

        /// <summary>
        /// Тип теплоносителя
        /// </summary>
        [Category(Data)]
        [DisplayName("Теплоноситель")]
        public CoolantType Coolant { get; set; }


        public override List<string> InfoProperties => new()
        {

        };

    }
}
