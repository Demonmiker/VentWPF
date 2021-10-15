using System;
using System.Reflection;
using System.Runtime.InteropServices;


namespace VentWPF.Fans.Nicotra
{
    class NICOTRAController
    {
        [DllImport(@"C:\Users\stig1\source\repos\3type\3type\bin\x86\Nicotra.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern int GET_CALCULATION_FANALONE(short s1, short s2, double[] IN, string KEY, short z1, short z2, double[] OUT);

        [DllImport(@"C:\Users\stig1\source\repos\3type\3type\bin\x86\Nicotra.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public static extern int GET_PRODUCTS([MarshalAsAttribute(UnmanagedType.VBByRefStr)] ref string LIST);



        void test()
        {
            var KEY = new string(new Char(), 15);
            KEY = "AT 7-7 S";
            
            
            var LIST = new string(new Char(), 30000);
            int n = GET_PRODUCTS(ref LIST);
            var str = LIST.ToString();
            

            double[] IN =
            {
                1, 1, 0, 24, 5, 600, 100, 150, 0, 0, 0, 0, 0
            };
            short s1 = 0;
            short s2 = 0;
            short z1 = 0;
            short z2 = 0;
            double[] OUT = new double[31];
            foreach (int i in OUT)
            {
                OUT[i] = 0;
            } 
            int e = GET_CALCULATION_FANALONE(s1, s2, IN, KEY, z1, z2, OUT);
        }

    }
}
