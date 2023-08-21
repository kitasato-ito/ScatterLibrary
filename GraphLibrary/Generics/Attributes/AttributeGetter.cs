using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;
[assembly: InternalsVisibleTo("GraphLibrary.Test")]

namespace GraphLibrary.Generics.Attributes
{

    internal static class AttributeGetter
    {
        public static string GetFontFamilyName<TEnum>(TEnum target) 
            where TEnum : System.Enum
        {
            var att = typeof(TEnum).GetField(target.ToString()).GetCustomAttribute<FontFamilyAttribute>();
            return att.GetName();
        }
    }
}
