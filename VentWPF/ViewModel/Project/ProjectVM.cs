using System;
using System.Collections.Generic;
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
            Frame = new(500, ProjectInfo.Width, ProjectInfo.Height);
            Frame.Parent = this;
            Grid.Init(ProjectInfo.Rows);
        }

        public Command<object> CmdScheme { get; init; }

        public void GenearateScheme(object o)
        {
            if (Scheme is null) { Scheme = new SchemeVM(); Scheme.Parent = this; }
            var result = Scheme;
            result.TwoRows = ProjectInfo.Rows == Model.Rows.Двухярусный;
            result.WidthBottom = ProjectInfo.Height;
            result.WidthTop = ProjectInfo.Height + 100; //TODO Исправить на нормальное значение
            result.Elements.Clear();
            for (int i = 0; i < 10; i++)
            {
                if (result.TwoRows)
                {
                    if (Grid.Elements[i].GetType().Name == "Element" && Grid.Elements[i + 10].GetType().Name == "Element")
                        break;
                    result.Elements.Add(new ElementPair()
                    {
                        TwoRows = true,
                        Top = Grid.Elements[i],
                        Bottom = Grid.Elements[i + 10],
                    });
                }
                else
                {
                    if (Grid.Elements[i].GetType().Name == "Element")
                        break;
                    result.Elements.Add(new ElementPair()
                    {
                        TwoRows = false,
                        Bottom = Grid.Elements[i],
                    });
                }
            }
            result.Init();
            Scheme = result;
        }
    }
}