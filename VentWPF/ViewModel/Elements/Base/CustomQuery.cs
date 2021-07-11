using PropertyChanged;
using System.Collections;
using System.Collections.Generic;
using VentWPF.Tools;

namespace VentWPF.ViewModel
{
    internal abstract class CustomQuery<Tin,Tout> : BaseViewModel where T : class
    {
        public Tin Query => null;

        public abstract IEnumerable<Tout> Fill(Tin q);

        private IEnumerable<Tout> QueryCache { get; set; }

        [DependsOn("QueryCache")]
        public IEnumerable QueryCollection
        {
            get
            {
                if (Show)
                    if (QueryCache == null)
                        TaskManager.Add(() =>
                        {
                            if (QueryCache == null)
                                QueryCache = Fill(Query);
                        });
                return QueryCache;
            }
        }

        public bool Show { get; init; } = false;
    }
}