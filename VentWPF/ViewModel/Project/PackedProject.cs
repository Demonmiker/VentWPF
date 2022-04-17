using System.Linq;

namespace VentWPF.ViewModel
{
    internal record PackedProject
    {

        public string ProjectPath { get; init; }

        public Order Order { get; init; }

        public Settings Settings {get; init;} 

        public View View { get; init; }

        public Element[] Elements { get; init; }

        public static PackedProject Pack(ProjectVM project,string path)
        {
            return new PackedProject()
            {
                ProjectPath = path,
                Order = project.ProjectInfo.Order,
                Settings = project.ProjectInfo.Settings,
                View = project.ProjectInfo.View,
                Elements = project.Grid.Elements.Select(x => x.Name == "" || x is IDoubleSubElement ? null : x).ToArray(),
            };
        }


        public static ProjectVM Unpack(PackedProject packed,ProjectVM project)
        {
            packed.Order.InitParent(project.ProjectInfo);
            packed.Settings.InitParent(project.ProjectInfo);
            packed.View.InitParent(project.ProjectInfo);
            // PI
            project.ProjectInfo.Order = packed.Order;
            project.ProjectInfo.Settings = packed.Settings;
            project.ProjectInfo.View = packed.View;

            project.ErrorManager.Add(project.ProjectInfo.Order, "Заказ");
            project.ErrorManager.Add(project.ProjectInfo.Settings, "Настройки");
            project.ErrorManager.Add(project.ProjectInfo.View, "Вид");

            project.Path = packed.ProjectPath;
            project.Grid.Init(project.ProjectInfo.View.Rows);
            for (int i = 0; i < packed.Elements.Length; i++)
                if (packed.Elements[i] is not null)
                    project.Grid.AddElement(packed.Elements[i], i);
            return project;
        }
        
    }
}