namespace VentWPF.ViewModel
{
    internal class ProjectVM : BaseViewModel
    {
        #region Constructors

        static ProjectVM()
        {
            Current.Init();
        }

        private ProjectVM()
        {
        }

        #endregion

        #region Properties

        public static ProjectVM Current { get; private set; } = new ProjectVM();

        //Информация о проекте
        public ProjectInfoVM ProjectInfo { get; init; } = new();

        //установка
        public GridVM Grid { get; private set; }

        //каркас установки
        public FrameVM Frame { get; private set; }

        //Менеджер запросов
        public TaskManagerVM TaskManager { get; private set; }

        //чертеж установки
        //отчёт
        //Менеджер ошибок
        public ErrorManagerVM ErrorManager { get; private set; }

        #endregion

        #region Methods

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

        protected void Init()
        {
            Grid = new();
            Frame = new(500, ProjectInfo.Width, ProjectInfo.Height);
            TaskManager = new();
            ErrorManager = new();
            ErrorManager.Add(ProjectInfo, "Информация о проекте");
            Grid.Init(ProjectInfo.Rows);
        }

        #endregion
    }
}