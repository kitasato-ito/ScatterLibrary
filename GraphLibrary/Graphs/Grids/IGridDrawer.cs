using GraphLibrary.Generics.Enum;
using GraphLibrary.Graphs.Grid;
using GraphLibrary.Labels;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphLibrary.Graphs
{
    internal interface IGridDrawer
    {
        void SetColor(Color color);
        void DrawGrid(RegionF regionF, AxisValue axisValue, Graphics g);
    }
}
