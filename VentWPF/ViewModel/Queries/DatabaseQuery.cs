using System.Collections;
using System.Linq;

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