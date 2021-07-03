using PropertyTools.DataAnnotations;
using System;
using VentWPF.Model;

namespace VentWPF.ViewModel
{
    internal class Heater_Gas : Heater
    {
        private float AB = (((float)Project.Width / 1000) * ((float)Project.Height / 1000));

        public Heater_Gas()
        {
            Name = "Нагреватель газовый";
            image = "Heaters/Heater_Gas.png";
        }

        [Category(Data)]
        #region Данные


        [DisplayName("Горелка")]
        public TorchType torch { get; set; }

        #endregion Данные

      

    
    }
}