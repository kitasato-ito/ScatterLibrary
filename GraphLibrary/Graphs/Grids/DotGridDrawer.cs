using GraphLibrary.Generics;
using GraphLibrary.Generics.Enum;
using GraphLibrary.Graphs.Grid;
using GraphLibrary.Labels;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphLibrary.Graphs
{
    internal class DotGridDrawer : IGridDrawer
    {
        private Color color = DefaultColor.DefaultGridColor();

        public void DrawGrid(RegionF regionF, AxisValue axisValue, Graphics g)
        {
            throw new NotImplementedException();
        }
        public void SetColor(Color color)
        {
            this.color = color;
        }
    }
}
