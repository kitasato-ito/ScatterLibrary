using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GraphLibrary.Generics.Enum;
using GraphLibrary.Graphs;
using GraphLibrary.Graphs.Grid;
using GraphLibrary.Labels;
using GraphLibrary.Struct;

namespace GraphLibrary
{
    public interface IPlotModel : IListContainer<IGraph>
    {
        void SetXLabelDecimalValue(DecimalPlaces decimalType);
        void SetXLabel(AxisValue xAxisValue, string axisName);
        void SetXLabelFont(FontProperty valueFont, FontProperty axisNameFont);

        void SetYLabelDecimalValue(DecimalPlaces decimalType);
        void SetYLabel(AxisValue yAxisValue, string axisName);
        void SetYLabelFont(FontProperty valueFont, FontProperty axisNameFont);

        void SetXGrid(GridLineType lineType, Color color);
        void SetXGrid(Color color);
        void SetYGrid(GridLineType lineType, Color color);
        void SetYGrid(Color color);
        void ShowLegend();
        void HideLegend();

        void SetLegend(FontProperty font);

        IEnumerable<IGraph> GetGraph();

        void SetTitle(string title, FontProperty font);

    }
}
