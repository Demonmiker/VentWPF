using PropertyTools.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VentWPF.Fans.FanSelect;
using VentWPF.Tools;

namespace VentWPF.ViewModel
{
    class RequestVM
    {
        //Наблон для Fan Select DLL
        DllRequest FanSelectTemplate => IOManager.LoadAsJson<DllRequest>("req.json");
        //Другие шаблоны



        [Category("FanSelect|Запрос")]
        [DisplayName("Логин")]
        public string FanSelectLogin
        {
            get => FanSelectTemplate.Username;
            set => FanSelectTemplate.Username = value;
        }

        [Category("FanSelect|Запрос")]
        [DisplayName("Пароль")]
        public string FanSelectPassword
        {
            get => FanSelectTemplate.Password;
            set => FanSelectTemplate.Password = value;
        }
    }
}
