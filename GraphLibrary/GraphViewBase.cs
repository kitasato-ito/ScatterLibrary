using GraphLibrary.Labels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GraphLibrary.Generics.Converter;

namespace GraphLibrary
{
    public interface IGraphViewBase
    {
        void InvalidateView();
    }
    public partial class GraphViewBase : Control, IGraphViewBase
    {
        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
        }

        protected float width;
        protected float height;

        public GraphViewBase()
        {
        }

        private float GetWidth()
        {
            return (float)this.Width;
        }

        private float GetHeight()
        {
            return (float)this.Height;
        }

        public void InvalidateView()
        {
            this.Invalidate();
        }

        protected void UpdateSizeChanged()
        {
            this.width = GetWidth();
            this.height = GetHeight();
        }

        private static readonly float XLABEL_X = 0.1f;
        private static readonly float XLABEL_Y = 0.9f;
        private static readonly float XLABEL_WIDTH = 0.8f;
        private static readonly float XLABEL_HEIGHT = 0.1f;

        private static readonly float YLABEL_X = 0f;
        private static readonly float YLABEL_Y = 0.1f;
        private static readonly float YLABEL_WIDTH = 0.1f;
        private static readonly float YLABEL_HEIGHT = 0.8f;

        private static readonly float TITLE_X = 0.1f;
        private static readonly float TITLE_Y = 0f;
        private static readonly float TITLE_WIDTH = 0.8f;
        private static readonly float TITLE_HEIGHT = 0.1f;

        private static readonly float LEGEND_X = 0.9f;
        private static readonly float LEGEND_Y = 0f;
        private static readonly float LEGEND_WIDTH = 0.1f;
        private static readonly float LEGEND_HEIGHT = 1.0f;

        private static readonly float PLOT_X = 0.1f;
        private static readonly float PLOT_Y = 0.1f;
        private static readonly float PLOT_WIDTH = 0.8f;
        private static readonly float PLOT_HEIGHT = 0.8f;


        /// <summary>
        /// Xラベル領域の獲得
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        protected RegionF ObtainXLabelRegion()
        {
            var x = XLABEL_X * this.width;
            var y = XLABEL_Y * this.height;
            var w = XLABEL_WIDTH * this.width;
            var h = XLABEL_HEIGHT * this.height;
            return new RegionF(x, y, w, h);
        }

        /// <summary>
        /// Yラベル両機の獲得
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        protected RegionF ObtainYLabelRegion()
        {
            var x = YLABEL_X * this.width;
            var y = YLABEL_Y * this.height;
            var w = YLABEL_WIDTH * this.width;
            var h = YLABEL_HEIGHT * this.height;
            return new RegionF(x, y, w, h);
        }

        /// <summary>
        /// Title領域の獲得
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        protected RegionF ObtainTitleRegion()
        {
            var x = TITLE_X * this.width;
            var y = TITLE_Y * this.height;
            var w = TITLE_WIDTH * this.width;
            var h = TITLE_HEIGHT * this.height;
            return new RegionF(x, y, w, h);
        }

        /// <summary>
        /// Legendの領域獲得
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        protected RegionF ObtainLegendRegion()
        {
            var x = LEGEND_X * this.width;
            var y = LEGEND_Y * this.height;
            var w = LEGEND_WIDTH * this.width;
            var h = LEGEND_HEIGHT * this.height;
            return new RegionF(x, y, w, h);
        }

        /// <summary>
        /// Gridの領域獲得
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        protected RegionF ObtainGridRegion()
        {
            return ObtainPlotRegion();
        }

        /// <summary>
        /// Plotの領域獲得
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        protected RegionF ObtainPlotRegion()
        {
            var x = PLOT_X * this.width;
            var y = PLOT_Y * this.height;
            var w = PLOT_WIDTH * this.width;
            var h = PLOT_HEIGHT * this.height;
            return new RegionF(x, y, w, h);
        }

        protected virtual void DrawXLabel(RegionF region, Graphics g)
        {
            throw new NotImplementedException();
        }

        protected virtual void DrawYLabel(RegionF region, Graphics g)
        {
            throw new NotImplementedException();
        }

        protected virtual void DrawTitle(RegionF region, Graphics g)
        {
            throw new NotImplementedException();
        }

        protected virtual void DrawLegend(RegionF region, Graphics g)
        {
            throw new NotImplementedException();
        }

        protected virtual void DrawGrid(RegionF region, Graphics g)
        {
            throw new NotImplementedException();
        }

        protected virtual void DrawPlot(RegionF region, Graphics g)
        {
            throw new NotImplementedException();
        }

        private void DrawPlotArea(RegionF region, Graphics g)
        {
            var brush = BrushToColorConveter.ConvertColorToBrush(Color.Black);
            var pen = new Pen(brush, 1f);
            g.DrawRectangle(pen, region.OffsetCordinate.X, region.OffsetCordinate.Y, region.Width, region.Height);
            pen.Dispose();
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);

            UpdateSizeChanged();

            var graphics = pe.Graphics;

            var xlabelRegion = ObtainXLabelRegion();
            DrawXLabel(xlabelRegion, graphics);

            var ylabelRegion = ObtainYLabelRegion();
            DrawYLabel(ylabelRegion, graphics);

            var titleRegion = ObtainTitleRegion();
            DrawTitle(titleRegion, graphics);

            var legendRegion = ObtainLegendRegion();
            DrawLegend(legendRegion, graphics);

            var gridRegion = ObtainGridRegion();
            DrawPlotArea(gridRegion, graphics);
            DrawGrid(gridRegion, graphics);

            var plotRegion = ObtainPlotRegion();
            DrawPlot(plotRegion, graphics);
        }
    }
}
