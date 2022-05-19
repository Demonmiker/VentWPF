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
    internal class RecuperatorGlicol : Recuperator
    {
        public override void UpdateQuery()
        {
            Query = new DatabaseQuery<ВодаТепло>
            {
                Source = from h in VentContext.Instance.ВодаТеплоs select h
            };
        }

        public override Element GetNewTopElement()
        {
            return new DecoyElement()
            {
                name = this.Name,
                image = ImagePath($"Recuperators/GlicolTop")
            };
        }

        public override Type DeviceType => typeof(ВодаТепло);

        public override string Image => ImagePath("Recuperators/GlicolBottom");

        public override int Width => (int)((DeviceData as ВодаТепло)?.ШиринаГабарит ?? 0);

        public override int Height => (int)((DeviceData as ВодаТепло)?.ВысотаГабарит ?? 0);

        public override int Length => 400;

        public override string Name => $"Гликолевый Рекуператор {(DeviceData as ВодаТепло)?.Типоряд}";


        /// <summary>
        /// КПД
        /// </summary>
        [Category(Info)]
        [DisplayName("КПД")]
        [FormatString(Strings.fper)]
        public float KPD => -1f;

        


        public override List<string> InfoProperties => new()
        {

        };

    }
}
