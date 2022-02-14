using System;
using System.Collections.Generic;
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
        }

        public static ProjectVM Current { get; private set; }

        public ProjectInfoVM ProjectInfo { get; private set; }

        public GridVM Grid { get; private set; }

        public FrameVM Frame { get; private set; }

        public TaskManagerVM TaskManager { get; private set; }

        public ErrorManagerVM ErrorManager { get; private set; }

        public SchemeVM Scheme { get; private set; }

        // TODO: Реализовать сохранение и загрузку проекта
        public void LoadProject(object o)
        {
            throw new NotImplementedException();
            //var sfd = new OpenFileDialog{ DefaultExt = ".prj", Filter = "Projects (.prj)|*.prj" };
            //if (sfd.ShowDialog() == true)
            //{
            //    var project = IOManager.LoadAsJson<Project>(sfd.FileName);
            //    ProjectInfo = project.ProjectInfo;
            //    Grid = new ObservableCollection<Element>(project.Grid);
            //}
        }

        public void SaveProject(object o)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Метод инициализации
        /// </summary>
        protected void Init()
        {
            ProjectInfo = new();
            TaskManager = new();
            ErrorManager = new();
            ErrorManager.Add(ProjectInfo, "Информация о проекте");
            Grid = new();
            Grid.ErrorManager = ErrorManager;
            Frame = new(500, ProjectInfo.Settings.Width, ProjectInfo.Settings.Height);
            Frame.Parent = this;
            Grid.Init(ProjectInfo.View.Rows);
        }

        public Command<object> CmdScheme { get; init; }

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