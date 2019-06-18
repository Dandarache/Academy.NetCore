using Academy.ConsoleApp.Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AcademyTests
{
    [TestClass]
    public class CalculatorTests
    {
        /// <summary>
        /// This method will test the add numbers method in calculator.
        /// </summary>
        [TestMethod]
        public void calculator_add_numbers_and_check_sum()
        {
            Calculator calculator = new Calculator();
            int x = 5;
            int y = 7;
            int expectedSum = 12;

            int z = calculator.AddNumbers(x, y);

            Assert.AreEqual(z, expectedSum);
        }

        [TestMethod]
        public void calculator_add_numbers_twice_and_check_sum()
        {
            Calculator calculator = new Calculator();
            int x = 5;
            int y = 7;
            int expectedSum = 24; // 23;

            int z = calculator.AddNumbers(x, y);
            z += calculator.AddNumbers(x, y);

            Assert.AreEqual(z, expectedSum);
        }

        [DataRow(5, 7, 12)]
        [DataRow(3, 5, 8)]
        [DataRow(999, 1, 1000)]
        [TestMethod]
        public void calculator_add_numbers_and_check_sum_using_datarow_attribute(
            int x,
            int y, 
            int expectedSum)
        {
            Calculator calculator = new Calculator();

            int z = calculator.AddNumbers(x, y);

            Assert.AreEqual(z, expectedSum);
        }

        [TestMethod]
        public void caclulate_number_with_modulus()
        {
            Calculator calculator = new Calculator();

            int x = 5;
            int y = 2;
            int expectedSum = 1;

            int z = calculator.CalculateModulus(x, y);

            Assert.AreEqual(z, expectedSum);
        }
    }
}
