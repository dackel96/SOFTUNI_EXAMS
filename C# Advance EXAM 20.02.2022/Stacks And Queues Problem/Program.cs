using System;
using System.Collections.Generic;
using System.Linq;

namespace EXAM_20._02._2022
{
    class Program
    {
        static void Main(string[] args)
        {
            //Изпробвай с double
            decimal[] water = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(decimal.Parse).ToArray();
            decimal[] flour = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(decimal.Parse).ToArray();
            Queue<decimal> waterQueue = new Queue<decimal>(water);
            Stack<decimal> flourStack = new Stack<decimal>(flour);
            Dictionary<string, int> bakery = new Dictionary<string, int>();
            bakery.Add("Croissant", 0);
            bakery.Add("Muffin", 0);
            bakery.Add("Baguette", 0);
            bakery.Add("Bagel", 0);
            while (true)
            {
                decimal currWater = waterQueue.Dequeue();
                decimal currFlour = flourStack.Pop();
                decimal mixed = currWater + currFlour;
                decimal percentageWater = (currWater * 100) / mixed;
                decimal percentageFlour = (currFlour * 100) / mixed;
                if (percentageWater == 50 && percentageFlour == 50)
                {
                    bakery["Croissant"]++;
                }
                else if (percentageFlour == 60 && percentageWater == 40)
                {
                    bakery["Muffin"]++;
                }
                else if (percentageWater == 30 && percentageFlour == 70)
                {
                    bakery["Baguette"]++;
                }
                else if (percentageFlour == 80 && percentageWater == 20)
                {
                    bakery["Bagel"]++;
                }
                else
                {
                    decimal leftFlour = currFlour - currWater;
                    currFlour -= leftFlour;
                    flourStack.Push(leftFlour);
                    bakery["Croissant"]++;
                }
                if (waterQueue.Count == 0 || flourStack.Count == 0)
                {
                    break;
                }
            }
            foreach (var baked in bakery.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
            {
                if (baked.Value == 0)
                {
                    continue;
                }
                else
                {
                    Console.WriteLine($"{baked.Key}: {baked.Value}");
                }
            }
            if (waterQueue.Any())
            {
                Console.WriteLine($"Water left: {string.Join(", ", waterQueue)}");
            }
            else
            {
                Console.WriteLine("Water left: None");
            }
            if (flourStack.Any())
            {
                Console.WriteLine($"Flour left: {string.Join(", ", flourStack)}");
            }
            else
            {
                Console.WriteLine("Flour left: None");
            }
        }
    }
}
