using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
namespace EXAMProblem03
{
    class Program
    {
        static void Main(string[] args)
        {
            string patt = @"([#|$|%|*|&])(?<name>[A-Za-z]+)\1[=](?<digit>\d+)[!]{2}(?<crypt>[\w\W]+)";
            bool isFound = false;
            while (!isFound)
            {
                string input = Console.ReadLine();
                Match matches = Regex.Match(input, patt);
                if (matches.Success)
                {

                    string name = matches.Groups["name"].Value.ToString();
                    string length = matches.Groups["digit"].Value.ToString();
                    int lengthIndex = int.Parse(length);
                    string crypt = matches.Groups["crypt"].Value.ToString();
                    if (crypt.Length == lengthIndex)
                    {
                        char[] charArr = crypt.ToCharArray();
                        for (int i = 0; i < charArr.Length; i++)
                        {
                            //char symb = (char)i
                            char symb = charArr[i];
                            symb += (char)lengthIndex;
                            charArr[i] = symb;
                        }
                        string result = new string(charArr);
                        Console.WriteLine($"Coordinates found! {name} -> {result}");
                        isFound = true;
                    }
                    else
                    {
                        Console.WriteLine("Nothing found!");
                    }
                }
                else
                {
                    Console.WriteLine("Nothing found!");
                }
            }
        }
    }
}