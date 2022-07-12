using System;
using System.Collections.Generic;
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
    internal class GridVM : ValidViewModel
    {
        private Element _Selected = new();

        public ProjectVM Project { get; set; } = ProjectVM.Current;

        public GridVM()
        {
            CmdRemove = new(RemoveElement, CanRemove);
            CmdRemoveShift = new Command(RemoveElementAndShift, CanRemoveAndShift);
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
            if (res > 0 && res < Elements.Count)
                Index = res; ;
        }


        /// <summary>
        /// Элементы в установке
        /// </summary>
        public ObservableCollection<Element> Elements { get; set; }

        /// <summary>
        /// Выбранный элемент в установке
        /// </summary>
        public Element Selected
        {
            get => _Selected;
            set
            {
                _Selected = value;
                ChangeInfo();
                if (_Selected != null)
                {
                    if (_Selected is IDoubleMainElement && Elements[Index-10] is DecoyElement)
                    {
                        Elements[Index - 10].IsSelected = true;
                    }
                    if (_Selected is DecoyElement)
                    {
                        Elements[Index + 10].IsSelected = true;
                        Index = Index + 10;
                        Selected = Elements[Index];
                    }
                    //TODO: Код для двойного выделения 
                }

            }
        }


        private int index;
        /// <summary>
        /// Индекс выбранного элемента
        /// </summary>
        public int Index
        {
            get => index;
            set
            {

                foreach (var el in Elements)
                    el.IsSelected = false; //Очищаем все выбранные
                index = value;
                if (index >= 0)
                {
                    Elements[index].IsSelected = true; //Выбираем кликнутый
                }
            }

        }

        /// <summary>
        /// Текстовое поле для показа информации
        /// </summary>
        public RichTextBox InfoBox { get; init; } = new RichTextBox() { Focusable = false, Document = new FlowDocument() };

        public Rows RowNumber { get; private set; }
        public void Init(Rows rows)
        {
            RowNumber = rows;
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
            ProjectVM.Current.ErrorManager.AddRange(Enumerable.Range(0, 20).Select(x => ($"Модуль {Position(x)}", new Element() as ValidViewModel)));
            Index = 0;
        }

        public void LoadElement(Element el, int index)
        {
            int ind = Index;
            Index = index;
            if (Index >= 0 && Index < Elements.Count)
            {
                el.UpdateQuery();
                Elements[Index] = el;
                Index = ind;
                ProjectVM.Current.ErrorManager.Add(Elements[Index], $"Модуль {Position(Index)}");
            }
            Index = ind;
        }

        /// <summary>
        /// Добавить элемент в установку
        /// </summary>
        /// <param name="el">добавляемый элементы</param>
        public void AddElement(Element el)
        {
            if (el is IDoubleMainElement del)
            {
                if (Elements.Count != 20) throw new Exception("Попытка добавить двойной элемент в одноярусную установку");
                int top = Index = index > 9 ? index - 10 : index;
                Elements[top] = del.GetNewTopElement();
                Elements[top].UpdateQuery();
                Index = top + 10;
            }
            int ind = Index;
            if (Index >= 0 && Index < Elements.Count)
            {
                var el2 = Element.GetInstance(el);
                el2.SubType = el.SubType;
                el2.UpdateQuery();
                Elements[Index] = el2;
                Index = ind;
                ProjectVM.Current.ErrorManager.Add(Elements[Index], $"Модуль {Position(Index)}");
            }
            Index = ind;
        }
        public void AddElement(Element el, int index)
        {
            int ind = Index;
            Index = index;
            AddElement(el);
            Index = ind;
        }


        /// <summary>
        /// Добавить элемент в установку
        /// </summary>
        /// <param name="el">добавляемый элементы</param>
        public void InsertElement(Element el)
        {
            int ind = Index;
            if (HasDouble(Index) || el is IDoubleMainElement)
            {
                (int top, int bot) = IndexTopBottom(Index);
                ShiftRowRight(top);
                ShiftRowRight(bot);
            }
            else
            {
                ShiftRowRight(Index);
            }
            Index = ind;
            AddElement(el);
        }


        public (int top, int bottom) IndexTopBottom(int index)
        {
            int top = index > 9 ? index - 10 : index;
            int bottom = index < 10 ? index + 10 : index;
            return (top, bottom);

        }

        private void ShiftRowRight(int index)
        {
            int n = index < 10 ? 9 : 19;
            for (int i = n; i > index; i--)
                Elements[i] = Elements[i - 1];
            Elements[index] = new Element();
        }
        private void ShiftRowLeft(int start)
        {
            int n = start < 10 ? 9 : 19;
            for (int i = start; i < n; i++)
                Elements[i] = Elements[i + 1];
            Elements[n] = new Element();
        }

        private bool HasDouble(int start)
        {
            int top = start > 9 ? start - 10 : start;
            for (int i = top; i < 10; i++)
                if (Elements[i] is IDoubleSubElement)
                    return true;
            return false;
        }


        public Command CmdRemove { get; set; }

        /// <summary>
        /// Удалить элемент
        /// </summary>
        /// <param name="el">удаляемый элемент</param>
        public void RemoveElement()
        {
            var index = Index;
            if (Index >= 0 && Index < Elements.Count)
            {
                if (Elements[Index] is IDoubleMainElement)
                    Elements[Index - 10] = new Element();
                Index = index;
                if (Elements[Index] is IDoubleSubElement)
                    Elements[Index + 10] = new Element();
                Elements[Index] = new Element();
            }
            Index = index;
        }

        public Command CmdRemoveShift { get; set; }

        /// <summary>
        /// Удалить элемент и сдвинуть ярус на один влево
        /// </summary>
        /// <param name="el">удаляемый элемент</param>
        public void RemoveElementAndShift()
        {
            if (Index >= 0 && Index < Elements.Count)
            {
                var index = Index;
                if (HasDouble(Index))
                {
                    (int top, int bot) = IndexTopBottom(Index);
                    ShiftRowLeft(top);
                    ShiftRowLeft(bot);
                }
                else
                {
                    ShiftRowLeft(Index);
                }
                Index = index;
            }
        }

        public bool CanRemoveAndShift()
        {
            if (Index < 0) return false;
            if (RowNumber == Rows.Двухъярусный)
            {
                if (HasDouble(Index))
                {
                    if (Elements[Index] is IDoubleMainElement || Elements[Index] is IDoubleSubElement)
                        return true;
                    var opposite = Index < 10 ? Elements[Index + 10] : Elements[Index - 10];
                    return opposite.Name == "";
                }
            }
            return true;
        }
        public bool CanRemove()
        {
            return Elements is not null && Index >= 0 && Index < Elements.Count;
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
            _ => true,
        };

        private string CheckStructure()
        {
            if (Elements is null) return string.Empty;
            Element root = null;
            foreach (var el in Elements)
            {
                if (el.Name != "")
                {
                    root = el;
                    break;
                }
            }
            if (root is null) return "Установка пуста";
            else return CheckConnections();
        }

        private string CheckConnections()
        {
            List<string> errors = new();
            for (int r = 0; r < Elements.Count / 10; r++)
                for (int i = r * 10; i < 10 * r + 9; i++)
                    if (Elements[i].Name != "" && Elements[i + 1].Name != "")
                        switch
                            (Elements[i].Connection.HasFlag(ElementConnection.Right),
                            Elements[i + 1].Connection.HasFlag(ElementConnection.Left))
                        {
                            case (false, true):
                            case (true, false):
                                errors.Add($"Некорректное соединение горизонтальное между\n" +
                                    $"{Position(i)}\t{Elements[i].Name}\n" +
                                    $"{Position(i+1)}\t{Elements[i+1].Name}\n");
                                break;
                        }
            if (Elements.Count == 20)
            {
                for (int i = 0; i < 10; i++)
                {
                    if (Elements[i].Name != "" && Elements[i + 10].Name != "")
                        switch
                            (Elements[i].Connection.HasFlag(ElementConnection.Down),
                            Elements[i + 10].Connection.HasFlag(ElementConnection.Up))
                        {
                            case (false, true):
                            case (true, false):
                                errors.Add($"Некорректное вертикальное соединение между\n" +
                                    $"{Position(i)}\t{Elements[i].Name}\n" +
                                    $"{Position(i+10)}\t{Elements[i+10].Name}\n");
                                break;
                        }
                }
            }
            return String.Join("\n", errors);

        }

        public static string Position(int i)
        {
            if (ProjectVM.Current.ProjectInfo.Settings.Rows == Rows.Двухъярусный)
            {
                return $"[{(i / 10 == 0 ? "Верхний ярус" : "Нижний ярус")},{i % 10 + 1}]";
            }
            else
            {
                return $"[{i % 10 + 1}]";
            }

        }
        protected override string OnValidation()
        {
            return CheckStructure();
        }

    }
}