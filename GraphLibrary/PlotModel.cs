using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GraphLibrary.Generics;
using GraphLibrary.Generics.Constant;
using GraphLibrary.Generics.Enum;
using GraphLibrary.Graphs;
using GraphLibrary.Graphs.Grid;
using GraphLibrary.Graphs.Legends;
using GraphLibrary.Graphs.Titles;
using GraphLibrary.Labels;

namespace GraphLibrary
{
    public class PlotModel : IPlotModel
    {
        private IList<IGraph> graphList = new List<IGraph>();

        private ILabel xLabel = new XLabel(DefaultPlotModel.DefaultXLabelName());
        private ILabel yLabel = new YLabel(DefaultPlotModel.DefaultYLabelName());

        private ITitle title = new GraphTitle(DefaultPlotModel.DefaultTitleName());
        private ILegend legend = new GraphLegend();

        private IGridDrawer xGridDrawer = new NullGridDrawer();
        private IGridDrawer yGridDrawer = new NullGridDrawer();

        private AxisValue xAxisValue = DefaultPlotModel.DefaultAxisValue();
        private AxisValue yAxisValue = DefaultPlotModel.DefaultAxisValue();

        public PlotModel()
        {
        }

        private const int DEFAULT_DECIMALPLACES = 0;

        private int xDecimalPlaces = DEFAULT_DECIMALPLACES;
        private int yDecimalPlaces = DEFAULT_DECIMALPLACES;

        public void SetXLabelDecimalValue(DecimalPlaces decimalType)
        {
            this.xDecimalPlaces = (int)decimalType;
        }
        public void SetYLabelDecimalValue(DecimalPlaces decimalType)
        {
            this.yDecimalPlaces = (int)decimalType;
        }

        public void Add(IGraph component)
        {
            this.graphList.Add(component);
            this.legend.Add(component.GetGraphProperty());
        }

        public void Clear()
        {
            if (this.graphList.Count() == 0) return;
            this.graphList.Clear();
            this.legend.Clear();
        }

        public IEnumerable<IGraph> GetGraph()
        {
            return this.graphList;
        }

        private bool showLegend = true;
        public void ShowLegend()
        {
            this.showLegend = true;
        }
        public void HideLegend()
        {
            this.showLegend = false;
        }

        public void Remove(IGraph component)
        {
            if (this.graphList.Count() == 0) return;
            if (!this.graphList.Contains(component)) return;
            this.graphList.Remove(component);
            this.legend.Remove(component.GetGraphProperty());
        }

        public void SetXGrid(GridLineType lineType, Color color)
        {
            this.xGridDrawer = GridFactory.CreateGridDrawer(lineType);
            this.xGridDrawer.SetColor(color);
        }

        public void SetXGrid(Color color)
        {
            this.xGridDrawer.SetColor(color);
        }

        public void SetYGrid(GridLineType lineType, Color color)
        {
            this.yGridDrawer = GridFactory.CreateGridDrawer(lineType);
            this.yGridDrawer.SetColor(color);
        }
        public void SetYGrid(Color color)
        {
            this.yGridDrawer.SetColor(color);
        }

        public void SetLegend(Font font)
        {
            this.legend.FontType = font;
        }

        public void SetTitle(string title, Font font)
        {
            this.title.Title = title;
            this.title.FontType = font;
        }

        public void SetXLabel(AxisValue xAxisValue, string axisName)
        {
            this.xAxisValue = xAxisValue;
            this.xLabel.SetName(axisName);
        }

        public void SetXLabelFont(Font valueFont, Font axisNameFont)
        {
            this.xLabel.SetAxisFont(axisNameFont);
            this.xLabel.SetValueFont(valueFont);
        }

        public void SetYLabel(AxisValue yAxisValue, string axisName)
        {
            this.yAxisValue = yAxisValue;
            this.yLabel.SetName(axisName);
        }

        public void SetYLabelFont(Font valueFont, Font axisNameFont)
        {
            this.yLabel.SetAxisFont(axisNameFont);
            this.yLabel.SetValueFont(valueFont);
        }

        internal void DrawXLabel(RegionF region, Graphics g)
        {
            var decimalString = "F" + xDecimalPlaces.ToString();
            var values = this.xAxisValue.GetEnumerableValues().Select(v => v.ToString(decimalString));
            this.xLabel.DrawLabel(region, values , g);
        }
        internal void DrawYLabel(RegionF region, Graphics g)
        {
            var decimalString = "F" + xDecimalPlaces.ToString();
            var values = this.yAxisValue.GetEnumerableValues().Select(v => v.ToString(decimalString));
            this.yLabel.DrawLabel(region, values, g);
        }
        internal void DrawLegend(RegionF region, Graphics g)
        {
            if (!this.showLegend) return;
            this.legend.DrawLegend(region, g);
        }
        internal void DrawTitle(RegionF region, Graphics g)
        {
            this.title.DrawTitle(region, g);
        }
        internal void DrawGrid(RegionF region, Graphics g)
        {
            this.xGridDrawer.DrawGrid(region, this.xAxisValue, g);
            this.yGridDrawer.DrawGrid(region, this.yAxisValue, g);
        }
        internal void DrawPlot(RegionF region, Graphics g)
        {
            var xRange = this.xAxisValue.GetRange();
            var yRange = this.yAxisValue.GetRange();
            foreach (var graph in this.graphList)
            {
                graph.DrawPlot(region, xRange, yRange, g);
            }
        }
    }
}
