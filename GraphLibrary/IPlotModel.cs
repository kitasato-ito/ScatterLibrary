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

namespace GraphLibrary
{
    public interface IPlotModel : IListContainer<IGraph>
    {
        void SetXLabelDecimalValue(DecimalPlaces decimalType);
        void SetXLabel(AxisValue xAxisValue, string axisName);
        void SetXLabelFont(Font valueFont, Font axisNameFont);

        void SetYLabelDecimalValue(DecimalPlaces decimalType);
        void SetYLabel(AxisValue yAxisValue, string axisName);
        void SetYLabelFont(Font valueFont, Font axisNameFont);

        void SetXGrid(GridLineType lineType, Color color);
        void SetXGrid(Color color);
        void SetYGrid(GridLineType lineType, Color color);
        void SetYGrid(Color color);
        void ShowLegend();
        void HideLegend();

        void SetLegend(Font font);

        IEnumerable<IGraph> GetGraph();

        void SetTitle(string title, Font font);

    }
}
