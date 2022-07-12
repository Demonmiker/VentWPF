using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using ERICEC;
using ERICEC.Abstracts;
using ERICEC.Abstracts.Entities;
using ERICEC.Entities;
using ERICEC.Entities.Attributes;
using ERICEC.Enums;
using ERICEC.Helper.Converter;

namespace VentWPF.data.Recuperator_P
{
    class Recuperator_plast_request
    {
        public static string AssemblyDirectory
        {
            get
            {
                var codeBase = Assembly.GetExecutingAssembly().CodeBase;
                var uri = new UriBuilder(codeBase);
                var path = Uri.UnescapeDataString(uri.Path);
                return Path.GetDirectoryName(path);
            }
        }

        /// <summary>
        /// </summary>
        public static AssemblyName Core
        {
            get
            {
                return
                    Assembly.GetExecutingAssembly()
                        .GetReferencedAssemblies()
                        .FirstOrDefault(el => el.Name == "ERI.Counterflow.Core");
            }
        }

        public static void BigAiflowCalculation(ICounterflowCalculator c)
        {
            var d = new ERICounterflowInputData
            {
                S_Airflow = 3000,
                S_Temperature = -3,
                S_RelativeHumidity = 60,
                E_Airflow = 3000,
                E_Temperature = 25,
                E_RelativeHumidity = 56,
                ModelName = "PCF 62",
                Width = 300,
                MaterialType = MaterialType.PLAIN_ALUMINIUM,
                PlatesDistance = PlatesDistance.PD_2p1,
                Season = Season.WINTER,
                UseStandardAirflow = true,
                IncludeAntibacterialTreatment = false,
                IncludePlasticStripHandle = true,
                IncludeInnerSealing = false,

                ProjectInfo = new ERICounterflowProjectInfo
                {
                    Customer = "TEST CLIENT",
                    Name = "TEST PROJECT"
                }
            };
            ERICounterflowOperationMessage m;
            var calculationResults = c.Calculate(d, out m);

            if (!ReferenceEquals(m, null))
            {
                Console.WriteLine(m.Message);
            }

            if (ReferenceEquals(calculationResults, null)) return;

            PrintResult(calculationResults);
        }

        public static void PrintResult(ERICounterflowMResultData calculationResults, string[] markProperties = null)
        {
            var t1 = "{0}: [Property name: {1}]: {2} ";
            var t2 = "{0}: [Property name: {1}]: Customer: {2}; Project name: {3}";
            var t3 = "{0}: [Property name: {1}]: License holder: {2}; Is expired: {3}";
            var t4 = "{0}: [Property name: {1}]: [A: {2}] [B: {3}] [E: {4}] [F: {5}] [G: {6}] [Plates distance: {7}]";
            var t5 = "{0}: [Property name: {1}]: [Bypass type: {2}] [Bypass position: {3}] [Bypass Pressure drop: {4}] [Bypass Width: {5}]";
            var t6 = "\r\n{0}: [Property name: {1}]: [Damper shaft position: {2}] [Damper type: {3}] [Return Air Damper: {4}]";

            foreach (var p in calculationResults.GetType().GetProperties())
            {
                var rs = string.Empty;

                var v = p.GetValue(calculationResults);
                var la = p.GetCustomAttribute(typeof(LocalizedDisplayNameAttribute)) as LocalizedDisplayNameAttribute;
                var name = ReferenceEquals(la, null) ? p.Name : la.DisplayName;

                var pq = v as PhysicalQuantity;
                if (!ReferenceEquals(pq, null))
                    rs = string.Format(t1, name, p.Name, pq.ToString(2));

                var pi = v as ERICounterflowProjectInfo;
                if (!ReferenceEquals(pi, null))
                    rs = string.Format(t2, name, p.Name, pi.Customer, pi.Name);

                var pb = v as ICounterflowResultBypassConfiguration;
                if (!ReferenceEquals(pb, null))
                {
                    rs = string.Format(t5, name, p.Name, pb.Type, pb.Position, pb.PressureDrop.ToString(0), pb.Width.ToString(0));

                    var pc = pb.ResultDamperConfiguration;
                    if (!ReferenceEquals(pc, null))
                    {
                        var pcName = pb.GetDisplayName(nameof(pb.ResultDamperConfiguration));
                        rs += string.Format(t6, ReferenceEquals(pcName, null) ? nameof(pb.ResultDamperConfiguration) : pcName, nameof(pb.ResultDamperConfiguration), pc.DamperShaftPosition, pc.DamperShaft, pc.IncludeReturnAirDamper);
                    }
                }

                var pl = v as ERICounterflowLicenseInfo;
                if (!ReferenceEquals(pl, null))
                    rs = string.Format(t3, name, p.Name, pl.LicenseHolder, pl.IsExpired ? "Yes" : "No");

                var pm = v as ICounterflowExchangerDimensions;
                if (!ReferenceEquals(pm, null))
                    rs = string.Format(t4, name, p.Name, pm.A.ToString(2), pm.B.ToString(2), pm.E.ToString(2),
                        pm.F.ToString(2), pm.G.ToString(2), calculationResults.PlatesDistanceValue.ToString(2));

                var ps = v as string;
                if (!ReferenceEquals(ps, null))
                    rs = string.Format(t1, name, p.Name, ps);

                var pe = v as Enum;
                if (!ReferenceEquals(pe, null))
                    rs = string.Format(t1, name, p.Name, pe);

                var pd = v as ICounterflowPriceInfo;
                if (!ReferenceEquals(pd, null))
                    rs = string.Format(t1, name, p.Name, pd.TotalPrice.Equals(0) ? "No price information" : $"{Math.Round(pd.TotalPrice, 2)} EUR");

                var pn = v as int? ?? -1;
                if (pn != -1)
                    rs = string.Format(t1, name, p.Name, pn);

                if (string.IsNullOrEmpty(rs)) continue;

                var isColored = !ReferenceEquals(markProperties, null) && markProperties.Contains(p.Name);

                Console.ForegroundColor = isColored ? ConsoleColor.Green : ConsoleColor.White;
                Console.WriteLine(rs);
                Console.ForegroundColor = ConsoleColor.White;
            }            
        }

    }
}
