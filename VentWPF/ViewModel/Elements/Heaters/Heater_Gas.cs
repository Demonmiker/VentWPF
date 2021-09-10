using PropertyTools.DataAnnotations; using static VentWPF.ViewModel.Strings;
using System;
using System.Collections.Generic;
using System.Linq;
using VentWPF.Model;
using VentWPF.Tools;

namespace VentWPF.ViewModel
{
    internal class Heater_Gas : Heater
    {


       
        public Heater_Gas()
        {
            image = "Heaters/Heater_Gas.png";
        }

        public override string Name => "Нагреватель газовый";

        protected override List<string> InfoProperties => new()
        {
            "Performance",
            "TempIn",
            "TempOut",
            "torch",
        };


        [Category(Data)]
        #region Данные


        [DisplayName("Горелка")]
        public TorchType torch { get; set; }

        #endregion Данные

      

    
    }
}