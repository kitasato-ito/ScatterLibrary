using GraphLibrary.Generics;
using GraphLibrary.Generics.Converter;
using GraphLibrary.Struct;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphLibrary.Graphs.Titles
{
    public class GraphTitle : ITitle
    {
        public string Title { get; set; }
        public FontProperty FontType { get; set; } = DefaultFont.DefaultTitleFont();

        public GraphTitle(string name)
        {
            this.Title = name;
        }


        public void DrawTitle(RegionF regionF, Graphics g)
        {
            var halfWidth = regionF.Width / 2f;
            var h = regionF.Height / 3f;
            var font = new Font(this.FontType.FontName, this.FontType.FontSize);

            var point = new PointF(regionF.OffsetCordinate.X + halfWidth, regionF.OffsetCordinate.Y + h);
            var brush = BrushToColorConveter.ConvertColorToBrush(this.FontType.FontColor);
            g.DrawString(this.Title, font, brush, point);

            font.Dispose();
            brush.Dispose();
        }
    }
}
