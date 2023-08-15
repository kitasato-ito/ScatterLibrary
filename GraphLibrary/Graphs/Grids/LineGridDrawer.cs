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
    internal class LineGridDrawer : IGridDrawer
    {
        private Color color = DefaultColor.DefaultGridColor();

        private bool isHorizontalGrid = false;

        private const int PEN_WIDTH = 2;

        public LineGridDrawer(bool isHorizontalGrid)
        {
            this.isHorizontalGrid = isHorizontalGrid;
        }


        public void DrawGrid(RegionF regionF, AxisValue axisValue, Graphics g)
        {
            var values = axisValue.GetEnumerableValues();
            if(values.Count() <= 2) return;
            if(isHorizontalGrid)
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
            var x0 = regionF.OffsetCordinate.X;
            var x1 = regionF.OffsetCordinate.X + regionF.Width;
            var pen = new Pen(color, PEN_WIDTH);
            for (int i = 1; i < amount - 1; i++)
            {
                var value = values.ElementAt(i);
                var y = ((1f - (value - ymin) / (ymax - ymin)) * heightF) + regionF.OffsetCordinate.Y;
                g.DrawLine(pen, x0, y, x1, y);
            }
            pen.Dispose();
        }

        //Y軸方向
        private void DrawVerticalGrid(RegionF regionF, IEnumerable<float> values, Graphics g)
        {
            var amount = values.Count();
            var widthF = regionF.Width;
            var xmin = values.ElementAt(0);
            var xmax = values.ElementAt(amount-1);
            var y0 = regionF.OffsetCordinate.Y;
            var y1 = regionF.OffsetCordinate.Y + regionF.Height;
            var pen = new Pen(color, PEN_WIDTH);
            for (int i = 1; i < amount-1; i++)
            {
                var value = values.ElementAt(i);
                var x = ((value - xmin) / (xmax - xmin) * widthF) + regionF.OffsetCordinate.X;
                g.DrawLine(pen, x, y0, x, y1);
            }
            pen.Dispose();
        }

        public void SetColor(Color color)
        {
            this.color = color;
        }
    }
}
