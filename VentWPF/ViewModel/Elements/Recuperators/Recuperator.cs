using PropertyTools.DataAnnotations;
using System;
using static VentWPF.ViewModel.Strings;
using valid = VentWPF.Tools;
using VentWPF.Model.Calculations;

namespace VentWPF.ViewModel.Elements.Recuperators
{
    internal abstract class Recuperator : Element
    {
        public Recuperator()
        {
            ShowPR = true;
            ShowPD = true;
        }

    }
}
