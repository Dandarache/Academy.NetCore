using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace CSharpByTopics.ExtensionMethods
{
    public static class DateTimeExtensions
    {
        public static string FormatCountryDate(
            this DateTime inputValue, 
            string countryCode)
        {
            CultureInfo cultureInfo = new CultureInfo(countryCode);

            string shortDateFormatString =
                cultureInfo.DateTimeFormat.ShortDatePattern;

            return inputValue.ToString(shortDateFormatString);
        }
    }
}
