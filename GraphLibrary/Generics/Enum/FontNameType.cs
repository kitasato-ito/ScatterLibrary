﻿using GraphLibrary.Generics.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;
[assembly: InternalsVisibleTo("GraphLibrary.Test")]

namespace GraphLibrary.Generics
{
    public enum FontNameType
    {
        [FontFamily("Arial")]
        ARIAL,
        [FontFamily("Book Antiqua")]
        BOOK_ANTIQUA,
    }
}
