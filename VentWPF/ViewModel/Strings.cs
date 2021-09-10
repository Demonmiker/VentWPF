using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VentWPF.ViewModel
{
    static class Strings
    {
        #region Категории
        public const string Data = "Данные";
        public const string Info = "Информация";
        public const string Debug = "Отладка";
        #endregion

        #region Форматирование
        public const string f1 = "{0:0.0}";
        public const string f2 = "{0:0.00}";
        

        public const string f0 = "{0}";
        public const string fc = "{0} шт";
        public const string fmm = "{0} мм";

        public const string fT = "{0:0.0}°C";
        
        public const string fkW = "{0:0.00} кВт";
        public const string fkPa = "{0:0.00} кПа";
        public const string fPa = "{0:0.00} Па";
        public const string fper = "{0:0.00} %";
        public const string fm3 = "{0:0.00} м³";
        public const string MasFr = "{0:0.00} Кг/Час";

        public const string fDate = "{0:dd/MM/yyyy}";
        
        public const string fNull = "{0:0.00} [X]";

        #endregion

        #region Сообщения об ошибке
        public const string errorRange = "Значение должно быть между {1} и {2}";

        public const string errorReq = "Обязательно к заполнению";


        #endregion
    }
}
