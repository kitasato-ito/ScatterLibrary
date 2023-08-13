using GraphLibrary.Graphs.Plots;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphLibrary.Graphs
{
    public interface IGraph
    {
        void DrawPlot(RegionF region, RangeF xRange, RangeF yRange, Graphics g);
        IGraphPropertyGetter GetGraphProperty();
    }
}
