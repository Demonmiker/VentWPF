using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PropertyTools.DataAnnotations;
using VentWPF.Model;

namespace VentWPF.ViewModel
{
    
    class Fan_2 : Element
    {
        public Fan_2()
        {
            Name = "Вентилятор";
        }

        //FanData fd;

        //[DisplayName("Элемент:")][Category(c2), PropertyOrder(3)]
        //public string Id => fd?.ARTICLE_NO;
    }
}
