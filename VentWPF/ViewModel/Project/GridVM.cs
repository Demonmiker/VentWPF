using PropertyChanged;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Documents;
using VentWPF.Model;
using VentWPF.Tools;

namespace VentWPF.ViewModel
{
    /// <summary>
    /// Представление Сетки конструктора вентиляции
    /// </summary>
    internal class GridVM : BaseViewModel
    {
        public ProjectVM Project { get; set; } = ProjectVM.Current;

        private Element _Selected = new();

        public GridVM()
        {
            CmdRemove = new(x => RemoveElement());
            CmdRemoveShift = new(x => RemoveElementAndShift());
            CmdSelectShift = new Command<object>(SelectShift);
        }

        public enum Direction
        {
            Left,
            Right,
            Top,
            Bottom,
        }

        public Command<object> CmdSelectShift { get; private init; }

        public void SelectShift(object x) // 0  
        {
            int a = int.Parse(x.ToString());
            int res = Index + (Direction)a switch
            {
                Direction.Left => -1,
                Direction.Right => +1,
                Direction.Top => -10,
                Direction.Bottom => +10,
            };
            if(res>0 && res<Elements.Count)
                Index = res; ;
        }

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
                Elements[Index].UpdateQuery();
                ErrorManager.Add(Elements[Index], $"[{Index % 10 + 1},{Index / 10 + 1}]");
            }
            Index = ind;
        }


        /// <summary>
        /// Добавить элемент в установку
        /// </summary>
        /// <param name="el">добавляемый элементы</param>
        public void InsertElement(Element el)
        {
            int n = Index < 10 ? 9 : 19;
            for (int i = n; i > Index; i--)
                Elements[i] = Elements[i - 1];
            AddElement(el);
        }

        public Command<object> CmdRemove { get; set; }

        /// <summary>
        /// Удалить элемент
        /// </summary>
        /// <param name="el">удаляемый элемент</param>
        public void RemoveElement()
        {
            var index = Index;
            if (Index >= 0 && Index < Elements.Count)
                Elements[Index] = new Element();
            Index = index;
        }

        public Command<object> CmdRemoveShift { get; set; }

        /// <summary>
        /// Удалить элемент и сдвинуть ярус на один влево
        /// </summary>
        /// <param name="el">удаляемый элемент</param>
        public void RemoveElementAndShift()
        {
            if (Index >= 0 && Index < Elements.Count)
            {
                var index = Index;
                int n = Index < 10 ? 9 : 19; //Смещаем только до конца текущего яруса
                for (int i = Index; i < n; i++)
                {
                    Elements[i] = Elements[i + 1];
                }
                Elements[n] = new Element();
                Index = index;
            }
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

        public bool InTopRow(Element e) => Elements.IndexOf(e) switch
        {
            >= 0 and < 10 => true,
            >= 10 and < 20 => false,
            _ => throw new Exception("Элемент не найден")
        };

    }
}