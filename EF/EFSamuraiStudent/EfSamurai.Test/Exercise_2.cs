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
    public class Exercise_2
    {

        [TestInitialize]
        public void Setup()
        {
            var dataAccess = new DataAccess();
            dataAccess.ClearDatabase();
            dataAccess.ClearContext();
        }


        [TestMethod]
        public void find_samurais_with_quote_part()
        {
            var dataAccess = new DataAccess();
            dataAccess.AddSamuraiWithLameQuotes("Enomoto", new[] { "fiskquote1", "quote2" });
            dataAccess.AddSamuraiWithLameQuotes("Hattori", new[] { "quote3", "quote4" });
            dataAccess.AddSamuraiWithLameQuotes("Ishida", new[] { "quote5", "quote6fisk" });

            dataAccess.ClearContext();
            IEnumerable<Samurai> sams = dataAccess.FindSamuraisWithQuotePart("fisk");

            CollectionAssert.AreEqual(new[] {
                "Enomoto", "Ishida"
            }, A.GetSamuraiNames(sams));
        }

        [TestMethod]
        public void report_samurai_secret_status()
        {
            var dataAccess = new DataAccess();
            var hasse = new Samurai
            {
                Name = "Hasse",
                SecretIdentity = new SecretIdentity { RealName = "Hans" }
            };
            dataAccess.Add(hasse);

            var ishida = new Samurai
            {
                Name = "Ishida",
            };
            dataAccess.Add(ishida);

            dataAccess.ClearContext();

            Assert.AreEqual("Hasse's real name is Hans",
                dataAccess.ReportSecretIdentityStatus("Hasse"));

            Assert.AreEqual("Ishida don't have a secret identity",
                dataAccess.ReportSecretIdentityStatus("Ishida"));

            Assert.AreEqual("Samurai Sven doesn't exist",
                dataAccess.ReportSecretIdentityStatus("Sven"));
        }

        [TestMethod]
        public void report_samurais_names_with_their_haircut()
        {
            var dataAccess = new DataAccess();
            dataAccess.Add(new Samurai
            {
                Name = "Enomoto",
                HairStyle = HairStyle.Oicho
            });

            dataAccess.Add(new Samurai
            {
                Name = "Hattori",
                HairStyle = HairStyle.Western
            });

            dataAccess.Add(new Samurai
            {
                Name = "Ishida",
                HairStyle = HairStyle.Chonmage
            });

            string[] result = dataAccess.ReportNamesWithHaircuts();

            CollectionAssert.AreEqual(new[] {
                "Enomoto has haircut oicho",
                "Hattori has haircut western",
                "Ishida has haircut chonmage",
            }, result);
        }

        [TestMethod]
        public void report_real_name_of_samurai()
        {
            var dataAccess = new DataAccess();
            dataAccess.Add(new Samurai
            {
                Name = "Ishida",
                SecretIdentity = new SecretIdentity { RealName = "Igor" }
            });

            dataAccess.Add(new Samurai
            {
                Name = "Enomoto",
                SecretIdentity = new SecretIdentity { RealName = "Emelie" }
            });

            dataAccess.Add(new Samurai
            {
                Name = "Hattori",
                SecretIdentity = new SecretIdentity { RealName = "Hans" }
            });

            string[] result = new DataAccess().ReportRealNameOfSamurai();

            CollectionAssert.AreEqual(new[] {
                "Ishida's real name is IGOR",
                "Enomoto's real name is EMELIE",
                "Hattori's real name is HANS",
            }, result);
        }

        [TestMethod]
        public void report_quotes_of_certain_type()
        {
            var dataAccess = new DataAccess();
            dataAccess.Add(new Samurai
            {
                Name = "Enomoto",
                Quotes = new List<Quote>
                {
                    new Quote
                    {
                        Style=QuoteStyle.Lame,
                        Text="Life is what happens to you while you're busy making other plans."
                    },
                                        new Quote
                    {
                        Style=QuoteStyle.Lame,
                        Text="Live, laugh, love."
                    }
                }
            });

            dataAccess.Add(new Samurai
            {
                Name = "Hattori",
                Quotes = new List<Quote>
                {
                    new Quote
                    {
                        Style=QuoteStyle.Lame,
                        Text="Everything happens for a reason."
                    },
                    new Quote
                    {
                        Style=QuoteStyle.Awesome,
                        Text="Even if you fall on your face, you’re still moving forward."
                    }
                }
            });

            string[] result = dataAccess.ReportQuotesOfType(QuoteStyle.Lame);

            CollectionAssert.AreEqual(new[] {
                "Enomoto has 2 lame quotes",
                "Hattori has 1 lame quote"
            }, result);

            string[] result2 = dataAccess.ReportQuotesOfType(QuoteStyle.Awesome);

            CollectionAssert.AreEqual(new[] {
                "Enomoto has no awesome quotes",
                "Hattori has 1 awesome quote"
            }, result2);

        }

        [TestMethod]
        public void report_battles()
        {
            var dataAccess = new DataAccess();

            dataAccess.AddBattles(A.Battle1, A.Battle2);

            // Only brutal battles
            {
                string[] result = new DataAccess().ReportBattles(
                    new DateTime(1700, 1, 1),
                    new DateTime(1900, 1, 1),
                    true);

                CollectionAssert.AreEqual(new[] {
                "Battle 1 was a brutal battle within the period",
                }, result);

            }

            // Only friendly battles
            {
                string[] result = new DataAccess().ReportBattles(
                    new DateTime(1700, 1, 1),
                    new DateTime(1900, 1, 1),
                    false);

                CollectionAssert.AreEqual(new[] {
                "Battle 2 was a friendly battle within the period"
                }, result);
            }

            // Both (note that third parameter is "null")
            {
                string[] result = new DataAccess().ReportBattles(
                    new DateTime(1700, 1, 1),
                    new DateTime(1900, 1, 1),
                    null);

                CollectionAssert.AreEqual(new[] {
                "Battle 1 was a brutal battle within the period",
                "Battle 2 was a friendly battle within the period"
                }, result);
            }

            // Filtering by date
            {
                string[] result = new DataAccess().ReportBattles(
                    new DateTime(1800, 1, 1),
                    new DateTime(1900, 1, 1),
                    null);

                CollectionAssert.AreEqual(new[] {
                "Battle 2 was a friendly battle within the period"
                }, result);
            }

        }

        [TestMethod]
        public void report_battles_with_log()
        {
            var dataAccess = new DataAccess();
            dataAccess.AddBattles(A.Battle1, A.Battle2);

            {
                string[] result = new DataAccess().ReportBattlesWithLog(
                    new DateTime(1700, 1, 1),
                    new DateTime(1900, 1, 1));

                CollectionAssert.AreEqual(new[] {
                "Name of battle: Battle 1",
                "Log name: Battlelog for battle 1",
                "Event: Summary of event (order1, battle1)",
                "Event: Summary of event (order2, battle1)",
                "Event: Summary of event (order3, battle1)",

                "Name of battle: Battle 2",
                "Log name: Battlelog for battle 2",
                "Event: Summary of event (order1, battle2)",
                "Event: Summary of event (order2, battle2)",
                }, result);

            }

            // filter by date
            {
                string[] result = new DataAccess().ReportBattlesWithLog(
                    new DateTime(1800, 1, 1),
                    new DateTime(1900, 1, 1));

                CollectionAssert.AreEqual(new[] {
                "Name of battle: Battle 2",
                "Log name: Battlelog for battle 2",
                "Event: Summary of event (order1, battle2)",
                "Event: Summary of event (order2, battle2)",
                }, result);

            }

        }


        [TestMethod]
        public void report_samurai_info()
        {
            var dataAccess = new DataAccess();
            dataAccess.Add(new Samurai
            {
                Name = "Ishida",
                SecretIdentity = new SecretIdentity { RealName = "Igor" },
                SamuraiBattles = new List<SamuraiBattle>
                {
                    new SamuraiBattle{Battle=A.Battle1},
                    new SamuraiBattle{Battle=A.Battle2},
                }
            }, new Samurai
            {
                Name = "Enomoto",
                SecretIdentity = new SecretIdentity { RealName = "Emelie" },
                SamuraiBattles = new List<SamuraiBattle>
                {
                    new SamuraiBattle{Battle=A.Battle2},
                }
            });

            SamuraiInfo[] result = new DataAccess().ReportSamuraiInfo();

            Assert.AreEqual(2, result.Length);

            Assert.AreEqual("Ishida", result[0].Name);
            Assert.AreEqual("Igor", result[0].RealName);
            Assert.AreEqual("Battle 1,Battle 2", result[0].BattleNames);

            Assert.AreEqual("Enomoto", result[1].Name);
            Assert.AreEqual("Emelie", result[1].RealName);
            Assert.AreEqual("Battle 2", result[1].BattleNames);
        }

        [TestMethod]
        public void report_battles_for_samurai()
        {
            var dataAccess = new DataAccess();
            dataAccess.Add(
                new Samurai
                {
                    Name = "Hattori",
                    SamuraiBattles = new List<SamuraiBattle>
                      {
                          new SamuraiBattle{ Battle = A.Battle1 },
                          new SamuraiBattle{ Battle = A.Battle2 }
                      },
                },
                new Samurai
                {
                    Name = "Ishida",
                    SamuraiBattles = new List<SamuraiBattle>
                      {
                          new SamuraiBattle{ Battle = A.Battle2 }
                      },
                });

            {
                string[] result = dataAccess.ReportBattlesForSamurai("Hattori");
                CollectionAssert.AreEqual(new[] {
                    "Battle 1 with startdate 1710-02-03",
                    "Battle 2 with startdate 1805-05-06",

                }, result);

            }

            {
                string[] result = dataAccess.ReportBattlesForSamurai("Ishida");
                CollectionAssert.AreEqual(new[] {
                    "Battle 2 with startdate 1805-05-06",

                }, result);

            }

            {
                string[] result = dataAccess.ReportBattlesForSamurai("Sverker");
                CollectionAssert.AreEqual(new string[] {

                }, result);

            }

        }
    }
}
