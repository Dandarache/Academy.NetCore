using System;
using System.Collections.Generic;
using System.Text;

namespace LinqDemos.Data.Classes
{
    /*
        Övning 13 - Arv 
    */ 
    public class Employee : Person
    {
        /*
            Övning 14 - Egenskaper     
        */
        public int EmployeeId { get; set; }
        public int ManagerId { get; set; }
        public DateTime HireDate { get; set; }

        /*
            Övning 15 - Konstruktor  

            Genom att använda nyckelordet "base" kan parametrar skickas vidare till basklassens
            konstruktor; i detta konstruktorn i fall klassen Person. 
            
            De parametrar som tillhör denna klass som t.ex. hireDate, employeeId och managerId 
            sätts i konstruktorn.
        */ 
        public Employee(
            int employeeId,
            DateTime hireDate,
            int managerId,
            string firstName, 
            string lastName, 
            string nickName,
            GenderType gender,
            DateTime birthdate,
            string streetName,
            string zipcode,
            string city,
            string country
            ) : 
            base(
                firstName, 
                lastName, 
                nickName,
                gender,
                birthdate,
                streetName,
                zipcode,
                city,
                country
                )
        {
            EmployeeId = employeeId;
            HireDate = hireDate;            
            ManagerId = managerId;
        }

        /*
            Övning 16 - Overrides
            
            Även fast detta är en klass som ärver en klass som redan har en override, så 
            är det möjligt att göra ytterligare en override för att specialisera det som 
            skall visas när man i detta fall kör metoden ToString() på en instans av klassen
            Employee.
        */ 
        public override string ToString()
        {
            return $"{this.FirstName} {this.LastName}, {this.Gender}, {this.Age} år gammal, anställd {HireDate.ToString("yyyy-MM-dd")}, anställnings-id: {EmployeeId}";
        }
    }
}
