using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GraphLibrary.Generics.Converter;

namespace GraphLibrary.Graphs.Plots
{
    public sealed class BarPlot : GraphBase
    {
        public BarPlot() : base()
        {
            base.SetSize(10);
        }
        public override void DrawPlot(RegionF region, RangeF xRange, RangeF yRange, Graphics g)
        {
            
        }

        public void SetBarWidth(float width)
        {
            base.SetSize(width);
        }

        public void SetBarGraphName(string name)
        {
            base.SetName(name);
        }

        public void SetBarColor(Color color)
        {
            base.SetColor(color);
        }
    }
}
