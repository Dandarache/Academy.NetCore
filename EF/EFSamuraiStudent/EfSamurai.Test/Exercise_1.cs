using EfSamurai.Data;
using EfSamurai.Domain.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace EfSamurai.Test
{
    [TestClass]
    public class Exercise_1
    {

        [TestInitialize]
        public void Setup()
        {
            var dataAccess = new DataAccess();
            dataAccess.ClearDatabase();
            dataAccess.ClearContext();
        }

        [TestMethod]
        public void add_awesome_quote_to_samuari()
        {
            var dataAccess = new DataAccess();
            var sam = new Samurai
            {
                Name = "Sven",
                Quotes = new List<Quote>()
            };
            dataAccess.Add(sam);
            dataAccess.AddAwesomeQuoteToSamurai("awesomeee", sam);

            dataAccess.ClearContext();
            var result = dataAccess.FindByName("Sven");
            Assert.AreEqual("Sven", result.Name);
            Assert.AreEqual(1, result.Quotes.Count);
            Assert.AreEqual("awesomeee", result.Quotes.First().Text);

        }

        [TestMethod]
        public void update_name_of_samurai()
        {
            var sven = new Samurai
            {
                Name = "Sven",
            };
            var dataAccess = new DataAccess();
            dataAccess.Add(sven);

            dataAccess.ClearContext();
            dataAccess.UpdateSamuraiName("Sven", "Minamoto");

            dataAccess.ClearContext();
            var result = dataAccess.FindByName("Minamoto");
            Assert.AreEqual("Minamoto", result.Name);
        }

        [TestMethod]
        public void replace_secret_identity()
        {
            var sven = new Samurai
            {
                Name = "Hasse",
                SecretIdentity = new SecretIdentity { RealName = "Hans" }
            };
            var dataAccess = new DataAccess();
            dataAccess.Add(sven);

            dataAccess.ClearContext();
            dataAccess.ChangeRealName("Hasse", "Hans-Fredrik");

            dataAccess.ClearContext();
            Assert.AreEqual("Hans-Fredrik", dataAccess.FindByName("Hasse").SecretIdentity.RealName);
        }

        [TestMethod]
        public void add_one_samurai_with_a_lot_of_data()
        {
            var dataAccess = new DataAccess();
            var samurai = new Samurai
            {
                Name = "Kalle",
                Quotes = new List<Quote> {
                  new Quote { Text = "Some awesome quote by Kalle", Style=QuoteStyle.Awesome },
                  new Quote { Text = "Some cheesy quote by Kalle", Style=QuoteStyle.Cheesy },
                  new Quote { Text = "Another cheesy quote by Kalle", Style=QuoteStyle.Cheesy }
              },
                SecretIdentity = new SecretIdentity { RealName = "Karl" },
                SamuraiBattles = new List<SamuraiBattle>
                  {
                      new SamuraiBattle{ Battle = A.Battle1 },
                      new SamuraiBattle{ Battle = A.Battle2 }
                  },
                HairStyle = HairStyle.Chonmage

            };
            dataAccess.Add(samurai);

            dataAccess.ClearContext();
            var sam = dataAccess.FindByName("Kalle");
            Assert.AreEqual("Kalle", sam.Name);
            Assert.AreEqual(3, sam.Quotes.Count);
            Assert.AreEqual(2, sam.Quotes.Count(x => x.Style == QuoteStyle.Cheesy));
            Assert.AreEqual("Karl", sam.SecretIdentity.RealName);
            Assert.AreEqual(HairStyle.Chonmage, sam.HairStyle);
            Assert.AreEqual(2, sam.SamuraiBattles.Count);
            Assert.AreEqual(3,
                sam.SamuraiBattles
                .Select(x => x.Battle)
                .Single(x => x.Name == "Battle 1")
                .BattleLog
                .BattleEvents
                .Count);
            Assert.AreEqual(2,
                sam.SamuraiBattles
                .Select(x => x.Battle)
                .Single(x => x.Name == "Battle 2")
                .BattleLog
                .BattleEvents
                .Count);

        }

        [TestMethod]
        public void add_multiple_samurais()
        {
            var dataAccess = new DataAccess();
            dataAccess.AddMultipleSamurais("Pelle", "Lasse", "Julle");

            dataAccess.ClearContext();
            string[] result1 = dataAccess.FindAllNames();
            CollectionAssert.AreEqual(new[] { "Julle", "Lasse", "Pelle" },
                result1);

            dataAccess.ClearContext();
            dataAccess.AddMultipleSamurais("Klas");

            dataAccess.ClearContext();
            string[] result2 = dataAccess.FindAllNames();

            CollectionAssert.AreEqual(new[] { "Julle", "Klas", "Lasse", "Pelle" },
                result2);
        }

        [TestMethod]
        public void find_samurai_names_in_reverse_order()
        {
            var dataAccess = new DataAccess();
            dataAccess.AddMultipleSamurais("Ai", "Bo", "Zoo", "Ki");

            dataAccess.ClearContext();

            string[] result1 = dataAccess.FindAllNamesInReverseOrder();
            CollectionAssert.AreEqual(new[] { "Zoo", "Ki", "Bo", "Ai" },
                result1);
        }

        [TestMethod]
        public void add_to_each_samurai_name()
        {
            var dataAccess = new DataAccess();
            dataAccess.AddMultipleSamurais("Ai", "Bo", "Ki", "Zoo");

            dataAccess.AddToEachSamuraiName("Zap");

            string[] result1 = dataAccess.FindAllNames();
            CollectionAssert.AreEqual(new[] { "AiZap", "BoZap", "KiZap", "ZooZap" },
                result1);

        }

    }
}
