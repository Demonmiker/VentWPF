using PropertyChanged;
using System.Collections;

namespace VentWPF.ViewModel
{
    internal abstract class Query : BaseViewModel
    {
        private IList _Cache;

        public object Source { get; init; }

        public QueryState State { get; set; } = QueryState.New;

        [DependsOn("Cache")]
        public IList Result
        {
            get
            {
                if (State == QueryState.New)
                {
                    State = QueryState.Process;
                    ProjectVM.Current.TaskManager.Add(() =>
                    {
                        Cache = Fill(Source);
                        State = Cache switch
                        {
                            null => QueryState.Error,
                            { Count: 0 } => QueryState.Empty,
                            _ => QueryState.Success,
                        };
                    });
                }

                return Cache;
            }
        }

        private IList Cache

        {
            get => _Cache;
            set => _Cache = value;
        }

        protected abstract IList Fill(object q);
    }

    internal enum QueryState
    {
        New,
        Process,
        Success,
        Empty,
        Error,
    }
}