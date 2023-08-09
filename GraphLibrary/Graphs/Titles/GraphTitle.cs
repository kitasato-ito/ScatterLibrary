using GraphLibrary.Generics;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphLibrary.Graphs.Titles
{
    public class GraphTitle : ITitle
    {
        public string Title { get; set; }
        public Font FontType { get; set; } = DefaultFont.DefaultTitleFont();

        public GraphTitle(string name)
        {
            this.Title = name;
        }


        public void DrawTitle(RegionF regionF, Graphics g)
        {
            throw new NotImplementedException();
        }
    }
}
