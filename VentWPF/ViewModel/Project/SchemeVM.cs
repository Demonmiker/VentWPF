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
                        Top = new ElementLen[] { new(new HeaterWater()), new(new FanC()) },
                        Bottom = new ElementLen[] { new(new HeaterElectric()), new(new HumidCell()) },
                    },
                    new SchemeDoubleBlock()
                    {
                        Doubles = new ElementTupleLen[]
                        {
                            new ElementTupleLen(new DecoyElement(sd),sd),
                        }
                    },
                    new SchemeSingleBlock()
                    {
                        Top = new ElementLen[] { new(new HeaterElectric()), new(new HumidCell()) },
                        Bottom = new ElementLen[] { new(new HeaterWater()), new(new FanC()) },
                    },
                    new SchemeDoubleBlock()
                    {
                        Doubles = new ElementTupleLen[]
                        {
                            new ElementTupleLen(new DecoyElement(sd),sd),
                        }
                    },
                    new SchemeSingleBlock()
                    {
                        Top = new ElementLen[] { new(new HeaterWater()), new(new FanC()) },
                        Bottom = new ElementLen[] { new(new HeaterElectric()), new(new HumidCell()) },
                    },

                }
            };
            SchemeImage.Blocks[0].First = true;
            if( SchemeImage.Blocks[0] is SchemeSingleBlock ssb2)
            {
                ssb2.Align = HorizontalAlignment.Right;
            }
            if( SchemeImage.Blocks[^1] is SchemeSingleBlock ssb)
            {
                ssb.Align = HorizontalAlignment.Left;
            }

        }
        public SchemeImageVM SchemeImage { get; set; }
    }

    internal class SchemeImageVM : BaseViewModel
    {
        public SchemeBlock[] Blocks { get; set; }
    }

    internal abstract class SchemeBlock 
    {
        public bool First { get; set; }
    }

    internal class SchemeDoubleBlock : SchemeBlock
    {
        public ElementTupleLen[] Doubles { get; set; }
    }

    internal class ElementTupleLen
    {
        public Element Top { get; set; }
        public Element Bottom { get; set; }
        public int Length { get; set; }

        public ElementTupleLen(Element top, Element bottom)
        {
            Top = top;
            Bottom = bottom;
            Length = Math.Max(Top.Length, Bottom.Length);
        }

    }
    internal class ElementLen
    {
        public Element Element { get; set; }
        public int Length { get; set; }

        public ElementLen(Element el)
        {
            Element = el;
            Length = el.Length;
        }

    }

    internal class SchemeSingleBlock : SchemeBlock
    {
        public ElementLen[] Top{ get; set; }

        public ElementLen[] Bottom { get; set; }

        public HorizontalAlignment Align { get; set; } = HorizontalAlignment.Center;
    }
}