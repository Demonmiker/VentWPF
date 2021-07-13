using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VentWPF.ViewModel
{
    class ProjectVM : BaseViewModel
    {
        static ProjectVM()
        {
            Current = new ProjectVM();
            Current.Init();
        }

        private ProjectVM()
        {
           
        }

        protected void Init()
        {
            Grid = new GridVM();
            Grid.Init(ProjectInfo.Rows);
        }

        public static ProjectVM Current { get; private set; }


        //Информация о заказе
        public OrderVM Order { get; init; } = new OrderVM();
        //Информация о проекте
        public ProjectInfoVM ProjectInfo { get; init; } = new ProjectInfoVM();
        //установка
        public GridVM Grid { get; private set; }
        //чертеж установки

        //каркас установки

        //отчёт


        public void LoadProject(object o)
        {
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
            //var sfd = new SaveFileDialog{ FileName = "Проект", DefaultExt = ".prj", Filter = "Projects (.prj)|*.prj" };
            //if(sfd.ShowDialog()==true) IOManager.SaveAsJson(new Project(ProjectInfo,Grid.ToList()), sfd.FileName);
        }

    }
}
