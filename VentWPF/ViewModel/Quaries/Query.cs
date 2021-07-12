using PropertyChanged;
using System.Collections;
using System.Collections.Generic;
using VentWPF.Tools;

namespace VentWPF.ViewModel
{
    internal abstract class Query : BaseViewModel
    {
        public object Source { get; init; }

        protected abstract IList Fill(object q);

        //Здесь можно создать объект регулирующий релоад запроса

        private IList Cache { get; set; }

        [DependsOn("Cache")]
        public IList Result
        {
            get
            {
                if (Cache == null)
                    TaskManager.Add(() =>
                    {
                        if (Cache == null)
                            Cache = Fill(Source);
                    });
                return Cache;
            }
        }
    }
}