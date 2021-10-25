using PropertyTools.DataAnnotations;
using VentWPF.Fans.FanSelect;
using VentWPF.Tools;

namespace VentWPF.ViewModel
{
    internal class RequestVM
    {
        [Category("FanSelect|Запрос")]
        [DisplayName("Логин")]
        public string FanSelectLogin
        {
            get => FanSelectTemplate.Username;
            set => FanSelectTemplate.Username = value;
        }

        //Другие шаблоны
        [Category("FanSelect|Запрос")]
        [DisplayName("Пароль")]
        public string FanSelectPassword
        {
            get => FanSelectTemplate.Password;
            set => FanSelectTemplate.Password = value;
        }

        //Наблон для Fan Select DLL
        private FanCRequest FanSelectTemplate => IOManager.LoadAsJson<FanCRequest>("req.json");
    }
}