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
    /// <summary>
    /// Строка информации об элементе
    /// </summary>
    public class InfoLine
    {

        /// <summary>
        /// Создает информационную строку
        /// </summary>
        /// <param name="mainType">источник иформации</param>
        /// <param name="propPath">путь к свойству объекта</param>
        /// <param name="type">запасной тип</param>
        public InfoLine(object mainType, string propPath, Type type = null)
        {
            type ??= mainType.GetType();
            MainObject = mainType;
            ExpectedType = type;
            Path = propPath;
            var prop = FindProperty(propPath, out _);
            if (prop == null) return;
            Header = prop.GetCustomAttribute<DisplayNameAttribute>()?.DisplayName;
            Format = prop.GetCustomAttribute<FormatStringAttribute>()?.FormatString;
        }

        /// <summary>
        /// Путь по которому было найдено свойство
        /// </summary>
        public string Path { get; init; }

        /// <summary>
        /// Формат для данных
        /// </summary>
        private string Format { get; init; }

        /// <summary>
        /// Заголовок для информации
        /// </summary>
        private string Header { get; init; }

        /// <summary>
        /// Тип ожидаемого родителя свойства
        /// </summary>
        private Type ExpectedType { get; init; }

        /// <summary>
        /// Родитель свойства
        /// </summary>
        private object MainObject { get; set; }

        /// <summary>
        /// Метод создающий список Информационных строк
        /// </summary>
        /// <param name="o"></param>
        /// <param name="exType"></param>
        /// <param name="props"></param>
        /// <returns></returns>
        public static IEnumerable<InfoLine> GenerateInfoLines(object o, Type exType, IEnumerable<string> props)
            => props.Select(x => new InfoLine(o, x, exType)).Where(x => x.Header != null);

        /// <summary>
        /// Метод находит Свойство и дополнительно его родителя
        /// </summary>
        /// <param name="path">путь к свойству от изначального объекта</param>
        /// <param name="parent">родитель конечного свойства</param>
        /// <returns>Информация про свойство</returns>
        public PropertyInfo FindProperty(string path, out object parent)
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

        /// <summary>
        /// Создает Параграф для вывода
        /// </summary>
        /// <param name="isDynamic">Определяет будет ли параграф автообновляемым или статичным</param>
        /// <returns>Параграф с информацией</returns>
        public Paragraph ToParagraph(bool isDynamic = false)
        {
            var runH = new Run(Header);
            var runV = new Run();
            if (isDynamic)
                runV.SetBinding(Run.TextProperty, new Binding() { Mode = BindingMode.OneWay, Source = MainObject, Path = new PropertyPath(Path), StringFormat = Format });
            else
            {
                var prop = FindProperty(Path, out var parent);
                if (parent is not null)
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