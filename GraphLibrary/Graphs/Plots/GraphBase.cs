using GraphLibrary.Struct;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GraphLibrary.Graphs.Plots
{
    public abstract class GraphBase : IGraph, IListContainer<DataPoint>
    {

        protected List<DataPoint> datas;

        protected GraphPropertyBase graphPropertyGetter;

        public GraphBase()
        {
            this.datas = new List<DataPoint>();
            this.graphPropertyGetter = new GraphPropertyBase();
        }

        protected bool IsWidthinRangeValue(RangeF xRange, RangeF yRange, DataPoint data)
        {
            if (!xRange.WithinRange(data.XValue)) return false;
            if (!yRange.WithinRange(data.YValue)) return false;
            return true;
        }

        protected float MinMaxScaler(RangeF xRange, float xValue)
        {
            return (xValue - xRange.Min) / (xRange.Max - xRange.Min);
        }

        protected void SetSize(float size)
        {
            this.graphPropertyGetter.SetSize(size);
        }

        protected void SetColor(Color color)
        {
            this.graphPropertyGetter.SetColor(color);
        }

        protected void SetName(string name)
        {
            this.graphPropertyGetter.SetName(name);
        }

        public void Add(DataPoint component)
        {
            this.datas.Add(component);
        }

        public void AddRange(IEnumerable<DataPoint> components)
        {
            foreach(var component in components)
            {
                this.Add(component);
            }
        }

        public void Clear()
        {
            if (this.datas.Count() == 0) return;
            this.datas.Clear();
        }

        public abstract void DrawPlot(RegionF region, RangeF xRange, RangeF yRange, Graphics g);

        public IGraphPropertyGetter GetGraphProperty()
        {
            return this.graphPropertyGetter;
        }

        public void Remove(DataPoint component)
        {
            if (!this.datas.Contains(component)) return;
            this.datas.Remove(component);
        }
    }
}
