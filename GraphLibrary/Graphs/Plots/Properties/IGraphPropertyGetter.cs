using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphLibrary.Graphs.Plots
{
    public interface IGraphPropertyGetter
    {
        string GetName();
        Color GetColor();

        float GetSize();
    }
}
