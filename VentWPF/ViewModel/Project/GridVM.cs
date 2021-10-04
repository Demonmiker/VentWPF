using PropertyChanged;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Documents;
using VentWPF.Model;

namespace VentWPF.ViewModel
{
    /// <summary>
    /// Представление Сетки конструктора вентиляции
    /// </summary>
    internal class GridVM : BaseViewModel
    {
        private Element _Selected = new();

        /// <summary>
        /// Менеджер ошибок
        /// </summary>
        public ErrorManagerVM ErrorManager { get; set; }

        /// <summary>
        /// Элементы в установке
        /// </summary>
        public ObservableCollection<Element> Elements { get; set; }

        /// <summary>
        /// Выбранный элемент в установке
        /// </summary>
        [DependsOn(nameof(Index))]
        public Element Selected
        {
            get => _Selected;
            set
            {
                _Selected = value;
                ChangeInfo();
            }
        }

        /// <summary>
        /// Индекс выбранного элемента
        /// </summary>
        public int Index { get; set; }

        /// <summary>
        /// Текстовое поле для показа информации
        /// </summary>
        public RichTextBox InfoBox { get; init; } = new RichTextBox() { Focusable = false, Document = new FlowDocument() };

        public void Init(Rows rows)
        {
            if (rows == Rows.Одноярусный)
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

        /// <summary>
        /// Добавить элемент в установку
        /// </summary>
        /// <param name="el">добавляемый элементы</param>
        public void AddElement(Element el)
        {
            int ind = Index;
            if (Index >= 0 && Index < Elements.Count)
            {
                Elements[Index] = Element.GetInstance(el);
                Index = ind;
                Elements[Index].SubType = el.SubType;
            }
            Index = ind;
            ErrorManager.Add(Elements[Index], $"[{Index % 10 + 1},{Index / 10 + 1}]");
        }

        /// <summary>
        /// Удалить элемент
        /// </summary>
        /// <param name="el">удаляемый элемент</param>
        public void RemoveElement(Element el)
        {
            throw new NotImplementedException("Удаление не реализованно");
        }

        /// <summary>
        /// Обновляет информацию для вывода
        /// </summary>
        private void ChangeInfo()
        {
            InfoBox.Document.Blocks.Clear();
            if (Selected?.InfoTable is not null)
                InfoBox.Document.Blocks.Add(_Selected.InfoTable);
        }
    }
}