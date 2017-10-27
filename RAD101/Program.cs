using RAD101;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RAD101
{

    public class Player
    {
        // unique Idenifier - MAC address
        public Guid ID { get; set; }
        public string Name { get; set; }
        public int Xp { get; set; }

        public override string ToString()
        {
            return ID.ToString() + " " + Name + " " + Xp.ToString();
        }
    }

    class Program
    {
        static List<Player> players = new List<Player>()
            {
                new Player ( ID = Guid.NewGuid(),  Name = "Pete Vloga", Xp=100),
                new Player ( ID = Guid.NewGuid(),  Name = "John Vloga", Xp=10),
                new Player ( ID = Guid.NewGuid(),  Name = "Nick Vloga", Xp=50),
                new Player ( ID = Guid.NewGuid(),  Name = "Ian Vloga", Xp=120),
            };

        static void Main(string[] args)
        {
            #region Test0
            // return the first occurance of some records
            Player found = players.FirstOrDefault(p => p.Name == ("John"));

            if (found != null)
            {
                Console.WriteLine("{0}", found.ToString());
            }
            else
            {
                Console.WriteLine("Not Found");
            }
            #endregion

            #region Test1
            Player found1 = players.FirstOrDefault(p => p.Name.Contains("Pete"));

            if (found != null)
            {
                Console.WriteLine("{0}", found.ToString());
            }
            else
            {
                Console.WriteLine("Not Found");
            }
            #endregion

            List<Player> topPlayers = topPlayers = players.Where(plr => plr.Xp >= 100).ToList();

            if (topPlayers.Count > 0)
            {
                foreach (var item in topPlayers)
                {
                    Console.WriteLine("{0}", item.ToString());
                }
            }
            else
            {
                Console.WriteLine("Not Found");
            }

            Console.WriteLine();
            // scoreboard is type IEnumerable
            var Scoreboard = players
                .OrderByDescending(o => o.Xp)
                // Dynamic collection / Object collection
                .Select(scores => new { scores.Name, scores.Xp });

            foreach (var item in Scoreboard)
            {
                Console.WriteLine("{0} {1}", item.Name, item.Xp);
            }

            Console.ReadKey();
        
        }
    }
}
