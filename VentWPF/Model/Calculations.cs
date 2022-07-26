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
        // TODO: @stigGGGer Перенести всё связанное с каркасом отдельно

        #region Constants 
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

        private static ProjectInfoVM ProjectInfo { get; set; } = ProjectVM.Current?.ProjectInfo;
        private static ProjectVM Project { get; set; } = ProjectVM.Current;

        #region Формулы для нагревателей 
        static public float heaterConsumption(float Power, float TempBegin, float TempEnd)
        {
            float Out = (float)(Power * 1000 / (4198 * (TempBegin - TempEnd))) * 3600;
            return Out;
        }

        static public float heaterHumidOutAbs(float HumidIn, float TempIn)
        {
            float pD = (float)Math.Exp((1500.3 + 23.5 * TempIn) / (234 + TempIn));
            float Out = (float)(0.6222f * (HumidIn / 100f) * pD / (ProjectInfo.Settings.PressOut - HumidIn / 100f * pD / 1000f));
            return Out;
        }

        static public float heaterHumidOutRel(float TempOut, float HumidOutAbs)
        {
            float pD2 = (float)Math.Exp((1500.3 + 23.5 * TempOut) / (234 + TempOut));
            float Out = ProjectInfo.Settings.PressOut / pD2 * 1000f / (0.6222f / HumidOutAbs * 1000f + 1f) * 100f;
            return Out;
        }

        static public float heaterPower(float TempOut, float TempIn)
        {
            float pConst = 353f / (273.15f + TempOut);
            float Out = (float)((ProjectInfo.Settings.VFlow * pConst * airCapacity * Math.Abs(TempIn - TempOut)) / 3600000f);
            return Out;
        }
        #endregion

        #region Формулы для охладителей
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

        public static float Entolpy(float Humid, float temp)
        {
            float OUT;
            float fi = Humid / 100;
            float x = (float)0.6222 * fi * HumidOut(temp) / (ProjectInfo.Settings.PressOut - fi * HumidOut(temp) / 1000);            
            OUT = (float)1.01 * temp + (2501 + (float)1.86 * temp) * x / 1000;
            return OUT;
        }

        public static float HumidOutAbs(float Humid, float TempIn, float TempOut, float TempCoolant)
        {
            return (EntolpyOut(Humid, TempIn, TempOut, TempCoolant) - 1.01f * TempOut) / (2501 + 1.868f * TempOut) * 1000;
        }

        public static float EntolpyOut(float Humid, float TempIn, float TempOut, float TempCoolant)
        {
            float ent = Entolpy(Humid, TempIn);
            return ent - (ent - hIn(TempCoolant)) * (TempOut - TempIn) / (TempCoolant - TempIn);
        }

        private static float hIn(float TempCoolant)
        {
            return 1.01f * TempCoolant + (2501 + 1.86f * TempCoolant) * xPov(TempCoolant) / 1000;
        }

        private static float xPov(float temp)
        {
            float test = HumidOut(temp);
            float OUT = 0.6222f * test / (ProjectInfo.Settings.PressOut - test / 1000);
            return OUT;
        }

        #endregion

        #region Подсчёт деталей каркаса
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

        /// <summary>
        /// Функция подсчитывает падение давления в текущем проекте
        /// </summary>
        /// <returns> Возвращает значения в верхней и нижней части </returns>
        public static float GPD(bool top)
        {
            var grid = Project.Grid.Elements;
            var result = 0f;
            if (top)    // Подсчитываем первые десять элементов (верхний или единственный)
                for (int i = 0; i < 10; i++)
                    result += grid[i].PressureDrop;
            else        // Подсчитываем вторые десять если они есть или будет 0
                for (int i = 10; i < grid.Count; i++)
                    result += grid[i].PressureDrop;
            return result;
        }

        /// <summary>
        /// Функция указывает сопротевление выбранного яруса (приток или вытяжка)
        /// </summary>
        /// <returns> Возвращает значения в верхней или нижней части </returns>
        public static float PressureInfo(bool top)
        {
            var result = 0f;
            if (top)
                result = ProjectInfo.Settings.PFlow;
            else
                result = ProjectInfo.Settings.PReserv;
            return result;
        }

        public static float AirFlow(bool top)
        {
            var result = 0f;
            if (top)
                result = ProjectInfo.Settings.VFlow;
            else
                result = ProjectInfo.Settings.PFlow;
            return result;
        }
    }
}