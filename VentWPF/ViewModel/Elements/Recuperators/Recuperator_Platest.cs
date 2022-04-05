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
    class Recuperator_Platest : Recuperator
    {
        public override void UpdateQuery()
        {
            Query = new DatabaseQuery<ПластинчатыйРекуператор>
            {
                Source = from h in VentContext.Instance.ПластинчатыйРекуператорs select h
            };
        }
        /*
        public override Type DeviceType => typeof(ВодаТепло);

        public override string Image => ImagePath("Heaters/Water");

        public override int Width => (int)((DeviceData as ВодаТепло)?.ШиринаГабарит ?? 0);

        public override int Height => (int)((DeviceData as ВодаТепло)?.ВысотаГабарит ?? 0);

        public override int Length => 400;

        public override string Name => $"Нагреватель жидкостный {(DeviceData as ВодаТепло)?.Типоряд}";
        */

        


        public override List<string> InfoProperties => new()
        {

        };


    }
}
