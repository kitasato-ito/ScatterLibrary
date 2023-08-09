using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphLibrary
{
    public struct RegionF
    {
        public PointF OffsetCordinate;
        public float Height;
        public float Width;
        public RegionF(float x, float y, float w, float h)
        {
            if (x < 0 || y < 0) throw new ValueSettingException();
            if (h <= 0 || w <= 0) throw new ValueSettingException();
            this.OffsetCordinate = new PointF(x, y);
            this.Width = w;
            this.Height = h;
        }
    }
}
