using GraphLibrary.Struct;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphLibrary.Generics
{
    internal class DefaultFont
    {
        public static FontProperty DefaultTitleFont()
        {
            return new FontProperty(FontNameType.ARIAL, 7f, Color.Black);
        }
        public static FontProperty DefaultLabelValueFont()
        {
            return new FontProperty(FontNameType.ARIAL, 7f, Color.Black);
        }
        public static FontProperty DefaultLabelNameFont()
        {
            return new FontProperty(FontNameType.ARIAL, 7f, Color.Black);
        }
    }
}
