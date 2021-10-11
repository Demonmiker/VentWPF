using System;
using VentWPF.ViewModel;
using PropertyTools.DataAnnotations;

namespace VentWPF.Model.Calculations
{
    /// <summary>
    /// Набор функций расчётов элемента
    /// </summary>
    internal static class Calculations
    {
        #region[Constants]
        [DisplayName("Плотность воздуха")]
        static float airCapacity { get; set; } = 1005;

        #endregion

        public static ProjectInfoVM Project { get; set; } = ProjectVM.Current?.ProjectInfo;

        #region[Heaters]
        static public float heaterConsumption(float Power, float TempBegin, float TempEnd)
        {
            float Out = (float)(Power * 1000 / (4198 * (TempBegin - TempEnd))) * 3600;
            return Out;
        }

        static public float heaterHumidOutAbs(float HumidIn, float TempIn)
        {
            float pD = (float)Math.Exp((1500.3 + 23.5 * TempIn) / (234 + TempIn));
            float Out = (float)(0.6222f * (HumidIn / 100f) * pD / (Project.PressOut - HumidIn / 100f * pD / 1000f));
            return Out;
        }

        static public float heaterHumidOutRel(float TempOut, float HumidOutAbs)
        {
            float pD2 = (float)Math.Exp((1500.3 + 23.5 * TempOut) / (234 + TempOut));
            float Out = Project.PressOut / pD2 * 1000f / (0.6222f / HumidOutAbs * 1000f + 1f) * 100f;
            return Out;
        }

        static public float heaterPower(float TempOut, float TempIn)
        {
            float pConst = 353f / (273.15f + TempOut);
            float Out = (float)((Project.VFlow * pConst * airCapacity * Math.Abs(TempIn - TempOut)) / 3600000f);
            return Out;
        }
        #endregion



    }
}