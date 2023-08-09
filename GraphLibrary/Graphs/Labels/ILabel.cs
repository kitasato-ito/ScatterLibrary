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
        void SetValueFont(Font font);
        void SetAxisFont(Font font);
        void SetName(string name);

        void DrawLabel(RegionF regionF, IEnumerable<string> values, Graphics g);

        string GetAxisName();
    }
}
