using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphLibrary.Generics.Converter
{
    internal static class DecimalPlaceConverter
    {
        public static string ConvertIntToDecimalPlace(int decimalPlaces)
        {
            const string F = "F";
            if (decimalPlaces < 0) throw new ValueSettingException();
            return F + decimalPlaces.ToString();
        }
    }
}
