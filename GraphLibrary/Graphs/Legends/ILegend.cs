using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GraphLibrary.Graphs.Plots;

namespace GraphLibrary
{
    internal interface ILegend : IListContainer<IGraphPropertyGetter>
    {
        Font FontType { get; set; }

        void DrawLegend(RegionF region, Graphics g);
    }
}
