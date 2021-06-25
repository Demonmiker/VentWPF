﻿using System.IO;

namespace VentWPF.ViewModel
{
    internal class Fan : Element
    {
        public Fan()
        {
            Name = "Вентилятор";
        }

        public Fan_Direction Direction { get; init; } = Fan_Direction.LeftRight;

        public override string Image => Path.GetFullPath($"Assets/Images/Fans/Directions/{Direction}.png");

        //
        //FanData fd;

        //[DisplayName("Элемент:")][Category(c2), PropertyOrder(3)]
        //public string Id => fd?.ARTICLE_NO;
    }
}