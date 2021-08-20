﻿using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media;
using VentWPF.Model;

namespace VentWPF.ViewModel
{
    internal class GridVM : BaseViewModel
    {
        #region Properties

        public ErrorManagerVM ErrorManager { get; set; }

        public ObservableCollection<Element> Elements { get; set; }


        private Element _Selected = new Element();
        [DependsOn(nameof(Index))]
        public Element Selected 
        { 
            get => _Selected;
            set { _Selected = value; ChangeInfo(); } 
        } 

        public int Index { get; set; }

        public RichTextBox InfoBox { get; init; } = new RichTextBox() { Focusable = false, Document=new FlowDocument() };


        private void ChangeInfo()
        {
            InfoBox.Document.Blocks.Clear();
            if (Selected?.InfoTable is not null)
                InfoBox.Document.Blocks.Add(_Selected.InfoTable);
        }

        
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

        public void RemoveElement(Element el)
        {
            throw new NotImplementedException("Удаление не реализованно");
        }


        #endregion
    }
}