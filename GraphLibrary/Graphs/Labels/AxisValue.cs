using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphLibrary.Labels
{
    public class AxisValue
    {
        const int MIN_DIVISION_VALUE = 2;

        public float MinValue;
        public float MaxValue;
        public float DivisionValue;
        public AxisValue(float minValue, float maxValue, float divisionValue)
        {
            if (minValue >= maxValue) throw new ValueSettingException();
            if (divisionValue < MIN_DIVISION_VALUE) throw new ValueSettingException();
            this.MinValue = minValue;
            this.MaxValue = maxValue;
            this.DivisionValue = divisionValue;
        }

        public RangeF GetRange()
        {
            return new RangeF(this.MinValue, this.MaxValue);
        }

        public IEnumerable<float> GetEnumerableValues()
        {
            var index = (this.MaxValue - this.MinValue) / this.DivisionValue;
            for(float i = this.MinValue; i <= this.MaxValue; i += index)
            {
                yield return i;
            }
        }

        public override bool Equals(object obj)
        {
            var axisValue = (AxisValue)obj;
            return (this.MinValue == axisValue.MinValue &&
                    this.MaxValue == axisValue.MaxValue &&
                    this.DivisionValue == axisValue.DivisionValue);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
