using GraphLibrary.Generics;
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

        public void DrawLabel(RegionF regionF, IEnumerable<string> values, Graphics g)
        {
            throw new NotImplementedException();
        }

        public void SetValueFont(Font font)
        {
            this.axisProperty.ValueFont = font;
        }

        public void SetAxisFont(Font font)
        {
            this.axisProperty.AxisFont = font;
        }

        public void SetName(string name)
        {
            this.axisProperty.AxisName = name;
        }
    }
}
