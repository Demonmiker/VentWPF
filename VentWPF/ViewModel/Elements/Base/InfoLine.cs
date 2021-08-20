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
            type ??= mainType.GetType();
            MainObject = mainType;
            ExpectedType = type;
            Path = propPath;
            var prop = FindProperty(propPath,out _);
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

        public PropertyInfo FindProperty(string path,out object parent)
        {
            parent = MainObject;
            while (path.Contains('.'))
            {
                var dot = path.IndexOf('.');
                var prop = path.Substring(0, dot);
                path = path.Substring(dot + 1, path.Length - dot - 1);
                parent = parent.GetType().GetProperty(prop).GetValue(parent);
            }
            if (parent != null)
                return parent.GetType().GetProperty(path);
            else
                return ExpectedType?.GetProperty(path);
              
        }

        public Paragraph ToParagraph(bool isDynamic=false)
        {
            var runH = new Run(Header);
            var runV = new Run();
            if (isDynamic)
                runV.SetBinding(Run.TextProperty, new Binding() { Mode = BindingMode.OneWay, Source = MainObject, Path = new PropertyPath(Path), StringFormat = Format });
            else
            {

                var prop = FindProperty(Path, out var parent);
                if(parent is not null)
                    runV.Text = String.Format(Format ?? "{0}", prop.GetValue(parent));
                else
                    runV.Text = "";
                
                
            }
              
            var res = new Paragraph();
            res.Inlines.AddRange(new[] { runH, new Run(": "), runV });
            return res;
        }
    }
}