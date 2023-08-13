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
    internal class YLabel : ILabel
    {
        private AxisProperty axisProperty;

        public YLabel(string name)
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
            var heightUnit = regionF.Height / (count - 1f);
            var pointF = regionF.OffsetCordinate;
            var valueFont = new Font(valueFontProperty.FontName, valueFontProperty.FontSize);

            //To Hack ; AxisPropertyに入れる
            var valueBrush = BrushToColorConveter.ConvertColorToBrush(this.axisProperty.ValueFont.FontColor);
            for (int i = 0; i < count; i++)
            {
                var x = pointF.X + regionF.Width / 3f * 2f;
                var y = pointF.Y + regionF.Height - (heightUnit * (float)i) - 6f; //6fは補正
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
            var w = regionF.OffsetCordinate.X + regionF.Width / 6f;
            var h = regionF.OffsetCordinate.Y + regionF.Height / 2f;
            var point = new PointF(w, h);
            var axisNameBrush = BrushToColorConveter.ConvertColorToBrush(this.axisProperty.AxisFont.FontColor);
            var name = StringRotate90Converter.RotateString90(this.axisProperty.AxisName);
            g.DrawString(name, nameFont, axisNameBrush, point);
            nameFont.Dispose();
            axisNameBrush.Dispose();
        }

        public void DrawLabel(RegionF regionF, IEnumerable<string> values, Graphics g)
        {
            if (values.Count() < 2) throw new CountOutOfRangeException("要素は2以上にしてください");
            DrawValue(regionF, values, g);
            DrawName(regionF, g);
        }

        public void SetValueFont(FontProperty font)
        {
            this.axisProperty.ValueFont = font;
        }

        public void SetAxisFont(FontProperty font)
        {
            this.axisProperty.AxisFont = font;
        }

        public void SetName(string name)
        {
            this.axisProperty.AxisName = name;
        }
    }
}
