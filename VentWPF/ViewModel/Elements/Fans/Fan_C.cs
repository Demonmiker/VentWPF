using PropertyTools.DataAnnotations;
using System.Collections;
using System.Collections.Generic;
using VentWPF.FanDLL;
using VentWPF.Tools;

namespace VentWPF.ViewModel
{
    internal class Fan_C : Fan
    {
        private static Dictionary<string, Column> format = new Dictionary<string, Column>()
        {
            { "ARTICLE_NO", new("ID") },
        };

        public Fan_C()
        {
            Name = "Вентилятор \"Обычный\"";
            Format = format;
            HasQuery = true;
        }

        public override IList Query => new DLLController() { Request = IOManager.LoadAsJson<DLLRequest>("req.json") }.GetResponce();


    }
}