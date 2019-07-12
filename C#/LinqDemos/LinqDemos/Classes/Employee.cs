using System;
using System.Collections.Generic;
using System.Text;

namespace EfSamurai.Test.Classes
{
    public class Employee : Person
    {
        public int EmployeeId { get; private set; }
        public int ManagerId { get; private set; }

        public Employee(
            string firstName, 
            string lastName, 
            DateTime birthdate, 
            GenderType gender, 
            int employeeId, 
            int managerId,
            bool hasPet
            ) : 
            base(
                firstName, 
                lastName, 
                birthdate, 
                gender,
                hasPet
                )
        {
            EmployeeId = employeeId;
            ManagerId = managerId;
        }
    }
}
