﻿using System;
using System.Collections.Generic;
using System.Windows.Data;
using VentWPF.Tools;

namespace VentWPF.ViewModel.Elements
{
    internal static class Conditions
    {
        private static ProjectInfoVM Project = ProjectVM.Current?.ProjectInfo;

        public static Dictionary<string, IValueConverter> Get(Element el)
        {
            return el switch
            {
                HeaterWater => new()
                {
                    { "LВозд", new Condition<double>(x => x >= Project.Settings.VFlow) },
                    { "ШиринаГабарит", new Condition<double>(x => x <= Project.Settings.Width) },
                    { "ВысотаГабарит", new Condition<double>(x => x <= Project.Settings.GetHeight(el)) },
                    { "Скорость", new Condition<double>(x => x is > 2.5 and < 4.5) },
                },
                CoolerWater => new()
                {
                    { "LВозд", new Condition<double>(x => x >= Project.Settings.VFlow) },
                    { "ШиринаГабарит", new Condition<double>(x => x <= Project.Settings.Width) },
                    { "ВысотаГабарит", new Condition<double>(x => x <= Project.Settings.GetHeight(el)) },
                    { "Скорость", new Condition<double>(x => x is > 2.5 and < 4.5) },
                },
                CoolerFr => new()
                {
                    { "LВозд", new Condition<double>(x => x >= Project.Settings.VFlow) },
                    { "ШиринаГабарит", new Condition<double>(x => x <= Project.Settings.Width) },
                    { "ВысотаГабарит", new Condition<double>(x => x <= Project.Settings.GetHeight(el)) },
                    { "Скорость", new Condition<double>(x => x is > 2.5 and < 4.5) },
                },
                FanC => new()
                {
                    { "NDiff", new Condition<double>(x => x is < 200 and > 0) },
                    { "INSTALLATION_WIDTH_MM", new Condition<double>(x => x <= Project.Settings.Width) },
                    { "INSTALLATION_HEIGHT_MM", new Condition<double>(x => x <= Project.Settings.GetHeight(el)) },
                },
                _ => new() { }
            };
        }
    }
}