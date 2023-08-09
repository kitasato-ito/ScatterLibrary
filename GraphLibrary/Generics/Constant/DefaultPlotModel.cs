using GraphLibrary.Labels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphLibrary.Generics.Constant
{
    internal static class DefaultPlotModel
    {
        public static string DefaultXLabelName()
        {
            return "X軸";
        }

        public static string DefaultYLabelName()
        {
            return "Y軸";
        }

        public static string DefaultTitleName()
        {
            return "Title";
        }

        public static AxisValue DefaultAxisValue()
        {
            return new AxisValue(0, 10, 5);
        }
    }
}
