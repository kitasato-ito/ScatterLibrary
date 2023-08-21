using GraphLibrary.Generics;
using GraphLibrary.Generics.Attributes;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphLibrary
{

    public class AttributeTest
    {
        [TestCase(FontNameType.ARIAL, "Arial")]
        [TestCase(FontNameType.BOOK_ANTIQUA, "Book Antiqua")]
        public void GetFontFamilyNameTest(FontNameType fontType, string answer)
        {
            var result = AttributeGetter.GetFontFamilyName<FontNameType>(fontType);
            Assert.Equals(answer, result);
        }

    }
}
