using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
namespace EXAMProblem02
{
    class Stats
    {
        public int HP { get; set; }
        public int MP { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Stats> heroDictonary = new Dictionary<string, Stats>();
            
            string input = Console.ReadLine();
            while (input != "Results")
            {
                string[] cmds = input.Split(":");
                if (cmds[0] == "Add")
                {
                    string name = cmds[1];
                    int hp = int.Parse(cmds[2]);
                    int energy = int.Parse(cmds[3]);
                    if (!heroDictonary.ContainsKey(name))
                    {
                        heroDictonary.Add(name, new Stats());
                        heroDictonary[name].HP = hp;
                        heroDictonary[name].MP = energy;
                    }
                    else
                    {
                        heroDictonary[name].HP += hp;
                    }
                }
                else if (cmds[0] == "Attack")
                {
                    string attacker = cmds[1];
                    string defender = cmds[2];
                    int dmg = int.Parse(cmds[3]);
                    if (heroDictonary.ContainsKey(attacker) && heroDictonary.ContainsKey(defender))
                    {
                        heroDictonary[defender].HP -= dmg;
                        heroDictonary[attacker].MP -= 1;
                        if (heroDictonary[defender].HP <= 0)
                        {
                            heroDictonary.Remove(defender);
                            Console.WriteLine($"{defender} was disqualified!");
                        }
                        if (heroDictonary[attacker].MP <= 0)
                        {
                            heroDictonary.Remove(attacker);
                            Console.WriteLine($"{attacker} was disqualified!");
                        }
                    }
                }
                else if (cmds[0] == "Delete")
                {
                    string name = cmds[1];
                    if (heroDictonary.ContainsKey(name))
                    {
                        heroDictonary.Remove(name);
                    }
                    else if (name == "All")
                    {
                        heroDictonary = new Dictionary<string, Stats>();
                    }
                }
                input = Console.ReadLine();
            }
            Console.WriteLine($"People count: {heroDictonary.Count}");
            heroDictonary = heroDictonary.OrderBy(x => x.Key).ToDictionary(x => x.Key, v => v.Value);
            foreach (var hero in heroDictonary.OrderByDescending(x => x.Value.HP))
            {
                Console.WriteLine($"{hero.Key} - {hero.Value.HP} - {hero.Value.MP}");
            }
        }
    }
}
