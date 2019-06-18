using Academy.ConsoleApp.Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace AcademyTests
{
    [TestClass]
    public class ZipCodeTests
    {
        [TestMethod]
        public void validate_valid_zipcode()
        {
            //string zipcodeText = "Nånting dumt här...";
            string zipcodeText = "780 68";
            //string zipcodeText = "784 32";

            bool result =
                ZipCodeValidator.Validate(zipcodeText, out string formattedZipCode);

            Assert.IsTrue(result);
        }

        [DataRow("780 68")]
        [DataRow("784 32")]
        [DataRow("72592")]
        [TestMethod]
        public void validate_valid_zipcode_datarow(string zipcodeString)
        {
            bool result =
                ZipCodeValidator.Validate(zipcodeString, out string formattedZipCode);

            Assert.IsTrue(result);

            Assert.AreEqual(formattedZipCode.Length, 6);
        }

        [DataRow("7 8 0 6 8")]
        [DataRow("78 432")]
        [DataRow("7 2592")]
        [TestMethod]
        public void validate_invalid_zipcode_datarow(string zipcodeString)
        {
            bool result =
                ZipCodeValidator.Validate(zipcodeString, out string formattedZipCode);

            Assert.IsFalse(result);
        }
    }
}
