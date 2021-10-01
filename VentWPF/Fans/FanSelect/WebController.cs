using System;

namespace VentWPF.Fans.FanSelect
{
    /// <summary>
    /// Выполняет Web запрос к FanSelect API
    /// </summary>
    internal class WebController : IController<DllRequest, string>
    {
        public string GetResponce(DllRequest request)
        {
            string session = "temp";
            //Найти Session Id
            WebRequest webRequest = new(request, session);
            throw new NotImplementedException();
        }
    }
}