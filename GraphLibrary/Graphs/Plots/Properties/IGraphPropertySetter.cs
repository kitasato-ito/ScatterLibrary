using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphLibrary.Graphs.Plots
{
    internal interface IGraphPropertySetter
    {
        void SetName(string name);
        void SetColor(Color color);

        void SetSize(float _size);
    }
}
