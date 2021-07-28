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
    internal class FrameSideVM : BaseViewModel
    {
        #region Constructors

        public FrameSideVM(FrameVM parent)
        {
            CmdSplit = new(Split);
            CmdDelete = new(Delete);
            Values = new() { new(this), new(this), new(this), new(this), new(this, 60), new(this, 120) };
        }

        #endregion

        #region Properties

        public ObservableCollection<Box> Values { get; private set; }

        [DependsOn(nameof(Values))]
        public int Sum => Values.Sum(x => x.Value);

        public bool IsTop { get; init; }

        public double Side => IsTop ? ProjectVM.Current.Frame.FrameWidth : ProjectVM.Current.Frame.FrameHeight;

        public Command<Box> CmdSplit { get; init; }

        public Command<Box> CmdDelete { get; init; }

        public FrameVM Parent { get; init; }

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