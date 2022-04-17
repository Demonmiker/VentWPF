using System.Collections.Generic;
using System.Linq;
using System.Windows;
using VentWPF.Model;

namespace VentWPF.ViewModel
{
    internal class SchemeVM : BaseViewModel //ViewModel для самой вкладки а не изображения схемы
    {
        public ProjectVM Parent { get; init; } = ProjectVM.Current;

        public SchemeImageVM SchemeImage { get; set; } = new SchemeImageVM();

        public (SchemeSingleBlock, int) GenSingleBlock(GridVM grid, int i)
        {
            var res = new SchemeSingleBlock() { TwoRows = true };
            List<Element> Top = new List<Element>();
            List<Element> Bottom = new List<Element>();
            while (i < 10 && !(grid.Elements[i + 10] is IDoubleElement) &&
                !(grid.Elements[i].Connection.HasFlag(ElementConnection.Down) &&
                grid.Elements[i + 10].Connection.HasFlag(ElementConnection.Up)))
            {
                if (grid.Elements[i].Name != "") Top.Add(grid.Elements[i]);
                if (grid.Elements[i + 10].Name != "") Bottom.Add(grid.Elements[i + 10]);
                i++;
            }
            res.Top = Top.Select(x => new SchemeElement(this.SchemeImage, x)).ToArray();
            res.Bottom = Bottom.Select(x => new SchemeElement(this.SchemeImage, x)).ToArray();
            return (res, i);
        }

        public (SchemeDoubleBlock, int) GenDoubleBlock(GridVM grid, int i)
        {
            var res = new SchemeDoubleBlock();
            List<DoubleSchemeElement> Els = new List<DoubleSchemeElement>();
            while (i < 10 && (grid.Elements[i + 10] is IDoubleElement || 
                (grid.Elements[i].Connection.HasFlag(ElementConnection.Down) &&
                grid.Elements[i+10].Connection.HasFlag(ElementConnection.Up))))
            {
                Els.Add(new DoubleSchemeElement(this.SchemeImage, grid.Elements[i], grid.Elements[i + 10]));

                i++;
            }
            res.Doubles = Els.ToArray();
            return (res, i);
        }

        public void GenFullScheme(GridVM grid)
        {
            if (grid.RowNumber == Model.Rows.Одноярусный)
            {
                var els = (from x in grid.Elements where x.Name != "" select new SchemeElement(this.SchemeImage, x)).ToArray();
                SchemeImage.Blocks = new SchemeBlock[]
                {
                    new SchemeSingleBlock() { Bottom = els, TwoRows = false, Align=HorizontalAlignment.Right,First=true,Last=true}
                };
            }
            else
            {
                int i = 0;
                List<SchemeBlock> blocks = new List<SchemeBlock>();
                SchemeBlock newBlock;
                while (i < 10)
                {
                    if (grid.Elements[i + 10] is IDoubleElement ||
                        grid.Elements[i].Connection.HasFlag(ElementConnection.Down) &&
                        grid.Elements[i+10].Connection.HasFlag(ElementConnection.Up))
                        (newBlock, i) = GenDoubleBlock(grid, i);
                    else
                        (newBlock, i) = GenSingleBlock(grid, i);
                    blocks.Add(newBlock);
                }
                if (blocks[0] is SchemeDoubleBlock)
                    blocks.Insert(0, new SchemeSingleBlock() { Top = new SchemeElement[0], Bottom = new SchemeElement[0], TwoRows = true });
                blocks[0].First = true;
                blocks[^1].Last = true;
                if (blocks[0] is SchemeSingleBlock ssb)
                    ssb.Align = HorizontalAlignment.Right;
                if (blocks[^1] is SchemeSingleBlock ssb2)
                    ssb2.Align = HorizontalAlignment.Left;
                SchemeImage.Blocks = blocks.ToArray();
            }
            SchemeImage.UpdateSum();
        }
    }
}