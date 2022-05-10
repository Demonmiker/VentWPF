using PropertyTools.DataAnnotations;
using System;
using static VentWPF.ViewModel.Strings;
using valid = VentWPF.Tools;
using VentWPF.Model.Calculations;
using System.IO;

namespace VentWPF.ViewModel
{
    internal abstract class Recuperator : Element, IDoubleMainElement
    {        

        public Recuperator()
        {
            ShowPR = true;
            ShowPD = true;            
        }
        /*
        /// <summary>
        /// Объем притока
        /// </summary>
        [Category(Data)]
        [DisplayName("V приток")]
        [FormatString(Strings.fm3Ph)]
        public float VFlow => ProjectInfo.Settings.VFlow;

        /// <summary>
        /// Объем Вытяжки
        /// </summary>
        [Category(Data)]
        [DisplayName("V вытяжки")]
        [FormatString(Strings.fm3Ph)]
        public float Vflowres => ProjectInfo.Settings.VReserv;

        /// <summary>
        /// Температура внутри
        /// </summary>
        [Category(Data)]
        [DisplayName("Темп. внутр.")]
        [FormatString(Strings.fT)]
        public float Tinside => 20f;

        /// <summary>
        /// Температура снаружи
        /// </summary>
        [Category(Data)]
        [DisplayName("Темп. наруж.")]
        [FormatString(Strings.fT)]
        public float Toutside => 30f;

        /// <summary>
        /// Влажность внутр. возд.
        /// </summary>
        [Category(Data)]
        [DisplayName("Влажность внутр. возд.")]
        [FormatString(Strings.fper)]
        public float Densinside => 45f;

        /// <summary>
        /// Влажность наруж. возд.
        /// </summary>
        [Category(Data)]
        [DisplayName("Влажность наруж. возд.")]
        [FormatString(Strings.fper)]
        public float Densoutside => 85f;
        */
        public Element GetNewTopElement()
        {
            return new DecoyElement()
            {
                name = this.Name,
                image = Path.GetFullPath($"Assets/Images/Icons/Sections/DoubleTop.png")
            };
        }
    }
}
