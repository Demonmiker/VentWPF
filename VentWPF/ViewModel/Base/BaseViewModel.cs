using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace VentWPF.ViewModel
{
    public class BaseViewModel : INotifyPropertyChanged
    {
#pragma warning disable 67
        public event PropertyChangedEventHandler PropertyChanged;
#pragma warning restore 67

        //public void OnPropertyChanged(string propertyName, object before, object after)
        //{

        //    //if (propertyName != nameof(Error))
        //    //    OnPropertyChanged(nameof(Error), "", Error);
        //}
    }
}
