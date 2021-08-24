using System;
using VentWPF.ViewModel;

namespace VentWPF.Fans.K3G
{
    class K3GRequest : K3GController
    {
        public static ProjectInfoVM Project { get; set; } = ProjectVM.Current?.ProjectInfo;
        //НАЧАЛО ЗАПРОСА РАСЧЁТА
        public void FanCalcData()
        {
            string buffer = new string(new Char(), 4000);
            string Input_Data = "";
            int n;
            Input_Data = Get_Input_Value(Input_Data);

            GC.GetTotalMemory(false);
            GC.GetTotalMemory(true);
            n = GET_CCSI_DATA(Input_Data, ref buffer);
            CalcData(n, buffer);
            //lbInfo.Items.Add(data);
            //lbInfo.Items.Add("\n");
        }
        //НАСТРОЙКА ЗАПРОСА К ДЛЛ
        private string Get_Input_Value(string Input_Data)
        {
            double Volumenstrom = Project.VFlow / 3600;        //VFlow    

            Input_Data = K3GController.ID + ';' + // the ID // die ID                    // Setze alle Informationen in den String und fülle es mit Semikolon um weitere Informationen zu bekommen
                         "0" + ';' +                          // 0 = static Pressure 1 = total pressure
                         "0:DIDO" + ';' +                                 // InstallationType(0:DIDO,1:FIDO,2:DIFO,3:FIFO) 
                         "1.14" + ';' +                                            // AirDensity(kg/m³) 
                         "0" + ';' +                                          // The altitude 
                         "24" + ';' +                                             // AirTemperature(°C) 
                         Project.PFlow + ';' +                                        // requiredPressure(Pa)
                         Convert.ToString(Volumenstrom) + ';' +                         // flowRate(m³/h) 
                         "0" + ';';                                               // Voltage (U) 

            return Input_Data;
        }
    }
}
