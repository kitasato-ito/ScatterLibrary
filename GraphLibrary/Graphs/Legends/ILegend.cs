using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GraphLibrary.Graphs.Plots;
using GraphLibrary.Struct;

namespace GraphLibrary
{
    internal interface ILegend : IListContainer<IGraphPropertyGetter>
    {
        FontProperty FontType { get; set; }

        void DrawLegend(RegionF region, Graphics g);
    }
}
