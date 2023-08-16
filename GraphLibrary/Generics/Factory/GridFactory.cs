using GraphLibrary.Graphs;
using GraphLibrary.Graphs.Grids;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphLibrary.Generics
{
    internal static class GridFactory
    {
        public static IGridDrawer CreateGridDrawer(GridLineType lineType, bool isHorizontal)
        {
            switch(lineType)
            {
                case GridLineType.NONE:
                    return new NullGridDrawer(isHorizontal);
                case GridLineType.LINE:
                    return new LineGridDrawer(isHorizontal);
                case GridLineType.DOTLINE:
                    return new DotGridDrawer(isHorizontal);
                case GridLineType.INWARD_SCALE:
                    return new InwardScaleGridDrawer(isHorizontal);
                default:
                    throw new NotImplementedException();
            }
        }

    }
}
