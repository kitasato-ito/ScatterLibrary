using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphLibrary.Struct
{
    public struct DataPoint
    {
        public float XValue;
        public float YValue;

        public DataPoint(float x, float y)
        {
            this.XValue = x;
            this.YValue = y;
        }

        public override bool Equals(object obj)
        {
            var d = (DataPoint)obj;
            return (this.XValue == d.XValue && 
                    this.YValue == d.YValue);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
