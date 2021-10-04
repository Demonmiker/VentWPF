﻿using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using VentWPF.Tools;

namespace VentWPF.ViewModel
{
    internal class FrameSideVM : BaseViewModel
    {
        #region Constructors

        public FrameSideVM(FrameVM parent, bool top = false)
        {
            CmdSplit = new(Split);
            CmdDelete = new(Delete);
            CmdSupport = new(AddSupport) { predicate = CanAddSupport };
            Values = new() { new(this),new(this)};
            ValuesChanged();
        }

        public void ValuesChanged()
        {
            Sum = Values.Sum(x => x.Value);
            RightSize = Sum == Length;
        }

        #endregion

        #region Properties

        public bool RightSize { get; set; }

        

        public ObservableCollection<Box> Values { get; private set; }

        public long Sum { get; set; }

        public uint Side { get; set; }

        public uint Length { get; set; }

        public Command<Box> CmdSplit { get; init; }

        public Command<Box> CmdDelete { get; init; }

        public Command<Box> CmdSupport { get; init; }

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

        private void AddSupport(Box b)
        {
            Values.First(x => b == x).Support = (uint)Side/2;
        }

        private bool CanAddSupport(Box b)
        {
            if (b == null) return true;
            return Values.First(x => b == x).Support == 0;
        }

        #endregion
    }
}