using PropertyTools.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace VentWPF.ViewModel
{
    public class InfoLine
    {
        private string Header;
        private object MainObject;
        private string Property;
        private object Value;
        private string Format;

        public InfoLine(object mainType, string property)
        {
            MainObject = mainType;
            Property = property;
            Update();
        }

        

        private bool NotValid => Header == null || Value == null;

        public static IEnumerable<InfoLine> GenerateInfoLines(object o, IEnumerable<string> props)
            => props.Select(x => new InfoLine(o, x)).Where(x => !x.NotValid);

        public override string ToString()
                    => Format != null ? $"{Header}: {string.Format(Format, Value)}" : $"{Header}: {Value}";

        public PropertyInfo FindProperty()
        {

            while(Property.Contains('.'))
            {
                int dot = Property.IndexOf('.');
                var prop = Property.Substring(0, dot);
                Property = Property.Substring(dot + 1, Property.Length - dot-1);
                MainObject = MainObject.GetType().GetProperty(prop).GetValue(MainObject);
            }
            return MainObject?.GetType()?.GetProperty(Property);

        }

        public void Update()
        {
            //Находим Нужное свойство
            var prop = FindProperty();
            if (prop == null) return;
            //Находи его Имя
            var ats = prop?.GetCustomAttributes(typeof(DisplayNameAttribute), true);
            if (ats.Length > 0)
            {
                Header = (ats[0] as DisplayNameAttribute).DisplayName;
                //Находим значение свойства
                Value = prop?.GetValue(MainObject);
                //Находи его форматирование
                var ats2 = prop?.GetCustomAttributes(typeof(FormatStringAttribute), true);
                if(ats2.Length>0)
                    Format = (ats2[0] as FormatStringAttribute).FormatString;
            }
        }
    }
}