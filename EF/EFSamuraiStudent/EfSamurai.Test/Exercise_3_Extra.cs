using EfSamurai.Data;
using EfSamurai.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EfSamurai.Test
{
    [TestClass]
    public class Exercise_3_Extra
    {

        [TestInitialize]
        public void Setup()
        {
            var dataAccess = new DataAccess();
            dataAccess.ClearDatabase();
            dataAccess.ClearContext();
        }


        //[TestMethod]
        //public void raw_sql()
        //{
        //    var dataAccess = new DataAccess();

        //    {
        //        dataAccess.Add(new Samurai { Name = "Ashimoto", }, new Samurai { Name = "Ishida", });

        //        // Update names where the second char is a "s"
        //        int affectedRows = dataAccess.UpdateSamuraiNameToHattoriFilterByParameter("_s%");
        //        Assert.AreEqual(2, affectedRows);
        //        string[] result = dataAccess.FindAllNames();
        //        CollectionAssert.AreEqual(new[] {
        //            "HATTORI",
        //            "HATTORI"
        //        }, result);
        //    }

        //    dataAccess.ClearDatabase();
        //    dataAccess.ClearContext();

        //    {
        //        dataAccess.Add(new Samurai { Name = "Ashimoto", }, new Samurai { Name = "Ishida", });

        //        // Update names which ends with "ida"
        //        int affectedRows = dataAccess.UpdateSamuraiNameToHattoriFilterByParameter("%ida");
        //        Assert.AreEqual(1, affectedRows);
        //        string[] result = dataAccess.FindAllNames();
        //        CollectionAssert.AreEqual(new[] {
        //            "Ashimoto",
        //            "HATTORI"
        //        }, result);
        //    }

        //}

        //[TestMethod]
        //public void raw_sql_combined_with_linq()
        //{
        //    var dataAccess = new DataAccess();

        //    dataAccess.Add(
        //        new Samurai
        //        {
        //            Name = "Enomoto",
        //            Quotes = new List<Quote> { new Quote(), new Quote(), new Quote() },
        //        },
        //        new Samurai
        //        {
        //            Name = "Hattori",
        //            Quotes = new List<Quote> { new Quote(), new Quote(), new Quote(), new Quote() },
        //        },
        //        new Samurai
        //        {
        //            Name = "Ishida",
        //            Quotes = new List<Quote> { new Quote() },
        //        },
        //        new Samurai
        //        {
        //            Name = "Pi",
        //            Quotes = new List<Quote> { new Quote(), new Quote(), new Quote() },
        //        }
        //    );

        //    // This sql will just filter out samurai "Pi"
        //    string sql = "select * from Samurais where Len(Name)>2";
        //    {
        //        int minNrOfQuotes = 3;
        //        var result = dataAccess.FindSamuraisWithManyQuotes(sql, minNrOfQuotes);

        //        CollectionAssert.AreEqual(new[] {
        //            "Enomoto",
        //            "Hattori"
        //            }, A.GetSamuraiNames(result));
        //    }

        //    {
        //        int minNrOfQuotes = 4;
        //        var result = dataAccess.FindSamuraisWithManyQuotes(sql, minNrOfQuotes);

        //        CollectionAssert.AreEqual(new[] {
        //            "Hattori",
        //            }, A.GetSamuraiNames(result));
        //    }

        //}



        [TestMethod]
        public void investigate_when_database_is_queried()
        {
            var dataAccess = new DataAccess();
            var context = dataAccess.GetContextForUnitTests;

            string dummy = "";

            dataAccess.EmptyLogExpected();

            context.Add(new Samurai { Name = "Lisa" });
            #region solution
            dataAccess.NoCommandExpected();
            #endregion

            context.SaveChanges();
            #region solution
            dataAccess.OneNewCommandExpected();
            #endregion

            var query1 = context.Samurais;
            #region solution
            dataAccess.NoCommandExpected();
            #endregion

            var query2 = context.Samurais.Where(s => s.Name.StartsWith("P"));
            #region solution
            dataAccess.NoCommandExpected();
            #endregion

            var query3 = query2.Where(s => s.Id > 1);
            #region solution
            dataAccess.NoCommandExpected();
            #endregion

            var query4 = context.Samurais.Where(s => s.Name.StartsWith("P")).ToList();
            #region solution
            dataAccess.OneNewCommandExpected();
            #endregion

            var query5 = query3.FirstOrDefault();
            #region solution
            dataAccess.OneNewCommandExpected();
            #endregion

            var samurais = context.Samurais.ToList();
            #region solution
            dataAccess.OneNewCommandExpected();
            #endregion

            foreach (var samurai in samurais)
            {
                dummy += samurai.Name;
            }
            #region solution
            dataAccess.NoCommandExpected(); // No query needed since we have the result in memort
            #endregion

            foreach (var samurai in context.Samurais)
            {
                dummy += samurai.Name;
            }
            #region solution
            dataAccess.OneNewCommandExpected();
            #endregion

            var first = context.Samurais.First();
            #region solution
            dataAccess.OneNewCommandExpected();
            #endregion

            dummy += first.Name;
            #region solution
            dataAccess.NoCommandExpected();
            #endregion

            context.Samurais.Add(new Samurai { Name = "Sven" });
            #region solution
            dataAccess.NoCommandExpected();
            #endregion

        }

        [TestMethod]
        public void investigate_generated_sql_queries()
        {
            /*
             These three queries gives the same command. A simple "select name from samurai"
             ReverseString is not executed in the database. It will be done in memory
             */
            var dataAccess = new DataAccess();
            var context = dataAccess.GetContextForUnitTests;

            var samurais = context.Samurais
              .Select(s => new { newName = A.ReverseString(s.Name) })
              .ToList();

            var samuraisNeue = context
                .Samurais
                .Select(s => new { s.Name })
                .ToList();

            var samuraisAgain = context.Samurais
                .Select(s => new Samurai { Name = A.ReverseString(s.Name) })
                .ToList();

            var log = dataAccess.DatabaseLog;

            Assert.AreEqual(log[0], log[1]);
            Assert.AreEqual(log[0], log[2]);

            // Hard tests, might break in other versions of EF

            Assert.AreEqual("Executing DbCommand [Parameters=[], CommandType='Text', CommandTimeout='30']\r\nSELECT [s].[Name]\r\nFROM [Samurais] AS [s]", log[0]);

        }

        [TestMethod]
        public void investigate_entry_state()
        {
            var context = new SamuraiContext();
            var s = new Samurai { Name = "Fridolf" };
            Assert.AreEqual(EntityState.Detached, context.Entry(s).State);

            context.Add(s);
            Assert.AreEqual(EntityState.Added, context.Entry(s).State);

            context.SaveChanges();
            Assert.AreEqual(EntityState.Unchanged, context.Entry(s).State);

            s.Name = "Jörgen";
            Assert.AreEqual(EntityState.Modified, context.Entry(s).State);

            context.Samurais.Remove(s);
            Assert.AreEqual(EntityState.Deleted, context.Entry(s).State);

            context.SaveChanges();
            Assert.AreEqual(EntityState.Detached, context.Entry(s).State); // Not "Unchanged" because "Unchanged" means that the entity is in database

        }


        [TestMethod]
        public void investigate_difference_between_find_and_where()
        {
            /*
             Just add a samurai and remember his id
             */
            var dataAccess = new DataAccess();

            var ashimoto = new Samurai { Name = "Ashimoto" };
            dataAccess.Add(ashimoto);
            int ashimotoId = ashimoto.Id;

            /*
             If find is called multiple times with the same id => no extra call is made to the database (good for performace!)
             */
            dataAccess = new DataAccess();
            var context = dataAccess.GetContextForUnitTests;

            dataAccess.ClearContext();
            context = dataAccess.GetContextForUnitTests;

            // Find
            var samurai = context.Samurais.Find(ashimotoId);
            dataAccess.OneNewCommandExpected();

            // Find once more
            var samuraiAgain = context.Samurais.Find(ashimotoId);
            dataAccess.NoCommandExpected();

            // Where
            var samuraisWhere = context.Samurais.Where(s => s.Id == ashimotoId).FirstOrDefault();
            dataAccess.OneNewCommandExpected();

            // Where once more
            var samuraisWhereAgain = context.Samurais.Where(s => s.Id == ashimotoId).FirstOrDefault();
            dataAccess.OneNewCommandExpected();
        }


        [TestMethod]
        public void investigate_id_value_changes_on_entities()
        {
            var context = new SamuraiContext();
            var samurai = new Samurai
            {
                Name = "Kyūzō",
                Quotes = new List<Quote> {
                  new Quote {Text = "Watch out for my sharp sword!"},
                  new Quote {Text = "I told you to watch out for the sharp sword! Oh well!" }
                }
            };

            /* 
             * EF is not involved, so we have of course default values (zero) for the id's
             */
            Assert.IsTrue(samurai.Id == 0);
            Assert.IsTrue(samurai.Quotes.First().Id == 0);

            context.Samurais.Add(samurai);

            /* 
             * Now the samurai is tracked and gets a temporary id (like -2147482647)
             */

            Assert.IsTrue(samurai.Id < -2000000000);
            Assert.IsTrue(samurai.Quotes.First().Id < -2000000000);
            Assert.IsTrue(int.MinValue == -2147483648);

            context.SaveChanges();

            /*
             * After saving the id's is filled with the values from the database
             */
            Assert.IsTrue(samurai.Id > 0);
            Assert.IsTrue(samurai.Quotes.First().Id > 0);
        }

        [TestMethod]
        public void investigate_iqueryable()
        {
            var context = new SamuraiContext();

            IQueryable<Samurai> myquery = context.Samurais.Where(x => x.Name.StartsWith("J") || x.Name.StartsWith("L"));

            /*
             These properties are unique for IQuerable 
             */

            Type elementType = myquery.ElementType;
            System.Linq.Expressions.Expression expression = myquery.Expression;
            IQueryProvider queryProvider = myquery.Provider;

            Assert.AreEqual("Samurai", elementType.Name);
        }

    }
}
