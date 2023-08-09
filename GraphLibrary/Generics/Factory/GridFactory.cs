using GraphLibrary.Graphs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphLibrary.Generics
{
    internal static class GridFactory
    {
        public static IGridDrawer CreateGridDrawer(GridLineType lineType)
        {
            switch(lineType)
            {
                case GridLineType.NONE:
                    return new NullGridDrawer();
                case GridLineType.LINE:
                    return new LineGridDrawer();
                case GridLineType.DOTLINE:
                    return new DotGridDrawer();
                default:
                    throw new NotImplementedException();
            }
        }

    }
}
