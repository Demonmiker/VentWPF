﻿using PropertyTools.DataAnnotations; using static VentWPF.ViewModel.Strings;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using VentWPF.Model;
using VentWPF.Tools;

namespace VentWPF.ViewModel
{
    internal class Valve_Ver_Heat : Valve
    {
        public Valve_Ver_Heat()
        {
            //"SELECT Маркировка, Типоряд, [Кол-во по ширине] FROM dbo.TЭНы",
            Name = "Воздушный клапан вертикальный с нагревателем";
            image = "Valves/Valve_Ver_Heat.png";
            Query = new DatabaseQuery<Тэны>
            {
                Source = from o in VentContext.Instance.Tэныs select o,
            };
        }

        //public override IList Query => ((IQueryable<object>)(from h in VentContext.Instance.Tэныs select h)).ToList();
        [Category(Data)]
        [DisplayName("Количество ТЭНов")]
        public int TEN_count { get; set; } = 3;
    }
}