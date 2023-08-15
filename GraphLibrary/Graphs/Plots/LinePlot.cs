using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GraphLibrary.Generics.Converter;
using GraphLibrary.Struct;

namespace GraphLibrary.Graphs.Plots
{
    public sealed class LinePlot : GraphBase
    {
        private const float DEFAULT_LINE_WIDTH = 2f;
        private const string DEFAULT_LINENAME = "Line1";
        private readonly static Color DEFAULT_LINE_COLOR = Color.Blue;
        public LinePlot() : base()
        {
            base.SetSize(DEFAULT_LINE_WIDTH);
            base.SetName(DEFAULT_LINENAME);
            base.SetColor(DEFAULT_LINE_COLOR);
        }


        public override void DrawPlot(RegionF region, RangeF xRange, RangeF yRange, Graphics g)
        {
            int count = base.datas.Count();
            if (count == 0) return;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            var brush = BrushToColorConveter.ConvertColorToBrush(base.graphPropertyGetter.GetColor());
            var width = base.graphPropertyGetter.GetSize();
            var pen = new Pen(brush, width);
            for (int i = 1; i < count; i++)
            {
                var data1 = CalcuratePoint(region, base.datas[i - 1], xRange, yRange);
                var data2 = CalcuratePoint(region, base.datas[i], xRange, yRange);
                g.DrawLine(pen, data1.X, data1.Y, data2.X, data2.Y);
            }
            
            brush.Dispose();
            pen.Dispose();
        }

        private PointF CalcuratePoint(RegionF region, DataPoint dataPoint, RangeF xRange, RangeF yRange)
        {
            var x = base.MinMaxScaler(xRange, dataPoint.XValue) * region.Width;
            var y = (1 - base.MinMaxScaler(yRange, dataPoint.YValue)) * region.Height;
            return new PointF(region.OffsetCordinate.X + x, region.OffsetCordinate.Y + y);
        }

        public void SetLineWidth(float width)
        {
            base.SetSize(width);
        }

        public void SetLineName(string name)
        {
            base.SetName(name);
        }

        public void SetLineColor(Color color)
        {
            base.SetColor(color);
        }
    }
}
