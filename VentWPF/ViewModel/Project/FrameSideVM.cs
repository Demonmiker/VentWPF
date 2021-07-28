using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VentWPF.Tools;

namespace VentWPF.ViewModel
{
    internal class Box : BaseViewModel
    {
        #region Constructors

        public Box(FrameSideVM parent, int value = 50)
        {
            this.Parent = parent;
            this.Value = value;
        }

        #endregion

        #region Properties

        public int Value { get; set; }

        public FrameSideVM Parent { get; set; }

        #endregion
    }

    internal class FrameSideVM : BaseViewModel
    {
        #region Constructors

        public FrameSideVM()
        {
            CmdSplit = new(Split);
            CmdDelete = new(Delete);
            Values = new() { new(this), new(this), new(this), new(this), new(this, 60), new(this, 120) };
        }

        #endregion

        #region Properties

        public ObservableCollection<Box> Values { get; private set; }

        public int FrameWidth { get; set; } = ProjectVM.Current.ProjectInfo.Width;

        public int FrameHeight { get; set; } = ProjectVM.Current.ProjectInfo.Height;

        public int FrameLenght
        {
            get => ProjectVM.Current.Frame.FrameLength;
            set => ProjectVM.Current.Frame.FrameLength = value;
        }

        [DependsOn(nameof(Values))]
        public int Sum => Values.Sum(x => x.Value);

        public bool IsTop { get; init; }

        public double Side => IsTop ? ProjectVM.Current.ProjectInfo.Width : ProjectVM.Current.ProjectInfo.Height;

        

        public Command<Box> CmdSplit { get; init; }

        public Command<Box> CmdDelete { get; init; }

        #endregion

        #region Methods

        private void Split(Box b)
        {
            int index = Values.IndexOf(b);
            var val = Values[index].Value / 2;
            var mod = Values[index].Value % 2;
            Values.RemoveAt(index);
            Values.Insert(index, new Box(this, val));
            Values.Insert(index, new Box(this, val + mod));
        }

        private void Delete(Box b)
        {
            Values.Remove(b);
        }

        #endregion
    }
}