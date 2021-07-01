using System.Collections.Generic;
using System.Collections.ObjectModel;
using VentWPF.ViewModel;

namespace VentWPF.Model
{
    internal class Project
    {
        public Project(ProjectInfoVM projectInfo, List<Element> grid)
        {
            ProjectInfo = projectInfo;
            Grid = grid.ToArray();
        }

        public Project()
        {
        }

        public ProjectInfoVM ProjectInfo { get; init; } = ProjectInfoVM.Instance;
        public Element[] Grid { get; set; }
    }
}