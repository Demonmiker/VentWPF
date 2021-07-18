﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Text;
using pt = PropertyTools.DataAnnotations;

namespace VentWPF.ViewModel
{
    public abstract class ValidViewModel : BaseViewModel, IDataErrorInfo
    {
        [NotMapped]
        [Browsable(false)]
        public string this[string columnName] => OnPropertyValidation(columnName);

        protected virtual string OnValidation()
        {
            return null;
        }

        protected virtual string OnPropertyValidation(string propertyName)
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
                var sb = new StringBuilder();
                var props = this.GetType().GetProperties().Select(x=>x.Name).Where(x=>x!="Error");
                var error = this.OnValidation();
                if(error!="")
                    sb.Append(this.OnValidation() + "\n");
                foreach (var pr in props)
                {
                    error = this[pr];
                    if(error!=null)
                    {
                        sb.Append(
                            (this.GetType()
                            .GetProperty(pr)
                            .GetCustomAttributes(typeof(pt.DisplayNameAttribute), true)
                            .FirstOrDefault() as pt.DisplayNameAttribute)?.DisplayName ?? pr);
                        sb.Append(": ");
                        sb.Append(this[pr]);
                        sb.Append('\n');
                    }
                   
                }
                return sb.ToString();
            }
        }

    }
}
