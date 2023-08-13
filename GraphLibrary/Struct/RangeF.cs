using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphLibrary
{
    public struct RangeF
    {
        public float Min;
        public float Max;
        public RangeF(float min, float max)
        {
            if (min >= max) throw new ValueSettingException();
            this.Min = min;
            this.Max = max;
        }

        public bool WithinRange(float value)
        {
            return this.Min <= value && value <= this.Max;
        }

        public override bool Equals(object obj)
        {
            var r = (RangeF)obj;
            return (this.Min == r.Min &&
                    this.Max == r.Max);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
