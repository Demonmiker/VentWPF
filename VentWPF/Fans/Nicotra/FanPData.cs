using PropertyTools.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using static VentWPF.ViewModel.Strings;

namespace VentWPF.Fans.Nicotra
{
    class FanPData
    {
        public FanPData(string KEY, IEnumerable<double> OUT)
        {
            double[] details = OUT.ToArray();
            Id = KEY;
            errors = details[0];
            installationType = details[1];
            airDensity = details[2];
            temperature = details[3];
            height = details[4];
            flowRate = details[5];
            staticPressure = details[6];
            totalPressure = details[7];
            speed = details[8];
            shaftPower = details[9];
            efficiency = details[10];
            soundPowerLevelOut = details[11];
            smallestReqMotor = details[30];
            soundPowerLevelIn = details[31];

        }

        [DisplayName("Название")]
        [FormatString(fNull)]
        public string Id { get; set; }

        [DisplayName("Ошибки")]
        [FormatString(fNull)]
        public double errors { get; set; } //0 n/1/min

        [DisplayName("Тип установки")]
        [FormatString(fEmpty)]
        public double installationType { get; set; }

        [DisplayName("Плотность воздуха")]
        [FormatString(fkgm3)]
        public double airDensity { get; set; }

        [DisplayName("Температура")]
        [FormatString(fT)]
        public double temperature { get; set; }

        [DisplayName("Высота")]
        [FormatString(fm)]
        public double height { get; set; }

        [DisplayName("Поток")]
        [FormatString(fm3Ph)]
        public double flowRate { get; set; }

        [DisplayName("Статичное давление")]
        [FormatString(fPa)]
        public double staticPressure { get; set; }

        [DisplayName("Общее давление")]
        [FormatString(fPa)]
        public double totalPressure { get; set; }

        [DisplayName("Скорость")]
        [FormatString(fRotate)]
        public double speed { get; set; }

        [DisplayName("Мощность на валу")]
        [FormatString(fkW)]
        public double shaftPower { get; set; }

        [DisplayName("КПД")]
        [FormatString(fper)]
        public double efficiency { get; set; }

        [DisplayName("Шум на выходе")]
        [FormatString(fdB)]
        public double soundPowerLevelOut { get; set; }

        [DisplayName("Мощность двигателя")]
        [FormatString(fkPa)]
        public double smallestReqMotor { get; set; }

        [DisplayName("Шум на выходе")]
        [FormatString(fdB)]
        public double soundPowerLevelIn { get; set; }

    }
}
