using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace EXAMProblem01
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string cmd = Console.ReadLine();
            StringBuilder sbInput = new StringBuilder();
            while (cmd != "Finish")
            {
                string[] splitedCmd = cmd.Split();
                if (splitedCmd[0] == "Replace")
                {
                    string subst = splitedCmd[1];
                    string newsubst = splitedCmd[2];
                    if (input.Contains(subst))
                    {
                        input = input.Replace(subst, newsubst);
                        Console.WriteLine(input);
                    }
                }
                else if (splitedCmd[0] == "Cut")
                {
                    int startIndex = int.Parse(splitedCmd[1]);
                    int endIndex = int.Parse(splitedCmd[2]);
                    if (startIndex < 0)
                    {
                        Console.WriteLine("Invalid indices!");
                    }
                    else if (endIndex > input.Length)
                    {
                        Console.WriteLine("Invalid indices!");
                    }
                    else
                    {
                        input = input.Remove(startIndex, (endIndex + 1) - startIndex);
                        Console.WriteLine(input);
                    }
                }
                else if (splitedCmd[0] == "Make")
                {
                    string lowerOrUpper = splitedCmd[1];
                    if (lowerOrUpper == "Upper")
                    {
                        input = input.ToUpper();
                        Console.WriteLine(input);
                    }
                    else if (lowerOrUpper == "Lower")
                    {
                        input = input.ToLower();
                        Console.WriteLine(input);
                    }
                }
                else if (splitedCmd[0] == "Check")
                {
                    string subst = splitedCmd[1];
                    if (input.Contains(subst))
                    {
                        Console.WriteLine($"Message contains {subst}");
                    }
                    else
                    {
                        Console.WriteLine($"Message doesn't contain {subst}");
                    }
                }
                else if (splitedCmd[0] == "Sum")
                {
                    int startIndex = int.Parse(splitedCmd[1]);
                    int endIndex = int.Parse(splitedCmd[2]);
                    if (startIndex <= 0)
                    {
                        Console.WriteLine("Invalid indices!");
                    }
                    else if (endIndex > input.Length)
                    {
                        Console.WriteLine("Invalid indices!");
                    }
                    else
                    {
                        string sumOfTheSubs = input.Substring(startIndex, (endIndex + 1) - startIndex);
                        char[] charArr = sumOfTheSubs.ToCharArray();
                        int sum = 0;
                        for (int i = 0; i < charArr.Length; i++)
                        {
                            sum += charArr[i];
                        }
                        Console.WriteLine(sum);
                    }
                }
                cmd = Console.ReadLine();
            }
        }
    }
}
