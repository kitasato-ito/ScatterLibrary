using GraphLibrary.Generics;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphLibrary.Graphs.Grids
{
    internal class InwardScaleGridDrawer : IGridDrawer
    {
        private Color color = DefaultColor.DefaultGridColor();

        private bool isHorizontalGrid = false;

        private const int PEN_WIDTH = 2;

        private const float INWARD_SCALE_LENGTH = 6f;

        public InwardScaleGridDrawer(bool isHorizontalGrid)
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
        private void DrawHorizontalGrid(RegionF regionF, IEnumerable<string> values, Graphics g)
        {
            var amount = values.Count() - 1;
            var heightF = regionF.Height;
            var x0 = regionF.OffsetCordinate.X;
            var x1 = regionF.OffsetCordinate.X + INWARD_SCALE_LENGTH;
            var pen = new Pen(color, PEN_WIDTH);
            var stepHeight = heightF / (float)amount;
            var h = heightF - stepHeight;
            for (int i = 1; i < amount; i++)
            {
                var y = h + regionF.OffsetCordinate.Y;
                g.DrawLine(pen, x0, y, x1, y);
                h -= stepHeight;
            }
            pen.Dispose();
        }

        //Y軸方向
        private void DrawVerticalGrid(RegionF regionF, IEnumerable<string> values, Graphics g)
        {
            var amount = values.Count() - 1;
            var widthF = regionF.Width;
            var y0 = regionF.OffsetCordinate.Y + regionF.Height;
            var y1 = y0 - INWARD_SCALE_LENGTH;
            var pen = new Pen(color, PEN_WIDTH);
            var stepWidth = widthF / (float)amount;
            var w = stepWidth;
            for (int i = 1; i < amount; i++)
            {
                var x = w + regionF.OffsetCordinate.X;
                g.DrawLine(pen, x, y0, x, y1);
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
