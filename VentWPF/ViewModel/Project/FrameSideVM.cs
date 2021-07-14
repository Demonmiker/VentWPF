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
    class FrameSideVM : BaseViewModel
    {
        public class Box : BaseViewModel
        {
            public FrameSideVM parent;

            public Box(FrameSideVM @parent, int @value) { this.parent = @parent; this.Value = @value; }

            public int Value { get; set; }
        }

        public FrameSideVM()
        {
            CmdSplit = new(Split);
            Values = new() { NewBox(), NewBox(), NewBox(), NewBox(), NewBox(60) };
        }

        private Box NewBox(int value = 50) => new Box(this, value);

        public ObservableCollection<Box> Values { get; private init; }

        [DependsOn("Values")]
        public int Sum => Values.Sum(x => x.Value);

        public int Length = 500;

        public bool IsTop { get; init; }

        public double Side => IsTop ? ProjectVM.Current.ProjectInfo.Width : ProjectVM.Current.ProjectInfo.Height;
        
        public int FrameLenght
        {
            get => ProjectVM.Current.Frame.FrameLength;
            set => ProjectVM.Current.Frame.FrameLength =value;
        }


        Command<int> CmdSplit { get; init; }

        public void Split(int index)
        {
            var val = Values[index].Value / 2;
            var mod = Values[index].Value % 2;
            Values.RemoveAt(index);
            Values.Insert(index, NewBox(val));
            Values.Insert(index, NewBox(val+mod));
        }
    }
}
