using GraphLibrary.Generics;
using GraphLibrary.Generics.Constant;
using GraphLibrary.Graphs.Plots;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphLibrary.Graphs.Legends
{
    internal class GraphLegend : ILegend
    {
        private IList<IGraphPropertyGetter> legendList = new List<IGraphPropertyGetter>();

        public Font FontType { get; set; } = DefaultFont.DefaultLabelNameFont();

        public void Add(IGraphPropertyGetter component)
        {
            if (this.legendList.Contains(component)) return;
            this.legendList.Add(component);
        }

        public void Clear()
        {
            if (this.legendList.Count() == 0) return;
            this.legendList.Clear();
        }

        public void DrawLegend(RegionF region, Graphics g)
        {
            throw new NotImplementedException();
        }

        public void Remove(IGraphPropertyGetter component)
        {
            if (!this.legendList.Contains(component)) return;
            this.legendList.Clear();
        }
    }
}
