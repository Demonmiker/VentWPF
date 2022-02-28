using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;
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
            Elements[el.Name] = el;
        }

        public Dictionary<string, FrameworkElement> Elements = new();

        private ProjectVM()
        {
            CmdScheme = new Command<object>(GenearateScheme);
            CmdLinkGui = new Command<FrameworkElement>(SetLink);
            CmdExpand = new Command<BaseViewModel>(ExpandView);
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
            Grid = new();
            Grid.ErrorManager = ErrorManager;
            Frame = new(500, ProjectInfo.Settings.Width, ProjectInfo.Settings.Height);
            Frame.Parent = this;
            Grid.Init(ProjectInfo.View.Rows);
        }

        public Command<object> CmdScheme { get; init; }
        public Command<BaseViewModel> CmdExpand { get; private init; }

        public void GenearateScheme(object o)
        {
            if (Scheme is null) { Scheme = new SchemeVM(); Scheme.Parent = this; }
            var result = Scheme;
            result.TwoRows = ProjectInfo.View.Rows == Model.Rows.Двухярусный;
            result.WidthBottom = ProjectInfo.Settings.Height;
            result.WidthTop = ProjectInfo.Settings.Height + 100; //TODO Исправить на нормальное значение
            result.TopElements.Clear();
            result.BottomElements.Clear();
            if (result.TwoRows)
            {
                int i = 0;
                while (Grid.Elements[i].Name != "" && i < 10)
                    result.TopElements.Add(Grid.Elements[i++]);
                i = 10;
                while (Grid.Elements[i].Name != "" && i < 20)
                    result.BottomElements.Add(Grid.Elements[i++]);
                MessageBox.Show(result.TopElements.Sum(x => x.Length).ToString());
            }
            else
            {
                int i = 0;
                while (Grid.Elements[i].Name != "" && i < 10)
                    result.BottomElements.Add(Grid.Elements[i++]);
            }
            result.Init();
            Scheme = result;
        }
    }
}