using GraphLibrary.Graphs.Plots;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace GraphLibrary.Generics.Constant
{
    internal static class DefaultProperty
    {

        public static Color DefaultPlotColor()
        {
            return Color.Black;
        }

        public static string DefaultLabelName()
        {
            return "Label1";
        }

        public static string DefaultPlotName()
        {
            return "Graph1";
        }
        public static int DefaultPlotSize()
        {
            return 5;
        }

        public static PlotProperty GetDefaultProperty()
        {
            var _property = new PlotProperty(DefaultPlotName(),DefaultPlotColor(), DefaultPlotSize());
            return _property;
        }
    }
}
