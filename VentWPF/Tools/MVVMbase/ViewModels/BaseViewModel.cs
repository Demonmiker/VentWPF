using System.ComponentModel;

namespace VentWPF.ViewModel
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        public BaseViewModel()
        {
            PropertyChanged += OnPropChanged;
        }

        protected virtual void OnPropChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName != "Error")
                PropertyChanged(sender, new PropertyChangedEventArgs("Error"));
        }

#pragma warning disable 67

        public event PropertyChangedEventHandler PropertyChanged;

#pragma warning restore 67
    }
}