using Microsoft.Win32;
using PropertyTools.DataAnnotations;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;
using VentWPF.Tools;

namespace VentWPF.ViewModel
{
    /// <summary>
    /// Проект
    /// </summary>
    internal class ProjectVM : BaseViewModel
    {
        static ProjectVM()
        {
            Current = new ProjectVM();
            Current.Init();
            Current.NewProject(null);
        }

        public Command<FrameworkElement> CmdLinkGui { get; set; }

        private void SetLink(FrameworkElement el)
        {
            if(el is not null)
                Elements[el.Name] = el;
        }

        public Dictionary<string, FrameworkElement> Elements = new();

        private ProjectVM()
        {
            CmdScheme = new Command(GenearateScheme);
            CmdLinkGui = new Command<FrameworkElement>(SetLink);
            CmdExpand = new Command<BaseViewModel>(ExpandView);
            CmdAutoColumns = new(AutoColumns);
        }

        internal void NewProject(object obj)
        {
            if (File.Exists("new.json"))
            {
                LoadProjectFile("new.json");
                Path = null;
            }
            else
                Init();
            Status = "Новый проект";
        }

        public static ProjectVM Current { get; private set; }

        public ProjectInfoVM ProjectInfo { get; private set; }

        public GridVM Grid { get; private set; }

        public FrameVM Frame { get; private set; }

        public TaskManagerVM TaskManager { get; private set; }

        public ErrorManagerVM ErrorManager { get; private set; }

        public SchemeVM Scheme { get; private set; }

        public BaseViewModel ExpandedViewModel { get; set; }

        /// <summary>
        /// Разворачивает отображение на полный экран или сворачивает если уже развернуто
        /// </summary>
        /// <param name="vm">Модель Отображения</param>
        private void ExpandView(BaseViewModel vm)
        {
            if (ExpandedViewModel != vm)
                ExpandedViewModel = vm;
            else
                ExpandedViewModel = null;
        }

        // TODO: @MikeKondr99 Сохранение и загрузка каркаса
        public void LoadProject(object o)
        {
            Status = "Загружаем...";
            var workdir = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\VentProjects";
            var sfd = new OpenFileDialog
            {
                DefaultExt = ".json",
                Filter = "Projects (.json)|*.json",
                FileName = Path is not null ? Path : "",
                InitialDirectory = workdir,
            };
            if (sfd.ShowDialog() == false) { Status = ""; return; } // Если была отмена
            Status = LoadProjectFile(sfd.FileName) ? "Проект загружен" : "Ошибка при загрузке";
        }

        private bool LoadProjectFile(string path)
        {
            PackedProject pp = new PackedProject();
            try { pp = IOManager.LoadAsJson<PackedProject>(path); }
            catch (Exception ex) { return false; }
            PackedProject.Unpack(pp, this);
            return true;
        }

        public string Path { get; set; } = null;

        public string Status { get; set; }

        public void SaveProject(string path)
        {
            Status = "Сохраняем...";
            if (path is null)
            {
                var workdir = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\VentProjects";
                if (!Directory.Exists(workdir))
                    Directory.CreateDirectory(workdir);
                // TODO: @MikeKondr99 OrderName может содержать недопустимые для файла символы
                var fileName = ProjectInfo.Order.OrderName is not null ? ProjectInfo.Order.OrderName : "project";
                SaveFileDialog diag = new SaveFileDialog()
                {
                    FileName = fileName,
                    Title = "Сохранение проекта",
                    DefaultExt = ".json",
                    InitialDirectory = workdir,
                };
                var res = diag.ShowDialog();
                if (res == true)
                    path = diag.FileName;
                else
                {
                    Status = "";
                    return;
                }
            }
            PackedProject pp = PackedProject.Pack(this, path);
            try { IOManager.SaveAsJson(pp, path); }
            catch (Exception ex) { Status = "Ошибка при сохранении"; }
            Path = path;
            Status = "Проект сохранён";
        }

        /// <summary>
        /// Метод инициализации
        /// </summary>
        protected void Init()
        {
            ProjectInfo = new();
            TaskManager = new();
            ErrorManager = new();
            ErrorManager.Add(ProjectInfo.Order, "Заказ");
            ErrorManager.Add(ProjectInfo.Settings, "Настройки");
            ErrorManager.Add(ProjectInfo.View, "Вид");
            Scheme = new SchemeVM();
            Grid = new();
            Grid.ErrorManager = ErrorManager;
            Frame = new(500, ProjectInfo.Settings.Width, ProjectInfo.Settings.TopHeight + ProjectInfo.Settings.BottomHeight);
            Frame.Parent = this;
            Grid.Init(ProjectInfo.View.Rows);
        }

        public Command CmdScheme { get; init; }
        public Command<BaseViewModel> CmdExpand { get; private init; }
        public Command<DataGridAutoGeneratingColumnEventArgs> CmdAutoColumns { get; init; }
        private void AutoColumns(DataGridAutoGeneratingColumnEventArgs e)
        {
            string header = e.Column.Header.ToString();
            // Получчение имени из тэга
            if (ProjectVM.Current.Grid.Selected.Query.Result.Count == 0) return;
            object[] atrs = ProjectVM.Current.Grid.Selected.Query.Result[0].GetType()
                    .GetProperty(header).GetCustomAttributes(typeof(DisplayNameAttribute), true);
            if (atrs.Length > 0)
            {
                e.Column.Header = (atrs[0] as DisplayNameAttribute).DisplayName ?? e.Column.Header;
            }
            else
            {
                e.Cancel = true;
                return;
            }
            //Получение форматирования из тэга
            object[] atrs2 = ProjectVM.Current.Grid.Selected.Query.Result[0].GetType()
                .GetProperty(header).GetCustomAttributes(typeof(FormatStringAttribute), true);
            if (atrs2.Length > 0 && e.Column is DataGridTextColumn)
            {
                DataGridTextColumn col = e.Column as DataGridTextColumn;
                col.Binding.StringFormat = (atrs2[0] as FormatStringAttribute).FormatString;
            }

            if (ProjectVM.Current.Grid.Selected.Format == null)
                return;
            if (ProjectVM.Current.Grid.Selected.Format.ContainsKey(header))
            {
                IValueConverter format = ProjectVM.Current.Grid.Selected.Format[header];
                if (format != null)
                {
                    Style defaultStyle = Application.Current.TryFindResource(typeof(DataGridCell)) as Style;
                    Style style = new(typeof(DataGridCell), defaultStyle);
                    style.Triggers.Add(new DataTrigger()
                    {
                        Binding = new Binding(header) { Converter = format },
                        Value = true,
                        Setters =
                        {
                            new Setter() { Property = DataGridCell.BackgroundProperty, Value = Brushes.PaleGreen},
                            new Setter() { Property = DataGridCell.ForegroundProperty, Value = Brushes.DarkGreen},
                        }
                    });
                    style.Triggers.Add(new DataTrigger()
                    {
                        Binding = new Binding(header) { Converter = format },
                        Value = false,
                        Setters =
                        {
                            new Setter() { Property = DataGridCell.BackgroundProperty, Value = Brushes.Pink},
                            new Setter() { Property = DataGridCell.ForegroundProperty, Value = Brushes.DarkRed},
                        }
                    });
                    e.Column.CellStyle = style;
                }
            }
        }
        public void GenearateScheme()
        {
            Scheme.GenFullScheme(Grid);
        }

    }
}