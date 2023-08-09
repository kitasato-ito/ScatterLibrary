using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphLibrary
{
    public interface IListContainer<TComponent>
    {
        void Add(TComponent component);
        void Remove(TComponent component);
        void Clear();
    }
}
