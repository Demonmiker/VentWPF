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

        protected bool InProcess { get; set; }

        //Здесь можно создать объект регулирующий релоад запроса

        private IList _Cache;

        private IList Cache

        {
            get => _Cache;
            set { InProcess = false; _Cache = value; }
        }

        [DependsOn("Cache")]
        public IList Result
        {
            get
            {
                if (Cache == null)
                    if(!InProcess)
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
    }
}