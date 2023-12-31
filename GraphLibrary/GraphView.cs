﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GraphLibrary
{
    public interface IGraphView : IGraphViewBase
    {
        PlotModelBase GraphModel { get; set; }
    }

    public partial class GraphView : GraphViewBase, IGraphView
    {

        private PlotModelBase _plotModel = new ValuePlotModel();

        [Browsable(false)]
        public PlotModelBase GraphModel
        {
            get { return this._plotModel; }
            set
            {
                this._plotModel = value;
            }
        }

        public GraphView() : base()
        {
        }

        /// <summary>
        /// Xラベルの描画
        /// </summary>
        /// <param name="region"></param>
        /// <param name="g"></param>
        protected override void DrawXLabel(RegionF region, Graphics g)
        {
            this._plotModel.DrawXLabel(region, g);
        }
        /// <summary>
        /// Yラベルの描画
        /// </summary>
        /// <param name="region"></param>
        /// <param name="g"></param>
        protected override void DrawYLabel(RegionF region, Graphics g)
        {
            this._plotModel.DrawYLabel(region, g);
        }
        /// <summary>
        /// Titleの描画
        /// </summary>
        /// <param name="region"></param>
        /// <param name="g"></param>
        protected override void DrawTitle(RegionF region, Graphics g)
        {
            this._plotModel.DrawTitle(region, g);
        }
        /// <summary>
        /// Legendの描画
        /// </summary>
        /// <param name="region"></param>
        /// <param name="g"></param>
        protected override void DrawLegend(RegionF region, Graphics g)
        {
            this._plotModel.DrawLegend(region, g);
        }
        /// <summary>
        /// Gridの描画
        /// </summary>
        /// <param name="region"></param>
        /// <param name="g"></param>
        protected override void DrawGrid(RegionF region, Graphics g)
        {
            this._plotModel.DrawGrid(region, g);
        }
        /// <summary>
        /// Plotの描画
        /// </summary>
        /// <param name="region"></param>
        /// <param name="g"></param>
        protected override void DrawPlot(RegionF region, Graphics g)
        {
            this._plotModel.DrawPlot(region, g);
        }
    }
}
