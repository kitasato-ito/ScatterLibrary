using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphLibrary.Generics.Converter
{
    internal static class StringRotate90Converter
    {
        public static string RotateString90(string str)
        {
            if (String.IsNullOrEmpty(str) || String.IsNullOrWhiteSpace(str)) throw new Exception();
            StringBuilder builder = new StringBuilder();
            foreach(char c in str)
            {
                builder.Append(c + Environment.NewLine);
            }
            return builder.ToString();
        }
    }
}
