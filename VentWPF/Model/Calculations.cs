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

        [DisplayName("Погрешность")]
        static int error { get; set; } = 117;

        [DisplayName("Имя профиля каркаса")]
        static string frameType { get; set; } = " НЧП 4415 ";

        [DisplayName("Имя профиля стойки")]
        static string frameStandType { get; set; } = " НЧП 4416 ";

        [DisplayName("Имя уголка")]
        static string frameCorner { get; set; } = " АВР 330 ";

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

        #region[Frame]
        static public string[] FrameOutCalcWitdh(int width)
        {
            int count = width - error;
            string[] outData = new string[5];
            outData[0] = "Профиль каркаса" + frameType;
            outData[1] = "ширина";
            outData[2] = Convert.ToString(count);
            outData[3] = "4";
            outData[4] = Convert.ToString(count * 4);
            return outData;
        }

        static public string[] FrameOutCalcLenght(int lenght)
        {
            int count = lenght - error;
            string[] outData = new string[5];
            outData[0] = "Профиль каркаса" + frameType;
            outData[1] = "длина";
            outData[2] = Convert.ToString(count);
            outData[3] = "4";
            outData[4] = Convert.ToString(count * 4);
            return outData;
        }

        static public string[] FrameOutCalcHeight(int height)
        {
            int count = height - error;
            string[] outData = new string[5];
            outData[0] = "Профиль каркаса" + frameType;
            outData[1] = "высота";
            outData[2] = Convert.ToString(count);
            outData[3] = "4";
            outData[4] = Convert.ToString(count * 4);
            return outData;
        }

        static public string[] FrameStandCalcTop(int top, int nums)
        {
            int count = top - error;
            string[] outData = new string[5];
            outData[0] = "Профиль стойки" + frameStandType;
            outData[1] = "верх";
            outData[2] = Convert.ToString(count);
            outData[3] = Convert.ToString(nums);
            outData[4] = Convert.ToString(count * nums);
            return outData;
        }

        static public string[] FrameStandCalcServ(int top, int nums)
        {
            int count = top - error;
            string[] outData = new string[5];
            outData[0] = "Профиль стойки" + frameStandType;
            outData[1] = "ст обслуж";
            outData[2] = Convert.ToString(count);
            outData[3] = Convert.ToString(nums);
            outData[4] = Convert.ToString(count * nums);
            return outData;
        }

        static public string[] FrameStandCalcBack(int top, int nums)
        {
            int count = top - error;
            string[] outData = new string[5];
            outData[0] = "Профиль стойки" + frameStandType;
            outData[1] = "верх";
            outData[2] = Convert.ToString(count);
            outData[3] = Convert.ToString(nums);
            outData[4] = Convert.ToString(count * nums);
            return outData;
        }

        static public string[] FrameStandCalcUnder(int top, int nums)
        {
            int count = top - error;
            string[] outData = new string[5];
            outData[0] = "Профиль стойки" + frameStandType;
            outData[1] = "верх";
            outData[2] = Convert.ToString(count);
            outData[3] = Convert.ToString(nums);
            outData[4] = Convert.ToString(count * nums);
            return outData;
        }
        #endregion

    }
}