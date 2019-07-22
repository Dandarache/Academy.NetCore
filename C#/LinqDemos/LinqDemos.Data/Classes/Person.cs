using System;
using System.Collections.Generic;
using System.Text;

namespace LinqDemos.Data.Classes
{
    /*
        Övning 1 - Skapa en klass.
    */
    public class Person
    {
        /*
            Övning 2 - Lägg till egenskaper till klassen.
        */
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string NickName { get; set; }
        public string StreetName { get; private set; }
        public string Zipcode { get; private set; }
        public string City { get; private set; }
        public string Country { get; set; }

        /*
            Övning 3 - Klassvariabler
            
            Variabeln nedan kommer bara att vara tillgänglig för metoder och egenskaper 
            via en instans av denna klass.

            Nyckelordet "readonly" behövs egentligen inte, men är bra att använda i detta 
            fall eftersom det gör att det bara går att sätta värdet för _birthDate när 
            en ny instans av klassen skapas. Det är med andra ord bara när konstruktorn körs 
            som man kan sätta värdet för en klassvariabel märkt med readonly. 
        */
        private readonly DateTime _birthdate;

        /*
            Övning 5 - Egenskaper 

            Genom att bara ha en "get" för egenskapen BirthDate är det bara möjligt att
            läsa värdet egenskapen BirthDate som returnerar klassvariabeln _birthDate.
        */
        public DateTime Birthdate
        {
            get
            {
                return _birthdate;
            }
        }

        /*
            Övning 6 - Egenskaper
            
            Egenskapen nedan har bara en "getter" vilket gör att den bara kan läsas av 
            klasser utifrån. 

            Värdet som returneras är beräknat baserat på födelsedatumet som angavs när
            instansen skapades, dvs när man anropade konstruktorn för klassen. 
            
            Åldern kan räknas ut på flera olika sätt och implementationen nedan är ett 
            exempel på en implementation.
        */ 
        public int Age
        {
            get
            {
                return ((int)(DateTime.Today.Subtract(_birthdate).TotalDays) / 365);
            }
        }

        /*
            Övning 7 - Enum
            Övning 8 - Egenskaper
            
            Egenskapen nedan används för att kunna ange kön på en person.

            Det är bara möjligt att ändra på värdet genom att anropa instans-metoder eftersom
            att "set" är satt till private.
            
            Datatypen är satt till GenderType som är en enum.
            Använd "Goto Definition (F12)" för att ta dig en titt på implementationen av enum.
        */ 
        public GenderType Gender { get; private set; }

        /*
            Övning 8 - Egenskaper

            Denna metod finns inte med i övningarna för repetition av C#, men är ett exempel
            på en instansmetod som kan användas för att t. ex. byta kön på en person.
        */
        public void ChangeGender(GenderType newGender)
        {
            Gender = newGender;
        }

        /*
            Övning 12 - Egenskaper  
        */ 
        public string FullName
        {
            get
            {
                return $"{FirstName} {LastName}";
                //return string.Format("{0} {1}", FirstName, LastName);
            }
        }

        /*
            Oftast är det en god idé att ha en tom konstruktor för en klass eftersom att
            bl.a. LINQ och .NET-ramverket använder t.ex. object initializers för att skapa 
            instanser av klasser.

            En annan sak som använder tomma konstruktorer är en teknik som kallas för 
            serialisering av objekt. 
        */
        public Person()
        {

        }

        /*
            Övning 4 - Konstruktorer  
        */
        public Person(string firstName, string lastName, DateTime birthDate)
        {
            FirstName = firstName;
            LastName = lastName;

            // Sätt klassvariabeln _birthDate.
            _birthdate = birthDate;
        }

        /*
            Övning 9 - Konstruktorer  
        */
        public Person(
            string firstName, 
            string lastName, 
            string nickName,
            GenderType gender,
            DateTime birthdate,
            string streetName,
            string zipcode,
            string city,
            string country)
        {
            FirstName = firstName;
            LastName = lastName;
            NickName = nickName;
            _birthdate = birthdate;
            Gender = gender;
            StreetName = streetName;
            Zipcode = zipcode;
            City = city;
            Country = country;
        }

        /*
            Övning 10 - Overrides
            
            Nedan ser ni ett exempel på en override av metoden ToString().
            Genom att göra en override är det möjligt att skräddarsy och specialisera
            redan befintliga metoder med din egen implementation.
        */
        public override string ToString()
        {
            return $"{FirstName} {LastName} ({NickName}), {Gender.ToString()}, {Age} år gammal";
        }

        /*
            Övning 11 - Statiska metoder
            
            Metoden nedan är statisk vilket innebär att den bara kan anropas direkt på klassen.
            Det går inte att anropa metoden på en instans av Person.
        */ 
        public static Person Create(
            string firstName,
            string lastName,
            string nickName,
            GenderType gender,
            DateTime birthdate,
            string streetName,
            string zipcode,
            string city,
            string country)
        {
            Person person = new Person(firstName, lastName, birthdate);

            person.NickName = nickName;
            person.Gender = gender;
            person.StreetName = streetName;
            person.Zipcode = zipcode;
            person.City = city;
            person.Country = country;

            return person;
        }
    }
}
