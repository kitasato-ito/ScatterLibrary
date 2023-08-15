using GraphLibrary.Generics;
using GraphLibrary.Generics.Constant;
using GraphLibrary.Graphs.Plots;
using GraphLibrary.Struct;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GraphLibrary.Generics.Converter;

namespace GraphLibrary.Graphs.Legends
{
    internal class GraphLegend : ILegend
    {
        private IList<IGraphPropertyGetter> legendList = new List<IGraphPropertyGetter>();

        public FontProperty FontType { get; set; } = DefaultFont.DefaultLabelNameFont();

        public void Add(IGraphPropertyGetter component)
        {
            if (this.legendList.Contains(component)) return;
            this.legendList.Add(component);
        }

        public void Clear()
        {
            if (this.legendList.Count() == 0) return;
            this.legendList.Clear();
        }

        public bool Contains(IGraphPropertyGetter component)
        {
            foreach(var _legend in legendList)
            {
                if (_legend.Equals(component)) return true;
            }
            return false;
        }

        public void DrawLegend(RegionF region, Graphics g)
        {
            var count = this.legendList.Count();
            if (count == 0) return;

            var hStep = region.Height / (float)(count+2);
            var wStart = region.OffsetCordinate.X + region.Width / 10f;
            var wEnd = region.OffsetCordinate.X + region.Width;
            for(int i = 0; i < count; i++)
            {
                var component = this.legendList[i];
                var name = component.GetName();
                var color = component.GetColor();
                var font = new Font(FontType.FontName, FontType.FontSize);
                var brush = BrushToColorConveter.ConvertColorToBrush(color);
                var h = region.OffsetCordinate.Y + hStep * (float)(i + 1);
                g.DrawString(name, font, brush, new PointF(wStart,h));
                font.Dispose();
                brush.Dispose();
            }
        }


        public void Remove(IGraphPropertyGetter component)
        {
            if (!this.legendList.Contains(component)) return;
            this.legendList.Clear();
        }
    }
}
