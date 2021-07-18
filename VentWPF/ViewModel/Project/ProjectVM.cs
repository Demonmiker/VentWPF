namespace VentWPF.ViewModel
{
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

        protected void Init()
        {
            Grid = new GridVM();
            ErrorManager.Add(ProjectInfo,"Информация о проекте");
            Grid.Init(ProjectInfo.Rows);
        }

        public static ProjectVM Current { get; private set; }

        //Информация о проекте
        public ProjectInfoVM ProjectInfo { get; init; } = new();

        //установка
        public GridVM Grid { get; private set; }

        //чертеж установки

        //каркас установки
        public FrameVM Frame { get; init; } = new();

        //отчёт

        //Менеджер запросов
        public TaskManagerVM TaskManager { get; init; } = new();

        //Менеджер ошибок
        public ErrorManagerVM ErrorManager { get; init; } = new();

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