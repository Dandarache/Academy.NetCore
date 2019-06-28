using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Academy.ConsoleApp.Classes
{
    public class ZipCodeValidator
    {
        /// <summary>
        /// This method will match and return true for '12345' and '123 45' zipcodes.
        /// Other strings will return false.
        /// </summary>
        /// <param name="zipcodeString">The zipcode string.</param>
        /// <returns>Tru or false depending on if the zipcode is valid or not.</returns>
        public static bool Validate(string zipcodeString, out string formattedZipcode)
        {
            string myPattern = @"^(\d{3})\s?(\d{2})$";
            Regex regex = new Regex(myPattern);

            bool isMatch = regex.IsMatch(zipcodeString);

            var matches = regex.Match(zipcodeString);

            formattedZipcode = $"{matches.Groups[1]} {matches.Groups[2]}";

            return isMatch;
            //return regex.IsMatch(zipcodeString);
        }
    }
}
