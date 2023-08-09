using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphLibrary.Graphs.Plots
{
    internal struct PlotProperty
    {
        public string PlotName;
        public Color PlotColor;
        public int Size;

        public PlotProperty(string name, Color color, int size)
        {
            if (String.IsNullOrEmpty(name)) throw new ValueSettingException();
            if (color == null) throw new ValueSettingException();
            if (size < 1) throw new ValueSettingException();
            this.PlotName = name;
            this.PlotColor = color;
            this.Size = size;
        }

        public override bool Equals(object obj)
        {
            var tgt = (PlotProperty)obj;

            return (this.PlotName == tgt.PlotName &&
                    this.PlotColor == tgt.PlotColor);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

    }
}
