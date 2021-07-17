using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using da = System.ComponentModel.DataAnnotations;

namespace VentWPF.Tools
{
    class RequiredAttribute : da.RequiredAttribute
    {
        public override string FormatErrorMessage(string name)
        {
            return "Обязательное поле";
        }
    }

    class RangeAttribute : da.RangeAttribute
    {
        public RangeAttribute(
            double minimum=double.MinValue,
            double maximum=double.MaxValue)  
            : base(minimum, maximum)
        {
        }



        public override string FormatErrorMessage(string name) => 
                ((double)Minimum != double.MinValue,
                (double)Maximum != double.MaxValue) switch
        {
            (true, true) => $"Значение должно быть между {Minimum} и {Maximum}",
            (true, false) => $"Значение должно больше {Minimum}",
            (false, true) => $"Значение должно меньше {Maximum}",
            (false, false) => "!ОШИБКА RangeAttribute!",

        };
    }
}
