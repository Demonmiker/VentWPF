using PropertyTools.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using static VentWPF.ViewModel.Strings;

namespace VentWPF.Fans.Nicotra
{
    internal class FanPData
    {
        public FanPData(string KEY, IEnumerable<double> OUT)
        {
            double[] details = OUT.ToArray();
            Id = KEY;
            errors = details[0];
            InstallationType = details[1];
            AirDensity = details[2];
            Temperature = details[3];
            Height = details[4];
            FlowRate = details[5];
            StaticPressure = details[6];
            TotalPressure = details[7];
            Speed = details[8];
            ShaftPower = details[9];
            Efficiency = details[10] * 100;
            SoundPowerLevelOut = details[11];
            SmallestReqMotor = details[30];
            SoundPowerLevelIn = details[31];
        }

        [DisplayName("Название")]
        public string Id { get; set; }

        public double errors { get; set; }

        // TODO выяснить какие бывают типы установки
        [DisplayName("Тип установки")]
        public double InstallationType { get; set; }

        [DisplayName("Плотность воздуха")]
        [FormatString(fkgm3)]
        public double AirDensity { get; set; }

        [DisplayName("Температура")]
        [FormatString(fT)]
        public double Temperature { get; set; }

        [DisplayName("Высота")]
        [FormatString(fm)]
        public double Height { get; set; }

        [DisplayName("Поток")]
        [FormatString(fm3Ph)]
        public double FlowRate { get; set; }

        [DisplayName("Статичное давление")]
        [FormatString(fPa)]
        public double StaticPressure { get; set; }

        [DisplayName("Общее давление")]
        [FormatString(fPa)]
        public double TotalPressure { get; set; }

        [DisplayName("Скорость")]
        [FormatString(fRotate)]
        public double Speed { get; set; }

        [DisplayName("Мощность на валу")]
        [FormatString(fkW)]
        public double ShaftPower { get; set; }

        [DisplayName("КПД")]
        [FormatString(fper)]
        public double Efficiency { get; set; }

        [DisplayName("Шум на выходе")]
        [FormatString(fdB)]
        public double SoundPowerLevelOut { get; set; }

        [DisplayName("Мощность двигателя")]
        [FormatString(fkPa)]
        public double SmallestReqMotor { get; set; }

        [DisplayName("Шум на выходе")]
        [FormatString(fdB)]
        public double SoundPowerLevelIn { get; set; }
    }
}