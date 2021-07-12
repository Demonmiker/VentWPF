using PropertyChanged;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using VentWPF.Tools;

namespace VentWPF.ViewModel
{
    internal class DatabaseQuery<T> : Query
    {
        protected override IList Fill(object q) => (q as IQueryable<T>).ToList();

        //protected override IEnumerable<T> Fill(object q)
        //{
        //    throw new System.NotImplementedException();
        //}
    }
}