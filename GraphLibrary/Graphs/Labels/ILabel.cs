using GraphLibrary.Struct;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphLibrary.Labels
{
    internal interface ILabel
    {
        void SetValueFont(FontProperty font);
        void SetAxisFont(FontProperty font);
        void SetName(string name);

        void DrawLabel(RegionF regionF, IEnumerable<string> values, Graphics g);

        string GetAxisName();
    }
}
