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

        public void DrawGrid(RegionF regionF, IEnumerable<string> values, Graphics g)
        {
            if (values.Count() <= 2) return;
            if (this.isHorizontalGrid)
            {
                DrawHorizontalGrid(regionF, values, g);
            }
            else
            {
                DrawVerticalGrid(regionF, values, g);
            }
        }

        //X軸方向
        private void DrawHorizontalGrid(RegionF regionF, IEnumerable<string> values, Graphics g)
        {
            var amount = values.Count() - 1;
            var heightF = regionF.Height;
            var xStart = regionF.OffsetCordinate.X;
            var xEnd = regionF.OffsetCordinate.X + regionF.Width;
            var pen = new Pen(color, PEN_WIDTH);
            var stepHeight = heightF / (float)amount;
            var h = heightF - stepHeight;
            for (int i = 1; i < amount; i++)
            {
                var y = h + regionF.OffsetCordinate.Y;
                var currentXStart = xStart;
                var currentXEnd = xStart + DOT_LENGTH;
                while (currentXStart <= xEnd)
                {
                    g.DrawLine(pen, currentXStart, y, currentXEnd, y);
                    currentXStart += DOT_LENGTH + DOT_INTERVAL;
                    currentXEnd = (currentXEnd > xEnd) ? xEnd :  currentXEnd + DOT_LENGTH + DOT_INTERVAL;
                }
                h -= stepHeight;
            }
            pen.Dispose();
        }

        //Y軸方向
        private void DrawVerticalGrid(RegionF regionF, IEnumerable<string> values, Graphics g)
        {
            var amount = values.Count() - 1;
            var widthF = regionF.Width;
            var yStart = regionF.OffsetCordinate.Y;
            var yEnd = regionF.OffsetCordinate.Y + regionF.Height;
            var pen = new Pen(color, PEN_WIDTH);
            var stepWidth = widthF / (float)amount;
            var w = stepWidth;
            for (int i = 1; i < amount; i++)
            {
                var x = w + regionF.OffsetCordinate.X;
                var currentYStart = yEnd;
                var currentYEnd = yEnd - DOT_LENGTH;
                while (yStart <= currentYStart)
                {
                    g.DrawLine(pen, x, currentYStart, x, currentYEnd);
                    currentYStart = currentYStart - (DOT_LENGTH + DOT_INTERVAL);
                    currentYEnd = (currentYEnd < yStart) ? yStart : currentYEnd - (DOT_LENGTH + DOT_INTERVAL);
                }
                w += stepWidth;
            }
            pen.Dispose();
        }

        public void SetColor(Color color)
        {
            this.color = color;
        }
    }
}
