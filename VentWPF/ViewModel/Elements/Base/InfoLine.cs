using PropertyTools.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Windows.Data;
using System.Windows.Documents;

namespace VentWPF.ViewModel
{
    public class InfoLine
    {
        public InfoLine(object mainType, string property)
        {
            MainObject = mainType;
            Property = FindProperty(property);
        }

        public string Format
        {
            get
            {
                if (NotValid) return null;
                var ats = Property?.GetCustomAttributes(typeof(FormatStringAttribute), true);
                return ats.Length > 0 ? (ats[0] as FormatStringAttribute).FormatString : null;
            }
        }

        public string Header
        {
            get
            {
                if (NotValid) return null;
                var ats = Property?.GetCustomAttributes(typeof(DisplayNameAttribute), true);
                return ats.Length > 0 ? (ats[0] as DisplayNameAttribute).DisplayName : null;
                
            }
        }

        public object Value => Property?.GetValue(MainObject);

        private object MainObject { get; set; }

        private bool NotValid => Property==null;

        private PropertyInfo Property { get; set; }

        public static IEnumerable<InfoLine> GenerateInfoLines(object o, IEnumerable<string> props)
            => props.Select(x => new InfoLine(o, x)).Where(x => !x.NotValid);

        public PropertyInfo FindProperty(string path)
        {
            while (path.Contains('.'))
            {
                var dot = path.IndexOf('.');
                var prop = path.Substring(0, dot);
                path = path.Substring(dot + 1, path.Length - dot - 1);
                MainObject = MainObject.GetType().GetProperty(prop).GetValue(MainObject);
            }
            return MainObject?.GetType()?.GetProperty(path);
        }

        public override string ToString()
                            => Format != null ? $"{Header}: {string.Format(Format, Value)}" : $"{Header}: {Value}";

        public Paragraph ToParagraph()
        { 
            var runH = new Run();
            runH.SetBinding(Run.TextProperty, new Binding() {  Mode=BindingMode.OneWay, Source = Header });
            var runV = new Run();
            runV.SetBinding(Run.TextProperty, new Binding() { Mode=BindingMode.OneWay, Source = Value ,StringFormat=Format});
            var res = new Paragraph();
            res.Inlines.AddRange(new[] { runH, new Run(": "), runV });
            return res;
        }
    }
}