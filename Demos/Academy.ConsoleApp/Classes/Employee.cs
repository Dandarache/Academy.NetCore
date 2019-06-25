using System;
using System.Collections.Generic;
using System.Text;

namespace Academy.ConsoleApp.Classes
{
    public class Employee : Person
    {
        public int EmployeeId { get; private set; }
        public int ManagerId { get; private set; }

        public Employee(
            string firstName, 
            string lastName, 
            int age, 
            DateTime birthdate, 
            GenderType gender, 
            int employeeId, int 
            managerId
            ) : 
            base(
                firstName, 
                lastName, 
                age, 
                birthdate, 
                gender
                )
        {
            EmployeeId = employeeId;
            ManagerId = managerId;
        }
    }
}
