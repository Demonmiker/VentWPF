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
        public ProjectVM Parent { get; init; } = ProjectVM.Current;


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
                        Top = new SchemeElement[] { new(new HeaterWater()), new(new FanC()) },
                        Bottom = new SchemeElement[] { new(new HeaterElectric()), new(new HumidCell()) },
                    },
                    new SchemeDoubleBlock()
                    {
                        Doubles = new DoubleSchemeElement[]
                        {
                            new DoubleSchemeElement(new DecoyElement(sd),sd),
                        }
                    },
                    new SchemeSingleBlock()
                    {
                        Top = new SchemeElement[] { new(new HeaterElectric()), new(new HumidCell()) },
                        Bottom = new SchemeElement[] { new(new HeaterWater()), new(new FanC()) },
                    },
                    new SchemeDoubleBlock()
                    {
                        Doubles = new DoubleSchemeElement[]
                        {
                            new DoubleSchemeElement(new DecoyElement(sd),sd),
                        }
                    },
                    new SchemeSingleBlock()
                    {
                        Top = new SchemeElement[] { new(new HeaterWater()), new(new FanC()) },
                        Bottom = new SchemeElement[] { new(new HeaterElectric()), new(new HumidCell()) },
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



}