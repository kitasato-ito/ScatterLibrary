using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphLibrary
{
    /// <summary>
    /// InterfaceだとPublicになるので抽象クラス
    /// </summary>
    public abstract class PlotModelBase
    {
        internal abstract void DrawXLabel(RegionF region, Graphics g);
        internal abstract void DrawYLabel(RegionF region, Graphics g);
        internal abstract void DrawLegend(RegionF region, Graphics g);
        internal abstract void DrawTitle(RegionF region, Graphics g);
        internal abstract void DrawGrid(RegionF region, Graphics g);
        internal abstract void DrawPlot(RegionF region, Graphics g);
    }
}
