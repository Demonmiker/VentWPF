using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;

namespace VentWPF.ViewModel
{
    public abstract class ValidViewModel : BaseViewModel, IDataErrorInfo
    {
        [NotMapped]
        [Browsable(false)]
        public string this[string columnName] => OnValidate(columnName);

        private string OnValidate(string propertyName)
        {
            try
            {
                var value = this.GetType().GetProperty(propertyName).GetValue(this, null);
                var results = new List<ValidationResult>();
                var result = Validator.TryValidateProperty(
                    value,
                    new ValidationContext(this, null, null) { MemberName = propertyName },
                    results);
                return !result ? results.Select(x => x.ErrorMessage).Aggregate((a, b) => $"{a}\n{b}") : null;
            }
            catch(Exception ex)
            {
                Debug.WriteLine($"error: {ex}");
                return null;
            }
          
        }

        [NotMapped]
        [Browsable(false)]
        public string Error
        {
            get
            {
                return "";
            }
        }

    }
}
