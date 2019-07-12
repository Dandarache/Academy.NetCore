using EfSamurai.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EfSamurai.Data
{
    public class DataAccess
    {
        private SamuraiContext _context;
        private MyLoggerProvider _loggerprovider;

        public SamuraiContext GetContextForUnitTests => _context;

        public List<string> DatabaseLog { get; set; } = new List<string>();

        public DataAccess()
        {
            _context = new SamuraiContext();
            _loggerprovider = new MyLoggerProvider();
            _loggerprovider.CommandExecuted += LoggerCommandExecuted;
            _context.GetService<ILoggerFactory>().AddProvider(_loggerprovider);
        }

        private void LoggerCommandExecuted(object sender, string message)
        {
            DatabaseLog.Add(message);
        }

        public void ClearDatabase()
        {
            _context.Database.EnsureCreated();
            _context.RemoveRange(_context.Quotes);
            _context.RemoveRange(_context.Samurais);
            _context.RemoveRange(_context.Battles);
            SaveChanges();
        }

        public void ClearContext()
        {
            _context = new SamuraiContext();
        }

        private void SaveChanges()
        {
            _context.SaveChanges();
        }


        public void AddSamuraiWithLameQuotes(string samuraiName, string[] samuraiQuoteTexts)
        {
            Add(new Samurai
            {
                Name = samuraiName,
                Quotes = samuraiQuoteTexts.Select(x => new Quote
                {
                    Text = x,
                    Style = QuoteStyle.Lame
                }).ToList()
            });

            //Samurai samurai = new Samurai();
            //samurai.Name = samuraiName;
            //samurai.Quotes = new List<Quote>();

            //foreach (var quote in samuraiQuoteTexts)
            //{
            //    samurai.Quotes.Add(
            //        new Quote {
            //            Text = quote,
            //            Style = QuoteStyle.Lame });
            //}

            //Add(samurai);
        }

        public IEnumerable<Samurai> FindSamuraisWithQuotePart(string partOfQuote)
        {
            //var foo = from s in FindAllNames()
            //          let sa = FindByName(s)
            //          where sa.Quotes.Any()

            return FindAllNames()
                .Select(x => FindByName(x))
                .Where(a => a.Quotes
                    .Any(c => c.Text.Contains(partOfQuote))
                )
                .ToList();

            //List<Samurai> samurais = new List<Samurai>();
            //var samuraiNames = FindAllNames();

            //foreach (var samuraiName in samuraiNames)
            //{
            //    var samurai = FindByName(samuraiName);
            //    foreach (var samuraiQuote in samurai.Quotes)
            //    {
            //        if (samuraiQuote.Text.Contains(partOfQuote))
            //        {
            //            samurais.Add(samurai);
            //        }
            //    }
            //}

            //return samurais;
        }

        public string[] ReportNamesWithHaircuts()
        {
            List<string> samuraisWithHaircuts = new List<string>();

            //"Enomoto has haircut oicho",
            //"Hattori has haircut western",
            //"Ishida has haircut chonmage",
            foreach (var samurai in _context.Samurais)
            {
                samuraisWithHaircuts.Add($"{samurai.Name} has haircut {samurai.HairStyle.ToString().ToLower()}");
            }

            return samuraisWithHaircuts.ToArray();
        }

        public string ReportSecretIdentityStatus(string samuraiName)
        {
            Samurai samurai = FindByName(samuraiName);

            // samurai == null
            if (samurai == null)
            {
                return $"Samurai {samuraiName} doesn't exist";
            }

            // SecretIdentity != null
            if (samurai.SecretIdentity != null)
            {
                return $"{samuraiName}'s real name is {samurai.SecretIdentity.RealName}";
            }
            // SecretIdentity == null
            else
            {
                return $"{samuraiName} don't have a secret identity";
            }
        }

        public string[] ReportRealNameOfSamurai()
        {
            List<string> samuraiRealNames = new List<string>();

            var samuraiNames = _context.Samurais.Select(a => a.Name);
            foreach (var samuraiName in samuraiNames)
            {
                var samurai = FindByName(samuraiName);

                // "Ishida's real name is IGOR",
                // "Enomoto's real name is EMELIE",
                // "Hattori's real name is HANS",
                var samuraiString =
                    $"{samurai.Name}'s real name is {samurai.SecretIdentity.RealName.ToUpper()}";

                samuraiRealNames.Add(samuraiString);
            }

            return samuraiRealNames.ToArray();
        }

        public string[] ReportQuotesOfType(QuoteStyle style)
        {
            var result = new List<string>();
            string stylestring = style.ToString().ToLower();
            foreach (var sam in _context.Samurais)
            {
                string name = sam.Name;
                int numQuotes = sam.Quotes.Count(x => x.Style == style);
                if (numQuotes == 0)
                    result.Add($"{name} has no {stylestring} quotes");
                else if (numQuotes == 1)
                    result.Add($"{name} has 1 {stylestring} quote");
                else
                    result.Add($"{name} has {numQuotes} {stylestring} quotes");
            }
            return result.ToArray();
        }

        public string[] ReportBattles(DateTime from, DateTime to, bool? isBrutal)
        {
            var battles = _context.Battles.Where(b => b.StartDate > from && b.EndDate < to);
            var result = new List<string>();
            if (isBrutal != null)
            {
                battles = battles.Where(b => b.IsBrutal == isBrutal);
            }

            foreach (var battle in battles)
            {
                string friendlyOrBrutal = battle.IsBrutal ? "brutal" : "friendly";

                result.Add($"{battle.Name} was a {friendlyOrBrutal} battle within the period");
            }
            return result.ToArray();
        }

        public string[] ReportBattlesWithLog(DateTime from, DateTime to)
        {
            var result = new List<string>();

            foreach (var battle in _context.Battles
                   .Where(b => b.StartDate > from && b.EndDate < to)
                   .Include(b => b.BattleLog.BattleEvents)
                   .OrderBy(b => b.Name))
            {
                result.Add($"Name of battle: {battle.Name}");
                result.Add($"Log name: {battle.BattleLog.Name}");

                foreach (var battleEvent in battle.BattleLog.BattleEvents.OrderBy(ev => ev.Order))
                {
                    result.Add($"Event: {battleEvent.Summary}");
                }

            }
            return result.ToArray();
        }

        public void AddBattles(params Battle[] battles)
        {
            foreach (var battle in battles)
            {
                _context.Battles.Add(battle);
                SaveChanges();
            }
        }

        public SamuraiInfo[] ReportSamuraiInfo()
        {
            return _context.Samurais.Select(s =>
                new SamuraiInfo
                {
                    Name = s.Name,
                    RealName = s.SecretIdentity.RealName,
                    BattleNames = string.Join(",", s.SamuraiBattles.Select(sb => sb.Battle.Name))
                }).ToArray();
        }

        public void Add(params Samurai[] sam)
        {
            _context.Samurais.AddRange(sam);
            SaveChanges();
        }

        public void AddAwesomeQuoteToSamurai(string v, Samurai sam)
        {
            Quote quote = new Quote
            {
                Text = v,
                Style = QuoteStyle.Awesome,
            };
            sam.Quotes.Add(quote);
            SaveChanges();
        }

        public Samurai FindByName(string v)
        {
            return _context.Samurais
                .Include(x => x.Quotes)
                .Include(x => x.SecretIdentity)
                .Include(x => x.SamuraiBattles)
                .ThenInclude(x => x.Battle)
                .ThenInclude(x => x.BattleLog)
                .ThenInclude(x => x.BattleEvents)
                .FirstOrDefault(x => x.Name == v);
        }

        public void UpdateSamuraiName(string oldName, string newName)
        {
            var samurai = FindByName(oldName);
            samurai.Name = newName;
            SaveChanges();
        }

        public void ChangeRealName(string samuraiName, string newSecretIdentityName)
        {
            var samurai = FindByName(samuraiName);
            samurai.SecretIdentity.RealName = newSecretIdentityName;
            SaveChanges();
        }

        public void AddMultipleSamurais(params string[] names)
        {

            _context.Samurais.AddRange(
                names.Select(q => new Samurai { Name = q })
            );

            SaveChanges();

            //foreach (var samName in names)
            //{
            //    Add(new Samurai { Name = samName });
            //}
            //SaveChanges();
        }

        public string[] FindAllNames()
        {
            return _context.Samurais.Select(w => w.Name).OrderBy(a => a).ToArray();

            //List<string> samNames = new List<string>();
            //foreach (var samurai in _context.Samurais)
            //{
            //    samNames.Add(samurai.Name);
            //}
            //var myArray = samNames.ToArray();
            //Array.Sort(myArray);
            //return myArray;
        }

        public string[] FindAllNamesInReverseOrder()
        {
            return _context.Samurais.Select(w => w.Name).OrderByDescending(a => a).ToArray();
        }

        public void AddToEachSamuraiName(string suffix)
        {
            FindAllNames()
                .Select(a => FindByName(a))
                .ToList()
                .ForEach(a => a.Name = $"{a.Name}{suffix}");
            SaveChanges();

            //var samurais = FindAllNames();
            //foreach (var samuraiName in samurais)
            //{
            //    var samurai = FindByName(samuraiName);
            //    samurai.Name = $"{samuraiName}{suffix}";
            //}
            //SaveChanges();
        }

        public List<Samurai> FindSamuraisWithManyQuotes(string sql, int minQuotes)
        {
            /*
             With "FromSql" you can make a pure sql-command
             ...and then continue with Linq to manipulate the result (sort, filter etc)
             */
            return _context.Samurais.FromSql(sql)
                          .Where(s => s.Quotes.Count >= minQuotes)
                          .OrderBy(s => s.Name)
                          .ToList();

            // Misc: "sql" can't contain "order by"
        }


        int _lastLogSize = 0;

        public void OneNewCommandExpected()
        {
            int expectedSize = _lastLogSize + 1;
            int actualSize = DatabaseLog.Count;

            if (actualSize != expectedSize)
                throw new Exception($"ExpectOneMoreLog: I expected size {expectedSize} but got {actualSize}");
            _lastLogSize = DatabaseLog.Count;
        }

        public void NoCommandExpected()
        {
            int expectedSize = _lastLogSize;
            int actualSize = DatabaseLog.Count;
            if (actualSize != expectedSize)
                throw new Exception($"ExpectSameLog: I expected size {expectedSize} but got {actualSize}");
            _lastLogSize = DatabaseLog.Count;
        }

        public void EmptyLogExpected()
        {
            if (DatabaseLog.Count != 0)
                throw new Exception($"ExpectEmptyLog: Log size is {DatabaseLog.Count} but I expected empty");
            _lastLogSize = 0;
        }

        public string[] ReportBattlesForSamurai(string samuraiName)
        {
            /* 
             * "ThenInclude" continues on SamuraiBattles
             * If you only use "Include" then you're stuck at Samurai
             * 
             * "ThenInclude" has to be after "Include" (not from start)
             */

            var samuraiWithBattles = _context.Samurais
              .Where(s => s.Name == samuraiName)
              .Include(s => s.SamuraiBattles)
              .ThenInclude(sb => sb.Battle).FirstOrDefault();

            if (samuraiWithBattles == null)
            {
                return new string[] { };
            }

            return samuraiWithBattles
                .SamuraiBattles
                .Select(x => $"{x.Battle.Name} with startdate {x.Battle.StartDate:yyyy-MM-dd}")
                .ToArray();

        }
    }
}
