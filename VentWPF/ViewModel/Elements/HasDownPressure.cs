using PropertyTools.DataAnnotations;
using VentWPF.Model;

namespace VentWPF.ViewModel
{
    public abstract class HasDownPressure : Element
    {
        public virtual float pressureDrop => 0;
    }
}
