using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VentWPF.Model;

namespace VentWPF.ViewModel
{
    class Heater_Gas : HasDownPressure
    {
        public Heater_Gas()
        {
            Name = "Нагреватель газовый";
        }
        
        [DisplayName("Производительность"), Category(c1), PropertyOrder(1)]
        public float performance => project.VFlow;

        [DisplayName("t наружного воздуха"), Category(c1), PropertyOrder(2)]
        public float tOutside => project.temp;

        [DisplayName("t воздуха на выходе"), Category(c1), PropertyOrder(3)]
        public float tOut { get; set; } = 18;


        [DisplayName("Влажность наружного воздуха"), Category(c1), PropertyOrder(6)]
        public float humidityOutSide { get; set; } = project.Humid;

        [DisplayName("Горелка"), Category(c1), PropertyOrder(7)]
        public torchType torch { get; set; }


        private float AB = (((float)project.With / 1000) * ((float)project.Height / 1000));

        [DisplayName("Падение давления расчётное"), Category(c2), PropertyOrder(1)]
        public override float pressureDrop => (70 / (4 / (((float)project.VFlow / 3600) / AB)));


        [DisplayName("Мощность воздухонагревателя, кВТ"), Category(c2), PropertyOrder(3)]
        //public float Power => (float)(project.VFlow * Math.Abs(tOutside - tOut) * 0.336 * 1.23 * 1);
        public float Power => (float)(project.VFlow * (353 / (273.15 + tOut)) / 3600000 * 1009 * Math.Abs(tOutside - tOut));

        [Browsable(false)]
        public float pD => (float)(Math.Exp((1500.3 + 23.5 * tOutside) / (234 + tOutside)));

        [DisplayName("Абсолютная влажность воздуха на выходе"), Category(c2), PropertyOrder(4)]
        public float humidityOut => (float)((0.6222 * (humidityOutSide / 100) * pD) / (project.PressOut - (humidityOutSide / 100) * pD / 1000));

        [Browsable(false)]
        public float pD2 => (float)(Math.Exp((1500.3 + 23.5 * tOut) / (234 + tOut)));

        [DisplayName("Относительная влажность воздуха на выходе"), Category(c2), PropertyOrder(4)]
        public int humidityOutOtn => (int)((project.PressOut / pD2 * 1000 / (0.6222 / humidityOut * 1000 + 1)) * 100);
        
    }
}
