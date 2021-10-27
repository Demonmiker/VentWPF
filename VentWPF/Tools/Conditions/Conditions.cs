using System;
using System.Collections.Generic;
using System.Windows.Data;
using VentWPF.Tools;

namespace VentWPF.ViewModel.Elements
{
    internal static class Conditions
    {
        public static Dictionary<Type, Dictionary<string, IValueConverter>> dict = new()
        {
            {
                typeof(HeaterWater),
                new()
                {
                    { "LВозд", new Condition<double>(x => x >= Project.VFlow) },
                    { "ШиринаГабарит", new Condition<double>(x => x <= Project.Width) },
                    { "ВысотаГабарит", new Condition<double>(x => x <= Project.Height) },
                    { "Скорость", new Condition<double>(x => x is > 2.5 and < 4.5) },
                }
            },
            {
                typeof(CoolerWater),
                new()
                {
                    { "LВозд", new Condition<double>(x => x >= Project.VFlow) },
                    { "ШиринаГабарит", new Condition<double>(x => x <= Project.Width) },
                    { "ВысотаГабарит", new Condition<double>(x => x <= Project.Height) },
                    { "Скорость", new Condition<double>(x => x is > 2.5 and < 4.5) },
                }
            },
            {
                typeof(CoolerFr),
                new()
                {
                    { "LВозд", new Condition<double>(x => x >= Project.VFlow) },
                    { "ШиринаГабарит", new Condition<double>(x => x <= Project.Width) },
                    { "ВысотаГабарит", new Condition<double>(x => x <= Project.Height) },
                    { "Скорость", new Condition<double>(x => x is > 2.5 and < 4.5) },
                }
            },
            {
                typeof(FanC),
                new()
                {
                    { "NDiff", new Condition<double>(x => x is < 200 and > 0) },
                    { "INSTALLATION_WIDTH_MM", new Condition<double>(x => x <= Project.Width) },
                    { "INSTALLATION_HEIGHT_MM", new Condition<double>(x => x <= Project.Height) },
                }
            }
        };

        private static ProjectInfoVM Project = ProjectVM.Current?.ProjectInfo;

        public static Dictionary<string, IValueConverter> Get(Type t)
                            => dict.ContainsKey(t) ? dict[t] : null;
    }
}