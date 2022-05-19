using System;
using System.Collections;
using System.Linq;

namespace VentWPF.ViewModel
{
    internal class DatabaseQuery<T> : Query
    {
        protected override QueryResult Fill(object q)
        {
            IList res;
            try
            {
                res = (q as IQueryable<T>).ToList();
                return new QueryResult() { List = (q as IQueryable<T>).ToList()};
            }
            catch(Exception ex)
            {
                return new QueryResult() { List = null, ErrorMessage = ex.Message };
            }
            
        }
    }
}