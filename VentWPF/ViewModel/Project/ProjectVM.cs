﻿using System;

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

        private ProjectVM()
        {
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
            //var sfd = new SaveFileDialog{ FileName = "Проект", DefaultExt = ".prj", Filter = "Projects (.prj)|*.prj" };
            //if(sfd.ShowDialog()==true) IOManager.SaveAsJson(new Project(ProjectInfo,Grid.ToList()), sfd.FileName);
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
            Grid.Init(ProjectInfo.Rows);
            Scheme = new SchemeVM();
        }
    }
}