using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GraphLibrary.Generics.Converter;

namespace GraphLibrary.Graphs.Plots
{
    public sealed class LinePlot : GraphBase
    {
        public LinePlot() : base()
        {
            base.SetSize(2);
        }
        public override void DrawPlot(RegionF region, RangeF xRange, RangeF yRange, Graphics g)
        {
            throw new NotImplementedException();
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
