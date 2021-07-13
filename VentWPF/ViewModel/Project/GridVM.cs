using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VentWPF.Model;

namespace VentWPF.ViewModel
{
    class GridVM : BaseViewModel
    {
        public ObservableCollection<Element> Elements { get; set; }

        [DependsOn("Index")]
        public Element Selected { get; set; } = new Element();

        public int Index { get; set; }

        public void Init(Rows rows)
        {
            if (rows == Rows.Одиноярусный)
            {
                Elements = new ObservableCollection<Element>()
                {
                    new(),new(),new(),new(),new(),new(),new(),new(),new(),new(),
                };
            }
            else
            {
                Elements = new ObservableCollection<Element>()
                {
                    new(),new(),new(),new(),new(),new(),new(),new(),new(),new(),
                    new(),new(),new(),new(),new(),new(),new(),new(),new(),new(),
                };
            }
            Index = 0;
        }

        public void AddElement(Element el)
        {
            var ind = Index;
            if (Index >= 0 && Index < Elements.Count)
            {
                Elements[Index] = Element.GetInstance(el);
                Index = ind;
                Elements[Index].SubType = el.SubType;
            }
            Index = ind;
        }
    }
}
