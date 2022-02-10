using System.Collections;
using System.Linq;

namespace VentWPF.ViewModel
{
    internal class DatabaseQuery<T> : Query
    {
        protected override QueryResult Fill(object q) => new QueryResult() { List = (q as IQueryable<T>).ToList() };
    }
}