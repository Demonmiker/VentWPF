using PropertyChanged;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using VentWPF.Tools;

namespace VentWPF.ViewModel.Elements.Base
{
    internal abstract class DatabaseQuery<T> : CustomQuery<IQueryable<T>,T>
    {
        public override IEnumerable<T> Fill(IQueryable<T> q) => q.ToList();
    }
}