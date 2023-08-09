using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphLibrary.Graphs.Grid
{
    public struct GridProperty
    {
        public Color gridColor;

        public GridProperty(Color color)
        {
            this.gridColor = color;
        }

        public override bool Equals(object obj)
        {
            var prop = (GridProperty)obj;
            return (this.gridColor == prop.gridColor);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
