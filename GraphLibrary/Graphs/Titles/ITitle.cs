using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphLibrary
{
    internal interface ITitle
    {
        string Title { get; set; }
        Font FontType { get; set; }

        void DrawTitle(RegionF regionF, Graphics g);
    }
}
