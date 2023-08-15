using GraphLibrary.Generics;
using GraphLibrary.Generics.Converter;
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
    internal class NullGridDrawer : IGridDrawer
    {
        private Color color = DefaultColor.DefaultGridColor();
        private bool isHorizontalGrid = false;
        public NullGridDrawer(bool isHorizontalGrid)
        {
            this.isHorizontalGrid = isHorizontalGrid;
        }

        public void DrawGrid(RegionF regionF, AxisValue axisValue, Graphics g)
        {
            return;
        }

        public void SetColor(Color color)
        {
            this.color = color;
        }
    }
}
