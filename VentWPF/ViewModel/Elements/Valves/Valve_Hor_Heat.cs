using PropertyTools.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using VentWPF.Model;
using VentWPF.Tools;

namespace VentWPF.ViewModel
{
    internal class Valve_Hor_Heat : Valve
    {
        private static Dictionary<string, Column> format = new Dictionary<string, Column>()
        {
            { "Маркировка", new() },
            { "Типоряд", new() },
            { "КолВоПоШирине", new("Кол-во по ширине") },
        };
        public Valve_Hor_Heat()
        {
            //SELECT Маркировка, Типоряд, [Кол-во по ширине] FROM dbo.TЭНы",
            Name = "Воздушный клапан горизонтальный с нагревателем";
            image = "Valves/Valve_Hor_Heat.png";
            //QueryCollection = ((IQueryable<object>)(from h in VentContext.Instance.Tэныs select h)).ToList();
            Format = format;
        }

        [Category(Data)]
        [DisplayName("Количество ТЭНов")]
        public int TEN_count { get; set; } = 3;
    }
}