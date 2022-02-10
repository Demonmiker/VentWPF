using PropertyChanged;
using System.Collections;

namespace VentWPF.ViewModel
{
    internal abstract class Query : BaseViewModel
    {
        private QueryResult _Cache = new QueryResult();

        [DependsOn("Cache")]
        public string ErrorMessage => _Cache.ErrorMessage;

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
                        if (Source is null)
                            throw new System.Exception("Source was 'null'");
                        Cache = Fill(Source);
                        if(Cache.ErrorMessage is not null)
                        {
                            State = QueryState.Error;
                        }
                        else
                        {
                            if (Cache.List.Count == 0) 
                                State = QueryState.Empty;
                            else 
                                State = QueryState.Success;
                        }
                    });
                }

                return Cache.List;
            }
        }

        private QueryResult Cache

        {
            get => _Cache;
            set => _Cache = value;
        }

        protected abstract QueryResult Fill(object q);
    }

    internal enum QueryState
    {
        New,
        Process,
        Success,
        Empty,
        Error,
    }

    internal class QueryResult
    {
        public IList List { get; init; }
        public string ErrorMessage { get; init; }
    }
}