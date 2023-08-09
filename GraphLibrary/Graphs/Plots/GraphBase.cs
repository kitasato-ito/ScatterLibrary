using GraphLibrary.Struct;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphLibrary.Graphs.Plots
{
    public abstract class GraphBase : IGraph, IListContainer<DataPoint>
    {

        protected List<DataPoint> datas;

        protected IGraphPropertyGetter graphPropertyGetter;

        public GraphBase()
        {
            this.datas = new List<DataPoint>();
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
            this.datas.Clear();
        }

        public abstract void DrawPlot(RegionF region, RangeF xRange, RangeF yRange, Graphics g);

        public bool Equals(IGraph other)
        {
            throw new NotImplementedException();
        }

        public abstract IGraphPropertyGetter GetGraphProperty();

        public void Remove(DataPoint component)
        {
            this.datas.Remove(component);
        }
    }
}
