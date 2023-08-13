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
    public sealed class ScatterPlot : GraphBase
    {
        public ScatterPlot() : base()
        {
            base.SetSize(3f);
            base.SetName("Scatter1");
            base.SetColor(Color.Blue);
        }     

        public override void DrawPlot(RegionF region, RangeF xRange, RangeF yRange, Graphics g)
        {
            int count = base.datas.Count();
            if (count == 0) return;
            var brush = BrushToColorConveter.ConvertColorToBrush(base.graphPropertyGetter.GetColor());
            var size = base.graphPropertyGetter.GetSize();
            for (int i = 0; i < count; i++)
            {
                var dataPoint = base.datas[i];
                if (!base.IsWidthinRangeValue(xRange, yRange, dataPoint)) continue;

                var data = CalcurateDataPoint(region, dataPoint, xRange, yRange);
                var rectF = CalcurateOffsetCordinate(data, size);
                g.FillEllipse(brush, rectF);
            }
            brush.Dispose();
        }

        private PointF CalcurateDataPoint(RegionF region, DataPoint dataPoint, RangeF xRange, RangeF yRange)
        {
            var x = base.MinMaxScaler(xRange, dataPoint.XValue) * region.Width;
            var y = (1 - base.MinMaxScaler(yRange, dataPoint.YValue)) * region.Height;
            return new PointF(region.OffsetCordinate.X + x, region.OffsetCordinate.Y + y);
        }


        private RectangleF CalcurateOffsetCordinate(PointF data, float size)
        {
            var halfSize = size / 2f;
            return new RectangleF(data.X - halfSize, data.Y - halfSize, size, size);
        }

        public void SetScatterSize(float width)
        {
            base.SetSize(width);
        }

        public void SetScatterName(string name)
        {
            base.SetName(name);
        }

        public void SetScatterColor(Color color)
        {
            base.SetColor(color);
        }
    }
}
