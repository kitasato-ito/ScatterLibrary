﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GraphLibrary.Generics;
using GraphLibrary.Generics.Constant;
using GraphLibrary.Generics.Converter;
using GraphLibrary.Generics.Enum;
using GraphLibrary.Graphs;
using GraphLibrary.Graphs.Grid;
using GraphLibrary.Graphs.Legends;
using GraphLibrary.Graphs.Titles;
using GraphLibrary.Labels;
using GraphLibrary.Struct;

namespace GraphLibrary
{
    public class ValuePlotModel : PlotModelBase
    {
        private List<IGraph> graphList = new List<IGraph>();

        private ILabel xLabel = new XLabel(DefaultPlotModel.DefaultXLabelName());
        private ILabel yLabel = new YLabel(DefaultPlotModel.DefaultYLabelName());

        private ITitle title = new GraphTitle(DefaultPlotModel.DefaultTitleName());
        private ILegend legend = new GraphLegend();

        private IGridDrawer xGridDrawer = new NullGridDrawer(false);
        private IGridDrawer yGridDrawer = new NullGridDrawer(true);

        private AxisValue xAxisValue = DefaultPlotModel.DefaultAxisValue();
        private AxisValue yAxisValue = DefaultPlotModel.DefaultAxisValue();

        public ValuePlotModel()
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
            if(!this.graphList.Contains(component))
            {
                this.graphList.Add(component);
                this.legend.Add(component.GetGraphProperty());
            }
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
            //XなのでVertical
            this.xGridDrawer = GridFactory.CreateGridDrawer(lineType, false);
            this.xGridDrawer.SetColor(color);
        }

        public void SetXGrid(Color color)
        {
            this.xGridDrawer.SetColor(color);
        }

        public void SetYGrid(GridLineType lineType, Color color)
        {
            //YなのでHorizontal
            this.yGridDrawer = GridFactory.CreateGridDrawer(lineType, true);
            this.yGridDrawer.SetColor(color);
        }
        public void SetYGrid(Color color)
        {
            this.yGridDrawer.SetColor(color);
        }

        public void SetLegend(FontProperty font)
        {
            this.legend.FontType = font;
        }

        public void SetTitle(string title, FontProperty font)
        {
            this.title.Title = title;
            this.title.FontType = font;
        }

        public void SetXLabel(AxisValue xAxisValue, string axisName)
        {
            this.xAxisValue = xAxisValue;
            this.xLabel.SetName(axisName);
        }

        public void SetXLabelFont(FontProperty valueFont, FontProperty axisNameFont)
        {
            this.xLabel.SetAxisFont(axisNameFont);
            this.xLabel.SetValueFont(valueFont);
        }

        public void SetYLabel(AxisValue yAxisValue, string axisName)
        {
            this.yAxisValue = yAxisValue;
            this.yLabel.SetName(axisName);
        }

        public void SetYLabelFont(FontProperty valueFont, FontProperty axisNameFont)
        {
            this.yLabel.SetAxisFont(axisNameFont);
            this.yLabel.SetValueFont(valueFont);
        }

        internal override void DrawXLabel(RegionF region, Graphics g)
        {
            var decimalString = DecimalPlaceConverter.ConvertIntToDecimalPlace(xDecimalPlaces);
            var values = this.xAxisValue.GetEnumerableValues().Select(v => v.ToString(decimalString));
            this.xLabel.DrawLabel(region, values , g);
        }
        internal override void DrawYLabel(RegionF region, Graphics g)
        {
            var decimalString = DecimalPlaceConverter.ConvertIntToDecimalPlace(yDecimalPlaces);
            var values = this.yAxisValue.GetEnumerableValues().Select(v => v.ToString(decimalString));
            this.yLabel.DrawLabel(region, values, g);
        }
        internal override void DrawLegend(RegionF region, Graphics g)
        {
            if (!this.showLegend) return;
            this.legend.DrawLegend(region, g);
        }
        internal override void DrawTitle(RegionF region, Graphics g)
        {
            this.title.DrawTitle(region, g);
        }
        internal override void DrawGrid(RegionF region, Graphics g)
        {
            var decimalString = DecimalPlaceConverter.ConvertIntToDecimalPlace(xDecimalPlaces);
            var xValues = this.xAxisValue.GetEnumerableValues().Select(v => v.ToString(decimalString));
            var yValues = this.yAxisValue.GetEnumerableValues().Select(v => v.ToString(decimalString));
            this.xGridDrawer.DrawGrid(region, xValues, g);
            this.yGridDrawer.DrawGrid(region, yValues, g);
        }
        internal override void DrawPlot(RegionF region, Graphics g)
        {
            var xRange = this.xAxisValue.GetRange();
            var yRange = this.yAxisValue.GetRange();
            foreach (var graph in this.graphList)
            {
                graph.DrawPlot(region, xRange, yRange, g);
            }
        }

        public bool Contains(IGraph component)
        {
            foreach(var _graph in this.graphList)
            {
                if (_graph.Equals(component)) return true;
            }
            return false;
        }
    }
}
