using System;

namespace theHuntingGames
{
    class Program
    {
        static void Main(string[] args)
        {
            int days = int.Parse(Console.ReadLine());
            int players = int.Parse(Console.ReadLine());
            double groupEnergy = double.Parse(Console.ReadLine());
            double waterPerDay = double.Parse(Console.ReadLine());
            double foodPerDay = double.Parse(Console.ReadLine());

            double totalFood = days * players * foodPerDay;
            double totalWater = days * players * waterPerDay;

            for (int currDay = 1; currDay <= days; currDay++)
            {
                double chopingWood = double.Parse(Console.ReadLine());
                groupEnergy -= chopingWood;
                if (groupEnergy <= 0)
                {
                    Console.WriteLine($"You will run out of energy. You will be left with {totalFood:f2} food and {totalWater:f2} water.");
                    return;
                }
                if (currDay % 2 == 0)
                {
                    groupEnergy += groupEnergy * 0.05;
                    totalWater -= totalWater * 0.30;
                }
                if (currDay % 3 == 0)
                {
                    totalFood -= totalFood / players;
                    groupEnergy += groupEnergy * 0.10;
                }
            }
            Console.WriteLine($"You are ready for the quest. You will be left with - {groupEnergy:f2} energy!");
        }
    }
}
