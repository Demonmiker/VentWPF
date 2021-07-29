using System;
using System.Collections.Generic;
using System.Windows.Data;
using VentWPF.Tools;

namespace VentWPF.ViewModel.Elements
{
    internal static class Conditions
    {
        #region Fields

        public static Dictionary<Type, Dictionary<string, IValueConverter>> dict = new()
        {
            {
                typeof(Heater_Water),
                new()
                {
                    { "LВозд", new Condition<double>(x => x >= Project.VFlow) },
                    { "ШиринаГабарит", new Condition<double>(x => x <= Project.Width) },
                    { "ВысотаГабарит", new Condition<double>(x => x <= Project.Height) },
                    { "Скорость", new Condition<double>(x => x > 2.5 && x < 4.5) },
                }
            },
            {
                typeof(Cooler_Water),
                new()
                {
                    { "LВозд", new Condition<double>(x => x >= Project.VFlow) },
                    { "ШиринаГабарит", new Condition<double>(x => x <= Project.Width) },
                    { "ВысотаГабарит", new Condition<double>(x => x <= Project.Height) },
                    { "Скорость", new Condition<double>(x => x > 2.5 && x < 4.5) },
                }
            },
            {
                typeof(Cooler_Fr),
                new()
                {
                    { "LВозд", new Condition<double>(x => x >= Project.VFlow) },
                    { "ШиринаГабарит", new Condition<double>(x => x <= Project.Width) },
                    { "ВысотаГабарит", new Condition<double>(x => x <= Project.Height) },
                    { "Скорость", new Condition<double>(x => x > 2.5 && x < 4.5) },
                }
            },
        };

        private static ProjectInfoVM Project = ProjectVM.Current?.ProjectInfo;

        #endregion

        #region Methods

        public static Dictionary<string, IValueConverter> Get(Type t)
                            => dict.ContainsKey(t) ? dict[t] : null;

        #endregion
    }
}