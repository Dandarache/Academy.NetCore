using EfSamurai.Data;
using System;

namespace EfSamurai.Consoles
{
    class Program
    {
        static void Main(string[] args)
        {
            DataAccess dataAccess = new DataAccess();
            var foo = dataAccess.ReportQuotesOfType(Domain.Entities.QuoteStyle.Cheesy);

            Console.ReadLine();

        }
    }
}
