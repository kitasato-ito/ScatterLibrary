using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphLibrary.Labels
{
    internal struct AxisProperty
    {
        public string AxisName;
        public Font ValueFont;
        public Font AxisFont;

        public AxisProperty(string name, Font valueFont, Font axisFont)
        {
            this.AxisName = name;
            this.ValueFont = valueFont;
            this.AxisFont = axisFont;
        }

        public override bool Equals(object obj)
        {
            var tgt = (AxisProperty)obj;
            return (this.AxisName == tgt.AxisName);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
