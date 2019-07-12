using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace EfSamurai.Test
{
    [TestClass]
    public class Exercise_0
    {
        [TestMethod]
        public void sort_employees_based_on_age_and_list_top_5()
        {
            DataAccessAcademy dataAccessAcademy = new DataAccessAcademy();

            //var employees = dataAccessAcademy.ListEmployeeIdsSortedByAge(5);

            //CollectionAssert.AreEqual(new[] { "Julle", "Klas", "Lasse", "Pelle" },
            //    employees);


        }

        [TestMethod]
        public void list_employees_with_age_between_25_and_40()
        {

        }

        [TestMethod]
        public void list_male_employees_with_pets()
        {

        }

        [TestMethod]
        public void list_full_name_of_employees_in_descending_order()
        {

        }

        [TestMethod]
        public void list_female_employees_that_live_in_stockholm()
        {
        }

        [TestMethod]
        public void list_employees_that_hanna_manages()
        {
        }

        [TestMethod]
        public void count_male_employees_that_lives_in_borlange()
        {
        }
    }
}
