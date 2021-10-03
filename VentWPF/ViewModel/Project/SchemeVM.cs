using System.Collections.Generic;

namespace VentWPF.ViewModel
{
    internal class SchemeVM : BaseViewModel
    {
        public List<ElementPair> Elements { get; init; } = new List<ElementPair>();

        public SchemeVM()
        {
            Elements.Add(new ElementPair() { Top = new Heater_Water(), Bottom = new Humid_Cell(), TwoRows = true });
            Elements.Add(new ElementPair() { Top = new Humid_Cell(), Bottom = new Heater_Water(), TwoRows = true });
        }
    }

    internal struct ElementPair
    {
        public Element Top { get; init; }

        public Element Bottom { get; init; }

        public bool TwoRows { get; init; }
    }
}