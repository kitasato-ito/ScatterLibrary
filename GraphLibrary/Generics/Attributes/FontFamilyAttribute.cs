using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphLibrary.Generics.Attributes
{
    internal class FontFamilyAttribute : Attribute
    {
        private string Name;
        public FontFamilyAttribute(string name)
        {
            this.Name = name;
        }

        public string GetName()
        {
            return this.Name;
        }
    }
}
