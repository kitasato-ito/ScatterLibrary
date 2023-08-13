using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphLibrary.Graphs.Labels
{
    public interface IAxisValue
    {
        RangeF GetRange();
        IEnumerable<float> GetEnumerableValues();
    }
}
