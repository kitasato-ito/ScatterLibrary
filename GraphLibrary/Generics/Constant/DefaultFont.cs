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
        public static Font DefaultTitleFont()
        {
            return new Font(new FontFamily("Arial"), 7f);
        }
        public static Font DefaultLabelValueFont()
        {
            return new Font(new FontFamily("Arial"), 7f);
        }
        public static Font DefaultLabelNameFont()
        {
            return new Font(new FontFamily("Arial"), 9f);
        }
    }
}
