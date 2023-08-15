using GraphLibrary.Exceptions;
using GraphLibrary.Generics;
using GraphLibrary.Generics.Converter;
using GraphLibrary.Struct;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphLibrary.Labels
{
    internal class XLabel : ILabel
    {
        private AxisProperty axisProperty;

        private Color color = Color.Black;

        public XLabel(string name)
        {
            this.axisProperty = new AxisProperty(name, DefaultFont.DefaultLabelValueFont(), DefaultFont.DefaultLabelNameFont());
        }

        public string GetAxisName()
        {
            return this.axisProperty.AxisName;
        }

        private void DrawValue(RegionF regionF, IEnumerable<string> values, Graphics g)
        {
            var valueFontProperty = this.axisProperty.ValueFont;
            var count = (float)values.Count();
            var widthUnit = regionF.Width / (count - 1f);
            var pointF = regionF.OffsetCordinate;
            var valueFont = new Font(valueFontProperty.FontName, valueFontProperty.FontSize);
            //To Hack ; AxisPropertyに入れる
            var valueBrush = BrushToColorConveter.ConvertColorToBrush(this.axisProperty.ValueFont.FontColor);
            for (int i = 0; i < count; i++)
            {
                var x = pointF.X + widthUnit * (float)i - 5f; //6fは補正
                var y = pointF.Y;
                var _point = new PointF(x, y);
                g.DrawString(values.ElementAt(i), valueFont, valueBrush, _point);
            }
            valueFont.Dispose();
            valueBrush.Dispose();
        }

        private void DrawName(RegionF regionF, Graphics g)
        {
            var nameFontProperty = this.axisProperty.AxisFont;
            var nameFont = new Font(nameFontProperty.FontName, nameFontProperty.FontSize);
            var w = regionF.OffsetCordinate.X + regionF.Width / 2f;
            var h = regionF.OffsetCordinate.Y + regionF.Height / 2f;
            var point = new PointF(w, h);
            var axisNameBrush = BrushToColorConveter.ConvertColorToBrush(this.axisProperty.AxisFont.FontColor);
            g.DrawString(this.axisProperty.AxisName, nameFont, axisNameBrush, point);
            nameFont.Dispose();
            axisNameBrush.Dispose();
        }

        public void DrawLabel(RegionF regionF, IEnumerable<string> values, Graphics g)
        {
            if (values.Count() < 2) throw new CountOutOfRangeException("要素は2以上にしてください");
            DrawValue(regionF, values, g);
            DrawName(regionF, g);
        }

        public void SetName(string name)
        {
            this.axisProperty.AxisName = name;
        }

        public void SetValueFont(FontProperty font)
        {
            this.axisProperty.ValueFont = font;
        }

        public void SetAxisFont(FontProperty font)
        {
            this.axisProperty.AxisFont = font;
        }
    }
}
