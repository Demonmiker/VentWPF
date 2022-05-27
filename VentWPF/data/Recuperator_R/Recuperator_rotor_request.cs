using ERIREC;
using ERIREC.Abstracts;
using ERIREC.Entities;
using ERIREC.Entities.Public;
using ERIREC.Entities.Public.Input;
using ERIREC.Entities.Public.Result;
using ERIREC.Enums;
using System;
using System.Globalization;
using System.Windows;
using VentWPF.Fans;

namespace VentWPF.data
{
    internal class Recuperator_rotor_request 
    {
        private static IEriRheCalculator calc;

        public double IN_S_Airflow { get; set; }
        public double IN_S_Temperature { get; set; }
        public double IN_S_RelativeHumidity { get; set; }
        public double IN_E_Airflow { get; set; }
        public double IN_E_Temperature { get; set; }
        public double IN_E_RelativeHumidity { get; set; }
        public double IN_PressureDifference { get; set; }

        public double IN_WheelDiameter { get; set; }

        public double IN_CasingHeight { get; set; }
        public double IN_CasingLength { get; set; }
        public double IN_CasingWidth { get; set; }

        private static readonly CultureInfo enusCultureInfo = new CultureInfo("en-US");

        private static ERIRotaryProjectInfo GetProjectInfo()
        {
            return new ERIRotaryProjectInfo()
            {
                Name = "TEST PROJECT",
                Customer = "TEST CUSTOMER"
            };
        }

        private static EriRheInputPriceConfiguration GetPriceConfiguration()
        {
            return new EriRheInputPriceConfiguration()
            {
                CurrencyCultureInfo = enusCultureInfo,
                EuroToCurrencyCoefficient = 1
            };
        }

        public static EriRheMResultData GetRequest(double S_A, double S_T, double S_R,
            double E_A, double E_T, double E_R, double W_D, double C_H, double C_W)
        {
            var IN = new EriRheInputData()
            {
                S_Airflow = S_A,
                S_Temperature = S_T,
                S_RelativeHumidity = S_R,

                E_Airflow = E_A,
                E_Temperature = E_T,
                E_RelativeHumidity = E_R,

                PressureDifference = 0,

                UseStandardAirflow = true,

                PriceConfiguration = GetPriceConfiguration(),
                ProjectInfo = GetProjectInfo(),
                Season = EriRheSeason.SUMMER,
                InputConfiguration = new EriRotaryInputConfiguration()
                {
                    Wheel = WheelConfiguration(W_D),
                    Casing = CasingConfiguration(),
                    MotorDrive = MotorConfiguration(),
                    ConfigurationType = EriRheRotaryConfigurationType.ByWheel
                }
            };            
            var pb = new EriRhePlatformBuilder();
            calc = pb.Build();
            try
            {
                EriRheMResultData result = calc.Calculate(IN);
                return result;
            }
            catch (Exception error)
            {
                MessageBox.Show(error.ToString());
                return null;
            }
            
        }

        

        private static EriRotaryInputWheelConfiguration WheelConfiguration(double W_D)
        {
            return new EriRotaryInputWheelConfiguration()
            {
                WheelDiameter = 1200,
                WheelWaveHeight = EriRheWheelWaveHeight.A16,
                WheelWidth = EriRheWheelWidth.WW_200,
                WheelSurfaceType = EriRheWheelSurfaceType.CONDENSATION
            };
        }

        private static EriRotaryInputCasingConfiguration CasingConfiguration()
        {
            return new EriRotaryInputCasingConfiguration()
            {
                CasingHeight = 1300,
                CasingLength = 1300,
                CasingWidth = 290,
                ArrangementType = EriRheArrangementType.A,
                CasingType = EriRheCasingType.GalvanizedSteel
            };
        }

        private static EriRotaryInputMotorDriveConfiguration MotorConfiguration()
        {
            return new EriRotaryInputMotorDriveConfiguration()
            {
                MotorDriveType = EriRheMotorDriveType.DmConstant3,
                EriRheMotorDriveMountingSide = EriRheMotorDriveMountingSide.DMMS1
            };
        } 
       
    }
}

/* вывод данных: (исходные данные (мануал) для разработки)
 * Console.WriteLine("Heat / Supply:");             Горячая часть вход
            Console.WriteLine("\tInlet:");
            Console.WriteLine("\t\tStandard Airflow: {0}", r.S_Airflow.ToString());
            Console.WriteLine("\t\tActual Airflow: {0}", r.S_ActualAirflow.ToString());
            Console.WriteLine("\t\tMass flow: {0}", r.S_Massflow.ToString());
            Console.WriteLine("\t\tTemperature BEFORE heat exchange: {0}", r.S_Temperature.ToString());
            Console.WriteLine("\t\tWater content BEFORE heat exchange: {0}", r.S_BE_WaterContent.ToString());
            Console.WriteLine("\t\tRelative humidity BEFORE heat exchange: {0}", r.S_RelativeHumidity.ToString());
            Console.WriteLine("\t\tEnthalpy BEFORE heat exchange: {0}", r.S_BE_Enthalpy.ToString());
            Console.WriteLine();

            Console.WriteLine("\tOutlet:");               Выход
            Console.WriteLine("\t\tActual Airflow: {0}", r.S_AE_ActualAirflow.ToString());
            Console.WriteLine("\t\tMass flow: {0}", r.S_AE_Massflow.ToString());
            Console.WriteLine("\t\tTemperature AFTER heat exchange: {0}", r.S_AE_Temperature.ToString());
            Console.WriteLine("\t\tWater content AFTER heat exchange: {0}", r.S_AE_WaterContent.ToString());
            Console.WriteLine("\t\tRelative humidity AFTER heat exchange: {0}", r.S_AE_RelativeHumidity.ToString());
            Console.WriteLine("\t\tEnthalpy AFTER heat exchange: {0}", r.S_AE_Enthalpy.ToString());
            Console.WriteLine("\t\tVelocity AFTER heat exchange: {0}", r.S_VelocityFace.ToString());
            Console.WriteLine();

            Console.WriteLine("\tPressure drop (actual / standard): {0} / {1}", r.S_PressureDropActualAirflow.ToString(), r.S_PressureDrop.ToString());
            Console.WriteLine("\tTemperature efficiency: {0}", r.S_TemperatureEfficiency.ToString());
            Console.WriteLine("\tHumidity efficiency: {0}", r.S_HumidityEfficiency.ToString());
            Console.WriteLine("\tLatent heat recovery: {0}", r.S_HR_Latent.ToString());
            Console.WriteLine("\tSensible heat recovery: {0}", r.S_HR_Sensible.ToString());
            Console.WriteLine("\tTotal heat recovery: {0}", r.S_HR_Total.ToString());
            Console.WriteLine("\tMoisture transfer: {0}", r.S_Condensation.ToString());

            Console.WriteLine("\nCool / Exhaust:");         холодная часть вход
            Console.WriteLine("\tInlet:");
            Console.WriteLine("\t\tStandard Airflow: {0}", r.E_Airflow.ToString());
            Console.WriteLine("\t\tActual Airflow: {0}", r.E_ActualAirflow.ToString());
            Console.WriteLine("\t\tMass flow: {0}", r.E_Massflow.ToString());
            Console.WriteLine("\t\tTemperature BEFORE heat exchange: {0}", r.E_Temperature.ToString());
            Console.WriteLine("\t\tWater content BEFORE heat exchange: {0}", r.E_BE_WaterContent.ToString());
            Console.WriteLine("\t\tRelative humidity BEFORE heat exchange: {0}", r.E_RelativeHumidity.ToString());
            Console.WriteLine("\t\tEnthalpy BEFORE heat exchange: {0}", r.E_BE_Enthalpy.ToString());
            Console.WriteLine();

            Console.WriteLine("\tOutlet:");   выход
            Console.WriteLine("\t\tActual Airflow: {0}", r.E_AE_ActualAirflow.ToString());
            Console.WriteLine("\t\tMass flow: {0}", r.E_AE_Massflow.ToString());
            Console.WriteLine("\t\tTemperature AFTER heat exchange: {0}", r.E_AE_Temperature.ToString());
            Console.WriteLine("\t\tWater content AFTER heat exchange: {0}", r.E_AE_WaterContent.ToString());
            Console.WriteLine("\t\tRelative humidity AFTER heat exchange: {0}", r.E_AE_RelativeHumidity.ToString());
            Console.WriteLine("\t\tEnthalpy AFTER heat exchange: {0}", r.E_AE_Enthalpy.ToString());
            Console.WriteLine("\t\tVelocity AFTER heat exchange: {0}", r.E_VelocityFace.ToString());
            Console.WriteLine();

            Console.WriteLine("\tPressure drop (actual / standard): {0} / {1}", r.E_PressureDropActualAirflow.ToString(), r.E_PressureDrop.ToString());
            Console.WriteLine("\tLatent heat recovery: {0}", r.E_HR_Latent.ToString());
            Console.WriteLine("\tSensible heat recovery: {0}", r.E_HR_Sensible.ToString());
            Console.WriteLine("\tTotal heat recovery: {0}", r.E_HR_Total.ToString());
            Console.WriteLine("\tMoisture transfer: {0}", r.E_Condensation.ToString());
 * 
 * 
 * записки:
 * 1)Использовать датагрид для вывода всех этих данных? Но как?
 * 2)обновлять по кнопке? А какой?
 * 3)Перерасчет длится секунды 2-3, нельзя обновлять при каждой смене значений - надо решить как сделать
 * 4)Роторный сделать как надо, пластинчатый по образцу роторного
 * 5)проверить как копируются ДЛЛ в итоговый проект
 */
