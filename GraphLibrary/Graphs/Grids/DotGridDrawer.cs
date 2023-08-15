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
        private bool isHorizontalGrid = false;
        private const int PEN_WIDTH = 2;

        private const float DOT_LENGTH = 10f;
        private const float DOT_INTERVAL = 5f;

        public DotGridDrawer(bool isHorizontalGrid)
        {
            this.isHorizontalGrid = isHorizontalGrid;
        }

        public void DrawGrid(RegionF regionF, AxisValue axisValue, Graphics g)
        {
            var values = axisValue.GetEnumerableValues();
            if (values.Count() <= 2) return;
            if (isHorizontalGrid)
            {
                DrawHorizontalGrid(regionF, values, g);
            }
            else
            {
                DrawVerticalGrid(regionF, values, g);
            }
        }

        //X軸方向
        private void DrawHorizontalGrid(RegionF regionF, IEnumerable<float> values, Graphics g)
        {
            var amount = values.Count();
            var heightF = regionF.Height;
            var ymin = values.ElementAt(0);
            var ymax = values.ElementAt(amount - 1);
            var xStart = regionF.OffsetCordinate.X;
            var xEnd = regionF.OffsetCordinate.X + regionF.Width;
            var pen = new Pen(color, PEN_WIDTH);
            for (int i = 1; i < amount - 1; i++)
            {
                var value = values.ElementAt(i);
                var y = ((1f - (value - ymin) / (ymax - ymin)) * heightF) + regionF.OffsetCordinate.Y;

                var currentXStart = xStart;
                var currentXEnd = xStart + DOT_LENGTH;
                while (currentXStart <= xEnd)
                {
                    g.DrawLine(pen, currentXStart, y, currentXEnd, y);
                    currentXStart += DOT_LENGTH + DOT_INTERVAL;
                    currentXEnd = (currentXEnd > xEnd) ? xEnd :  currentXEnd + DOT_LENGTH + DOT_INTERVAL;
                }
            }
            pen.Dispose();
        }

        //Y軸方向
        private void DrawVerticalGrid(RegionF regionF, IEnumerable<float> values, Graphics g)
        {
            var amount = values.Count();
            var widthF = regionF.Width;
            var xmin = values.ElementAt(0);
            var xmax = values.ElementAt(amount - 1);
            var yStart = regionF.OffsetCordinate.Y;
            var yEnd = regionF.OffsetCordinate.Y + regionF.Height;
            var pen = new Pen(color, PEN_WIDTH);
            for (int i = 1; i < amount - 1; i++)
            {
                var value = values.ElementAt(i);
                var x = ((value - xmin) / (xmax - xmin) * widthF) + regionF.OffsetCordinate.X;
                var currentYStart = yEnd;
                var currentYEnd = yEnd - DOT_LENGTH;
                while (yStart <= currentYStart)
                {
                    g.DrawLine(pen, x, currentYStart, x, currentYEnd);
                    currentYStart = currentYStart - (DOT_LENGTH + DOT_INTERVAL);
                    currentYEnd = (currentYEnd < yStart) ? yStart : currentYEnd - (DOT_LENGTH + DOT_INTERVAL);
                }
            }
            pen.Dispose();
        }

        public void SetColor(Color color)
        {
            this.color = color;
        }
    }
}
