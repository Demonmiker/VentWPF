using System.Windows.Data;
using VentWPF.Tools;

namespace VentWPF.ViewModel
{
    internal record Column(string Rename=null, IValueConverter Cond=null);
}