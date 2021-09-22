using PropertyChanged;
using System.Collections;

namespace VentWPF.ViewModel
{
    internal abstract class Query : BaseViewModel
    {
        private IList _Cache;

        public object Source { get; init; }

        [DependsOn("Cache")]
        public IList Result
        {
            get
            {
                if (Cache == null)
                    if (!InProcess)
                    {
                        InProcess = true;
                        ProjectVM.Current.TaskManager.Add(() =>
                        {
                            Cache = Fill(Source);
                        });
                    }

                return Cache;
            }
        }

        protected bool InProcess { get; set; }

        //Здесь можно создать объект регулирующий релоад запроса
        private IList Cache

        {
            get => _Cache;
            set { InProcess = false; _Cache = value; }
        }

        protected abstract IList Fill(object q);
    }
}