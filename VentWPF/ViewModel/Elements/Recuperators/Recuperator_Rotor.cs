using ERIREC.Entities.Public.Result;
using PropertyTools.DataAnnotations;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using VentWPF.data;
using VentWPF.Model;
using VentWPF.Model.Calculations;
using static VentWPF.ViewModel.Strings;


namespace VentWPF.ViewModel
{
    class Recuperator_Rotor : Recuperator
    {
        public override void UpdateQuery()
        {
            Query = new DatabaseQuery<РоторныйРегенератор>
            {
                Source = from h in VentContext.Instance.РоторныйРегенераторs select h
            };
        }

        public override Type DeviceType => typeof(РоторныйРегенератор);

        public override string Image => ImagePath("Heaters/Water");

        public override int Width => (int)((DeviceData as РоторныйРегенератор)?.With ?? 0);

        public override int Height => (int)((DeviceData as РоторныйРегенератор)?.Heinht ?? 0);

        public override int Length => 400;

        public override string Name => $"Роторный Рекуператор {(DeviceData as ВодаТепло)?.Типоряд}";

        [Browsable(false)]
        public EriRheMResultData Result => Recuperator_rotor_request.GetRequest(S_Airflow, S_Temperature,
            S_RelativeHumidity, E_Airflow, E_Temperature, E_RelativeHumidity, E_Diam, ProjectInfo.Settings.TopHeight, ProjectInfo.Settings.Width);
        /// <summary>
        /// КПД
        /// </summary>
        [Category(Data)]
        [DisplayName("Объём притока")]
        [FormatString(Strings.fkgm3)]
        public double S_Airflow { get; set; } = ProjectInfo.Settings.VFlow;
        
        /// <summary>
        /// КПД
        /// </summary>
        [Category(Data)]
        [DisplayName("Объём вытяжки")]
        [FormatString(Strings.fkgm3)]
        public double E_Airflow { get; set; } = ProjectInfo.Settings.VReserv;
        
        /// <summary>
        /// Температура входа
        /// </summary>
        [Category(Data)]
        [DisplayName("Темп. входа")]
        [FormatString(Strings.fT)]
        public double S_Temperature { get; set; } = -5;

        /// <summary>
        /// Температура выхода
        /// </summary>
        [Category(Data)]
        [DisplayName("Темп. выхода")]
        [FormatString(Strings.fT)]
        public double E_Temperature { get; set; } = 25;

        /// <summary>
        /// Влажность входа
        /// </summary>
        [Category(Data)]
        [DisplayName("Влаж. входа")]
        [FormatString(Strings.fper)]
        public double S_RelativeHumidity { get; set; } = 80;

        /// <summary>
        /// Влажность выхода
        /// </summary>
        [Category(Data)]
        [DisplayName("Влаж. выхода")]
        [FormatString(Strings.fper)]
        public double E_RelativeHumidity { get; set; } = 60;

        [Category(Data)]
        [DisplayName("Диаметр колеса")]
        [FormatString(Strings.fper)]
        public double E_Diam { get; set; } = 1200;

        protected override float GenPD() => (float)(Result.BarometricPressure.Value / 1000);

        [Category(Info)]
        [DisplayName("Фактический поток вытяжки")]
        [FormatString(Strings.fkgm3)]
        public double E_ActualAirflow => Result.E_ActualAirflow.Value;
                
        [Category(Info)]
        [DisplayName("Массовый расход вытяжки")]
        [FormatString(Strings.fkgm3)]
        public double TEST => Result.E_AE_Massflow.Value;

        public override List<string> InfoProperties => new()
        {

        };        
        
    }
}
