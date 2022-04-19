using System;
using System.Collections.Generic;
using System.Linq;
namespace NUMBERS
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split().Select(int.Parse).ToList();
            string[] input = Console.ReadLine().Split().ToArray();

            while (input[0] != "Finish")
            {
                if (input[0] == "Add")
                {
                    int num = int.Parse(input[1]);
                    numbers.Add(num);
                }
                if (input[0] == "Remove")
                {
                    int num = int.Parse(input[1]);
                    for (int i = 0; i < numbers.Count; i++)
                    {
                        if (numbers[i] == num)
                        {
                            numbers.RemoveAt(i);
                            break;
                        }
                    }
                }
                if (input[0] == "Replace")
                {
                    int num = int.Parse(input[1]);
                    int replacement = int.Parse(input[2]);
                    for (int i = 0; i < numbers.Count; i++)
                    {
                        if (numbers[i] == num)
                        {
                            numbers[i] = replacement;
                            break;
                        }
                    }
                }
                if (input[0] == "Collapse")
                {

                    int num = int.Parse(input[1]);
                    for (int i = 0; i < numbers.Count; i++)
                    {
                        if (numbers[i] <= num)
                        {
                            numbers.Remove(numbers[i]);
                        }
                    }
                }
                input = Console.ReadLine().Split().ToArray();
            }
            Console.WriteLine(string.Join(" ",numbers));
        }

    }
}
