using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using VentWPF.Model;

namespace VentWPF.ViewModel
{
    internal class GridVM : BaseViewModel
    {
        #region Properties

        public ErrorManagerVM ErrorManager { get; set; }

        public ObservableCollection<Element> Elements { get; set; }

        public Dictionary<Element,Table> Tables { get; init; }

        [DependsOn("Index")]
        public Element Selected { get; set; } = new Element();

        public int Index { get; set; }

        #endregion

        #region Methods

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
            ErrorManager.AddRange(Enumerable.Range(0, 20).Select(x => ($"[{x % 10 + 1},{x / 10 + 1}]", new Element() as ValidViewModel)));
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
            ErrorManager.Add(Elements[Index], $"[{Index % 10 + 1},{Index / 10 + 1}]");
        }

        #endregion
    }
}