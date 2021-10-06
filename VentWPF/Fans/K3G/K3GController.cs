using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text.Json;
using VentWPF.ViewModel;

namespace VentWPF.Fans.K3G
{
    internal class K3GController : IController<K3GRequest, List<K3GFanData>>
    {
        public static string ID;

        public string data;

        private bool connect = false;

        private string Reqest = "[";


        //TODO не используется
        private readonly string path = System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

        public static ProjectInfoVM Project { get; set; } = ProjectVM.Current?.ProjectInfo;

        [DllImport(@"EbmPapstFan.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public static extern int SET_XML_PATH_PC([MarshalAsAttribute(UnmanagedType.AnsiBStr)] string pfad);

        [DllImport(@"EbmPapstFan.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public static extern int GET_PRODUCTS_PC([MarshalAsAttribute(UnmanagedType.AnsiBStr)] ref string pfad);

        [DllImport(@"EbmPapstFan.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public static extern int GET_CCSI_DATA([MarshalAsAttribute(UnmanagedType.AnsiBStr)] string fanDescription, ref string buffer);

        public List<K3GFanData> GetResponce(K3GRequest request)
        {
            if (connect == false)
            {
                connection();
            }
            int n;
            string fanStringChar = new(new Char(), 4000);
            _ = GC.GetTotalMemory(false);
            _ = GC.GetTotalMemory(true);
            string response = null;
            n = GET_PRODUCTS_PC(ref fanStringChar);
            string[] IdNo = new string[n + 1];

            List<string> Nos = FanCollectShow(n, fanStringChar);

            for (int i = 0; i < n; i++)
            {
                ID = Nos[i];
                response += Request(request.GetRequest()) + ";";                
            }

            return response[0] != '[' ? null : JsonSerializer.Deserialize<List<K3GFanData>>(response);
        }

        private static string Request(String req)
        {
            string buffer = new(new Char(), 4000);

            return Marshal.PtrToStringUni((IntPtr)GET_CCSI_DATA(req, ref buffer));
        }


        //ПОДКЛЮЧЕНИЕ К ДЛЛ(НУЖНО ВЫПОЛНИТЬ ОДИН РАЗ, ЕСЛИ ЧТО)
        public void connection()
        {
            bool errors = false;
            Int32 n;
            Int32 l;
            string path = System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            if (File.Exists(path + @"\Data.sqlite"))
            {
                l = path.Length;

                if (path[l - 1] != (';'))
                {
                    path += (';');
                    n = SET_XML_PATH_PC(path);
                    //errors.Text = Convert.ToString(n);
                    //show_Results(n, path);
                }
                else
                {
                    errors = true;
                }
            }
            else
            {
                errors = true;
            }
        }


        #region[OldData]
        //ЗАПРОС К ПОДКЛЮЧЕНИЮ
        public void FanCollection()
        {
            int n;
            string fanStringChar = new(new Char(), 4000);

            _ = GC.GetTotalMemory(false);
            _ = GC.GetTotalMemory(true);

            n = GET_PRODUCTS_PC(ref fanStringChar);
            if (n < 0)
            {
                //errors.Text = "ERROR FanCollection()";
            }
            else
            {
                //errors.Text = Convert.ToString(n);
                FanCollectShow(n, fanStringChar);
            }
        }

        //ПОКАЗАТЬ ВЕНТИЛЯТОРЫ
        public List<string> FanCollectShow(int n, string FanList)
        {
            string[] Typen = new string[n + 1];

            string[] IdNo = new string[n + 1];

            List<string> IDNo = new List<string>();

            int m;
            string temp = "";
            int j = 0;
            int k;
            

            char[] thecopy = new char[FanList.Length];

            FanList = FanList.Replace(';', '|');

            

            n = 1;
            while (FanList.Length > 0)
            {
                m = FanList.IndexOf('|');
                for (k = 0; k < 50; k++)
                {
                    thecopy[k] = '\0';
                }
                FanList.CopyTo(0, thecopy, 0, m);
                while (true)
                {
                    if (thecopy[j] == '\0')
                    {
                        break;
                    }
                    else
                    {
                        temp += thecopy[j];
                        j++;
                    }
                }
                IdNo[n] = temp;
                FanList = FanList.Remove(0, m + 1);
                temp = "";
                j = 0;
                m = FanList.IndexOf('|');
                for (k = 0; k < 50; k++)
                {
                    thecopy[k] = '\0';
                }
                FanList.CopyTo(0, thecopy, 0, m);
                while (true)
                {
                    if (thecopy[j] == '\0')
                    {
                        break;
                    }
                    else
                    {
                        temp += thecopy[j];
                        j++;
                    }
                }
                Typen[n] = temp;
                FanList = FanList.Remove(0, m + 1);
                temp = "";
                j = 0;
                IDNo.Add(IdNo[n]);                
                //FanCalcData();
                n++;
                
            }
            return IDNo;
        }

        //НАЧАЛО ЗАПРОСА РАСЧЁТА
        public void FanCalcData()
        {
            string buffer = new(new Char(), 4000);
            string Input_Data = "";
            int n;
            Input_Data = Get_Input_Value(Input_Data);

            _ = GC.GetTotalMemory(false);
            _ = GC.GetTotalMemory(true);
            n = GET_CCSI_DATA(Input_Data, ref buffer);
            CalcData(buffer);

            //lbInfo.Items.Add(data);
            //lbInfo.Items.Add("\n");
        }

        //РАСЧЁТ ВЕНТИЛЯТОРА
        public void CalcData(string buffer)
        {
            double Volumenstrom = Convert.ToDouble(Project.VFlow) / 3600;
            string tmpDescript;                                                         // Declaration of the variable tmpDescript for copying the values into the array // Deklaration der Variable tmpDescript um die Werte in das Array rein zu kopieren
            int m = 0;                                                                  // m: number of signs till the next semikolon was found // m: Anzahl der Zeichen bis das nächste Semikolon gefunden wurde
            int k;                                                                      // k: counter variable to delete the information of the char array fandescription // K: Zählvariable um die Information zu löschen die in dem char Array fandescription steht
            int j = 0;                                                                  // j: counter variable to fill the information into the string tmpDescript // j: counter variable um die Information in dem string tmp Descript zu füllen
            int zahl = 0;
            string[] Descripts = new string[4000];
            tmpDescript = "";
            char[] fandescription = new char[4000];                                     // Declaration of the char Array fandescription to get the information from the string buffer // Deklaration des char Arrays fandescription um die Information vom string zu bekommen

            while (buffer.Length > 0)
            {
                m = buffer.IndexOf(';');                                                // Get the number of signs till the next semikolon was found // Hole die Anzahl der Zeichen bis das nächste Semikolon gefunden wurde
                for (k = 0; k < 50; k++)
                {
                    fandescription[k] = '\0';                                           // Delete the information // Lösche die Information
                }
                buffer.CopyTo(0, fandescription, 0, m);                                 // Copy one Information into the char array // Kopiere eine Information in das char Array
                while (true)
                {
                    if (fandescription[j] == '\0')                                      // If there is still information(signs) copy it to the string tmp Descript // Wenn immer noch informationen(signs) vorhanden sind, dann füge sie dem string tmpDescript hinzu
                    {
                        break;
                    }
                    else
                    {
                        tmpDescript += fandescription[j];
                    }
                    j++;
                }
                buffer = buffer.Remove(0, m + 1);
                Descripts[zahl] = tmpDescript;                                          // Save the Information in the array
                tmpDescript = "";                                                       // Delete the Information in tmpDescript to get a new Information
                zahl++;
                j = 0;                                                                  // j = 0 because you have to count from the beginning
            }




            /*
            tb_nSoll.Text = Descripts[0];                                               //
            tb_P1Soll.Text = Descripts[1];                                              //
            tb_ISoll.Text = Descripts[2];                                               //
            tb_EtaSoll.Text = Descripts[3];                                             //
            tb_UstSoll.Text = Descripts[4];                                             //
            tb_MdSoll.Text = Descripts[5];                                              //
            textBox1.Text = Descripts[6];                                               //
            tb_LwASoll.Text = Descripts[7];                                             //
            tb_LwAssSoll.Text = Descripts[8];                                           //
            tb_LwAdsSoll.Text = Descripts[9];                                           //

            tb_Lwss62_5_Soll.Text = Descripts[10];                                      //
            tb_Lwss125_Soll.Text = Descripts[11];                                       //
            tb_Lwss250_Soll.Text = Descripts[12];                                       //
            tb_Lwss500_Soll.Text = Descripts[13];                                       //
            tb_Lwss1000_Soll.Text = Descripts[14];                                      //
            tb_Lwss2000_Soll.Text = Descripts[15];                                      //
            tb_Lwss4000_Soll.Text = Descripts[16];                                      //
            tb_Lwss8000_Soll.Text = Descripts[17];                                      // тип

            tb_Lwds62_5_Soll.Text = Descripts[18];                                      //
            tb_Lwds125_Soll.Text = Descripts[19];                                       //
            tb_Lwds250_Soll.Text = Descripts[20];                                       //
            tb_Lwds500_Soll.Text = Descripts[21];                                       //
            tb_Lwds1000_Soll.Text = Descripts[22];                                      //
            tb_Lwds2000_Soll.Text = Descripts[23];                                      //
            tb_Lwds4000_Soll.Text = Descripts[24];                                      //
            tb_Lwds8000_Soll.Text = Descripts[25];                                      //
            tb_PtotSoll.Text = Descripts[26];                                           //
            textBox5.Text = Descripts[27];
            textBox4.Text = Descripts[28];
            textBox7.Text = Descripts[29];
            textBox8.Text = Descripts[30];
            textBox9.Text = Descripts[31];
            tb_EtaMSoll.Text = Descripts[32];
            textBox6.Text = Descripts[33];
            textBox3.Text = Descripts[34];
            textBox2.Text = Descripts[35];
            textBox23.Text = Descripts[36];
            textBox24.Text = Descripts[37];
            textBox25.Text = Descripts[38];
            textBox16.Text = Descripts[39];
            textBox17.Text = Descripts[40];
            textBox22.Text = Descripts[41];
            textBox19.Text = Descripts[42];
            textBox21.Text = Descripts[43];
            textBox20.Text = Descripts[44];
            textBox18.Text = Descripts[45];
            textBox10.Text = Descripts[46];
            textBox15.Text = Descripts[47];
            textBox14.Text = Descripts[48];
            textBox13.Text = Descripts[49];
            textBox12.Text = Descripts[50];
            textBox11.Text = Descripts[51];
            textBox30.Text = Descripts[52];
            textBox31.Text = Descripts[53];
            textBox32.Text = Descripts[54];
            textBox26.Text = Descripts[55];
            textBox27.Text = Descripts[56];
            textBox29.Text = Descripts[57];
            textBox28.Text = Descripts[58];
            */
        }

        //НАСТРОЙКА ЗАПРОСА К ДЛЛ
        private string Get_Input_Value(string Input_Data)
        {
            double Volumenstrom = Project.VFlow / 3600;        //VFlow

            Input_Data = ID + ';' + // the ID // die ID                    // Setze alle Informationen in den String und fülle es mit Semikolon um weitere Informationen zu bekommen
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

        #endregion
    }
}