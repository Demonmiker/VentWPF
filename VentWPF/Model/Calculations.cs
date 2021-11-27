﻿using System;
using VentWPF.ViewModel;
using PropertyTools.DataAnnotations;
using vm = VentWPF.ViewModel;

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

        [DisplayName("Цена профиля")]
        static int frameBorderPrice { get; set; } = 313;

        [DisplayName("Цена перегородки")]
        static int frameStandPrice { get; set; } = 290;

        [DisplayName("Цена уголка")]
        static int frameCornerPrice { get; set; } = 120;

        #endregion

        public static ProjectInfoVM Project { get; set; } = ProjectVM.Current?.ProjectInfo;
        public static vm.ProjectVM ProjectIT { get; set; } = vm.ProjectVM.Current;

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

        #region[Coolers]
        public static float HumidOut(float temp)
        {
            float HumidOut = 0;
            if (temp < -50)
            {
                return 0;
            }
            if (temp <= 0 && temp > -50)
            {
                HumidOut = (float)Math.Exp((1738.4 + 28.74 * temp) / (271 + temp));
            }
            if (temp > 0 && temp < 100)
            {
                HumidOut = (float)Math.Exp((1500.3 + 23.5 * temp) / (234 + temp));
            }
            if (temp > 100)
            {
                return 0;
            }

            return HumidOut;
        }

        public static float Entolpy(float HumidOutAbs, float temp)
        {
            float OUT;
            //float fi = Humid / 100;
            //float x = (float)0.6222 * fi * HumidOut(temp) / (Project.PressOut - fi * HumidOut(temp) / 1000);
            float x = HumidOutAbs;
            OUT = (float)1.01 * temp + (2501 + (float)1.86 * temp) * x / 1000;
            return OUT;
        }

        public static float HumidOutRel(float TempOut)
        {
            float EnthalpyOut = 0;//Calculations.Entolpy(HumidOutRel, TempOut);
            float HumidOutAbs = (EnthalpyOut - 1.01f * TempOut) / ((float)2501 + (float)1.86 * TempOut) * 1000;
            float OUT = Project.PressOut / HumidOut(TempOut) * 1000 / ((float)0.6222 / (HumidOutAbs * 1000 + 1));

            return OUT;
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
            outData[1] = "обратная";
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
            outData[1] = "низ";
            outData[2] = Convert.ToString(count);
            outData[3] = Convert.ToString(nums);
            outData[4] = Convert.ToString(count * nums);
            return outData;
        }

        static public string[] FrameCorner(int nums)
        {
            string[] outData = new string[4];
            outData[0] = "Уголок " + frameCorner;
            outData[1] = "8";
            outData[2] = "Винты";
            outData[3] = "24";
            return outData;
        }

        static public string[] FrameBorderPrice(float nums)
        {
            string[] Out = new string[4];
            Out[0] = "Профиль" + frameType;
            Out[1] = Convert.ToString(frameBorderPrice);
            Out[2] = Convert.ToString(nums);
            Out[3] = Convert.ToString(nums * frameBorderPrice);
            return Out;
        }

        static public string[] FrameStandPrice(float nums)
        {
            string[] Out = new string[4];
            Out[0] = "Перегородка" + frameStandType;
            Out[1] = Convert.ToString(frameStandPrice);
            Out[2] = Convert.ToString(nums);
            Out[3] = Convert.ToString(nums * frameStandPrice);
            return Out;
        }

        static public string[] FrameCornerPrice(float nums)
        {
            string[] Out = new string[4];
            Out[0] = "Фитинги" + frameCorner;
            Out[1] = Convert.ToString(frameCornerPrice);
            Out[2] = Convert.ToString(nums);
            Out[3] = Convert.ToString(nums * frameCornerPrice);
            return Out;
        }

        #endregion


        public static int GPD()
        {
            int sum = 0;
            //foreach (int i in ProjectVM.Current.Grid.Elements.Count)
            //{
               // sum += Convert.ToInt32(Project.Grid.Elements[i].PressureDrop);
            //}       
            for (int i = 0; i < ProjectVM.Current.Grid.Elements.Count; i++)
            {
                sum += Convert.ToInt32(ProjectIT.Grid.Elements[i].PressureDrop);
            }

            return sum;
        }
    }
}