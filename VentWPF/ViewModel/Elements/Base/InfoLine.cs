using PropertyTools.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Windows;
using System.Windows.Data;
using System.Windows.Documents;

namespace VentWPF.ViewModel
{
    public class InfoLine
    {
        public InfoLine(object mainType, string propPath, Type type = null)
        {
            type = type ?? mainType.GetType();
            MainObject = mainType;
            ExpectedType = type;
            Path = propPath;
            var prop = FindProperty(propPath);
            if (prop == null) return;
            Header = prop.GetCustomAttribute<DisplayNameAttribute>()?.DisplayName;
            Format = prop.GetCustomAttribute<FormatStringAttribute>()?.FormatString;
        }

        public string Format { get; init; }

        public string Header { get; init; }

        public string Path { get; init; }

        private Type ExpectedType { get; init; }

        private object MainObject { get; set; }

        public static IEnumerable<InfoLine> GenerateInfoLines(object o, Type exType, IEnumerable<string> props)
            => props.Select(x => new InfoLine(o, x, exType)).Where(x => x.Header != null);

        public PropertyInfo FindProperty(string path)
        {
            var o = MainObject;
            while (path.Contains('.'))
            {
                var dot = path.IndexOf('.');
                var prop = path.Substring(0, dot);
                path = path.Substring(dot + 1, path.Length - dot - 1);
                o = o.GetType().GetProperty(prop).GetValue(o);
            }
            if (o != null)
                return o.GetType().GetProperty(path);
            else
                return ExpectedType?.GetProperty(path);
        }

        public Paragraph ToParagraph()
        {
            var runH = new Run();
            runH.SetBinding(Run.TextProperty, new Binding() { Mode = BindingMode.OneWay, Source = Header });
            var runV = new Run();
            runV.SetBinding(Run.TextProperty, new Binding() { Mode = BindingMode.OneWay, Source = MainObject, Path=new PropertyPath(Path), StringFormat = Format });
            var res = new Paragraph();
            res.Inlines.AddRange(new[] { runH, new Run(": "), runV });
            return res;
        }
    }
}