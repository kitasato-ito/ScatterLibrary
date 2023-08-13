using GraphLibrary.Generics;
using GraphLibrary.Generics.Attributes;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphLibrary.Struct
{
    public struct FontProperty
    {
        public string FontName;
        public float FontSize;

        public Color FontColor;

        public FontProperty(FontNameType fontNameType, float fontSize, Color color)
        {
            this.FontName = AttributeGetter.GetFontFamilyName(fontNameType);
            this.FontSize = fontSize;
            this.FontColor = color;
        }

        public FontProperty(string fontName, float fontSize, Color color)
        {
            this.FontName = fontName;
            this.FontSize = fontSize;
            this.FontColor = color;
        }

    }
}
