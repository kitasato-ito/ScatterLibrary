using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphLibrary.Graphs.Plots
{
    public sealed class ScatterPlot : GraphBase
    {
        public ScatterPlot() : base()
        {

        }
        public override void DrawPlot(RegionF region, RangeF xRange, RangeF yRange, Graphics g)
        {
            throw new NotImplementedException();
        }

        public override IGraphPropertyGetter GetGraphProperty()
        {
            throw new NotImplementedException();
        }
    }
}
