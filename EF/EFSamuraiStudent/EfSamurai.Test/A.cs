using EfSamurai.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfSamurai.Test
{
    public class A
    {

        public static Battle Battle1
        {
            get
            {
                return new Battle
                {
                    Name = "Battle 1",
                    Description = "Description of battle 1",
                    IsBrutal = true,
                    StartDate = new DateTime(1710, 2, 3),
                    EndDate = new DateTime(1710, 2, 8),
                    BattleLog = new BattleLog
                    {
                        Name = "Battlelog for battle 1",
                        BattleEvents = new List<BattleEvent>
                    {
                        new BattleEvent{Summary="Summary of event (order1, battle1)",Description="Description of event (order1, battle1)", Order=1 },
                        new BattleEvent{Summary="Summary of event (order2, battle1)",Description="Description of event (order2, battle1)", Order=2 },
                        new BattleEvent{Summary="Summary of event (order3, battle1)",Description="Description of event (order3, battle1)", Order=3 },
                    }
                    }

                };
            }

        }

        public static Battle Battle2
        {
            get
            {
                return new Battle
                {
                    Name = "Battle 2",
                    Description = "Description of battle 2",
                    IsBrutal = false,
                    StartDate = new DateTime(1805, 5, 6),
                    EndDate = new DateTime(1805, 5, 12),
                    BattleLog = new BattleLog
                    {
                        Name = "Battlelog for battle 2",
                        BattleEvents = new List<BattleEvent>
                    {
                        new BattleEvent{Summary="Summary of event (order1, battle2)",Description="Description of event (order1, battle2)", Order=1 },
                        new BattleEvent{Summary="Summary of event (order2, battle2)",Description="Description of event (order2, battle2)", Order=2 },
                    }
                    }

                };
            }
        }

        public static List<string> GetSamuraiNames(IEnumerable<Samurai> sams)
        {
            return sams.Select(x => x.Name).ToList();
        }

        public static string ReverseString(string value)
        {
            var stringChar = value.AsEnumerable();
            return string.Concat(stringChar.Reverse());
        }
    }
}
