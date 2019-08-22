using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Globalization;

namespace CSharpByTopics.ExtensionMethods
{
    public class ExtensionMethodDemo
    {
        public void Run()
        {
            //-------------------------
            // String Extensions
            //-------------------------

            string myValue = "Dan Jansson Academy";
            Console.WriteLine(myValue.TakeOnlyTwoWords());

            string myValue1 = "Dan Jansson Academy dfhsdkjhkljds";
            Console.WriteLine(myValue1.TakeOnlyTwoWords());

            string myValue2 = "Dan Jansson";
            Console.WriteLine(myValue2.TakeOnlyTwoWords());
            Console.WriteLine("Laban Jansson Academy".TakeOnlyTwoWords());
            Console.WriteLine("Laban Jansson Academy TJena Hej Lunch".WordCount());


            var testString = "Laban Haban Filibaban";
            Console.WriteLine(testString.Reverse());
            Console.WriteLine(testString.Delimit("-%-"));
            Console.WriteLine(testString.Repeat(3));


            //-------------------------
            // DateTime Extensions
            //-------------------------

            DateTime myDate = DateTime.Now;
            Console.WriteLine(myDate.FormatCountryDate("en-US"));
            Console.WriteLine(myDate.FormatCountryDate("en"));
            Console.WriteLine(myDate.FormatCountryDate("de"));
            Console.WriteLine(myDate.FormatCountryDate("sv"));

            //-------------------------
            // Int Extensions
            //-------------------------

            var myNumericValue = 145;
            var result = myNumericValue.MultiplyAndAdd3000(7);
            Console.WriteLine(result);

        }
    }
}
