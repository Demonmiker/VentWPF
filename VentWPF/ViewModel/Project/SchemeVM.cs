using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using VentWPF.Tools;

namespace VentWPF.ViewModel
{
    internal class SchemeVM : BaseViewModel //ViewModel для самой вкладки а не изображения схемы
    {

        public SchemeVM()
        {
            var sd = new SectionDouble();
            //Здесь тестовая схема
            SchemeImage = new SchemeImageVM()
            {
                Blocks = new SchemeBlock[]
                {
                    new SchemeSingleBlock()
                    {
                        Top = new Element[] { new HeaterWater(), new FanC() },
                        Bottom = new Element[] { new HeaterElectric(), new HumidCell(), new FanP() },
                        Align = HorizontalAlignment.Right,
                    },
                    new SchemeDoubleBlock()
                    {
                        Doubles = new ElementTuple[]
                        {
                            new ElementTuple() {Bottom= sd,Top=new DecoyElement(sd)}
                        }
                    },
                    new SchemeSingleBlock()
                    {
                        Top = new Element[] { new HeaterWater(), new FanC() },
                        Bottom = new Element[] { new HeaterElectric(), new HumidCell(), new FanP() },
                        Align = HorizontalAlignment.Center,
                    },
                    new SchemeDoubleBlock()
                    {
                        Doubles = new ElementTuple[]
                        {
                            new ElementTuple() {Bottom= sd,Top=new DecoyElement(sd)}
                        }
                    },
                    new SchemeSingleBlock()
                    {
                        Top = new Element[] { new HeaterWater(), new FanC() },
                        Bottom = new Element[] { new HeaterElectric(), new HumidCell(), new FanP() },
                        Align = HorizontalAlignment.Left,
                    },

                }
                
            };

        }
        public SchemeImageVM SchemeImage { get; set; }
    }

    internal class SchemeImageVM : BaseViewModel
    {
        public SchemeBlock[] Blocks { get; set; }
    }

    internal abstract class SchemeBlock { }

    internal class SchemeDoubleBlock : SchemeBlock
    {
        public ElementTuple[] Doubles { get; set; }
    }

    internal class ElementTuple
    {
        public Element Top { get; set; }
        public Element Bottom { get; set; }

    }

    internal class SchemeSingleBlock : SchemeBlock
    {
        public Element[] Top{ get; set; }

        public Element[] Bottom { get; set; }

        public HorizontalAlignment Align { get; set; }
    }
}