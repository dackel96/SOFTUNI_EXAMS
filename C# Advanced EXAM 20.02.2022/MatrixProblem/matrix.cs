using System;
using System.Collections.Generic;
using System.Linq;

namespace matrixpart
{
    class Program
    {
        static void Main(string[] args)
        {
            int rowCol = int.Parse(Console.ReadLine());
            char[,] field = new char[rowCol, rowCol];
            int braveRow = 0;
            int braveCol = 0;
            int woods = 0;
            List<char> woodsSymb = new List<char>();
            for (int row = 0; row < field.GetLength(0); row++)
            {
                string[] rowInput = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                for (int col = 0; col < field.GetLength(1); col++)
                {
                    field[row, col] = char.Parse(rowInput[col]);
                    char symb = char.Parse(rowInput[col]);
                    if (field[row, col] == 'B')
                    {
                        braveRow = row;
                        braveCol = col;
                    }
                    else if (char.IsLower(symb))
                    {
                        woods++;
                    }
                }
            }
            int totalWood = woods;
            string cmd = Console.ReadLine();
            while (cmd != "end")
            {
                if (woods == 0)
                {
                    break;
                }
                if (cmd == "up")
                {
                    if (IsInRange(field, braveRow - 1, braveCol))
                    {
                        braveRow -= 1;
                        char letter = field[braveRow, braveCol];
                        if (char.IsLower(letter))
                        {
                            woodsSymb.Add(letter);
                            woods--;
                            field[braveRow, braveCol] = 'B';
                            field[braveRow + 1, braveCol] = '-';
                        }
                        else if (field[braveRow, braveCol] == 'F')
                        {
                            if (braveRow > 0)
                            {
                                field[0, braveCol] = 'B';
                                field[braveRow + 1, braveCol] = '-';
                                field[braveRow, braveCol] = '-';
                                braveRow = 0;
                            }
                            else
                            {
                                char letter1 = field[field.GetLength(0) - 1, braveCol];
                                field[field.GetLength(0) - 1, braveCol] = 'B';
                                field[braveRow + 1, braveCol] = '-';
                                field[braveRow, braveCol] = '-';
                                braveRow = field.GetLength(0) - 1;
                                if (char.IsLower(letter1))
                                {
                                    woodsSymb.Add(letter1);
                                }
                            }
                        }
                        else
                        {
                            field[braveRow, braveCol] = 'B';
                            field[braveRow + 1, braveCol] = '-';
                        }
                    }
                    else
                    {
                        if (woodsSymb.Count > 0)
                        {
                            woodsSymb.RemoveAt(woodsSymb.Count - 1);
                        }
                    }
                }
                else if (cmd == "down")
                {
                    if (IsInRange(field, braveRow + 1, braveCol))
                    {
                        braveRow += 1;
                        char letter = field[braveRow, braveCol];
                        if (char.IsLower(letter))
                        {
                            woodsSymb.Add(letter);
                            woods--;
                            field[braveRow, braveCol] = 'B';
                            field[braveRow - 1, braveCol] = '-';
                        }
                        else if (field[braveRow, braveCol] == 'F')
                        {
                            if (braveRow < field.GetLength(0))
                            {
                                field[field.GetLength(0) - 1, braveCol] = 'B';
                                field[braveRow - 1, braveCol] = '-';
                                field[braveRow, braveCol] = '-';
                                braveRow = field.GetLength(0) - 1;
                            }
                            else
                            {
                                char letter1 = field[0, braveCol];
                                field[0, braveCol] = 'B';
                                field[braveRow - 1, braveCol] = '-';
                                field[braveRow, braveCol] = '-';
                                braveRow = 0;
                                if (char.IsLower(letter1))
                                {
                                    woodsSymb.Add(letter1);
                                }
                            }
                        }
                        else
                        {
                            field[braveRow, braveCol] = 'B';
                            field[braveRow - 1, braveCol] = '-';
                        }
                    }
                    else
                    {
                        if (woodsSymb.Count > 0)
                        {
                            woodsSymb.RemoveAt(woodsSymb.Count - 1);
                        }
                    }
                }
                else if (cmd == "left")
                {
                    if (IsInRange(field, braveRow, braveCol - 1))
                    {
                        braveCol -= 1;
                        char letter = field[braveRow, braveCol];
                        if (char.IsLower(letter))
                        {
                            woodsSymb.Add(letter);
                            woods--;
                            field[braveRow, braveCol] = 'B';
                            field[braveRow, braveCol + 1] = '-';
                        }
                        else if (field[braveRow, braveCol] == 'F')
                        {
                            if (braveCol > 0)
                            {
                                field[braveRow, 0] = 'B';
                                field[braveRow, braveCol + 1] = '-';
                                field[braveRow, braveCol] = '-';
                                braveCol = 0;
                            }
                            else
                            {
                                char letter1 = field[braveRow, field.GetLength(1) - 1];
                                field[braveRow, field.GetLength(1) - 1] = 'B';
                                field[braveRow, braveCol + 1] = '-';
                                field[braveRow, braveCol] = '-';
                                braveCol = field.GetLength(1) - 1;
                                if (char.IsLower(letter1))
                                {
                                    woodsSymb.Add(letter1);
                                }
                            }
                        }
                        else
                        {
                            field[braveRow, braveCol] = 'B';
                            field[braveRow, braveCol + 1] = '-';
                        }
                    }
                    else
                    {
                        if (woodsSymb.Count > 0)
                        {
                            woodsSymb.RemoveAt(woodsSymb.Count - 1);
                        }
                    }
                }
                else if (cmd == "right")
                {
                    if (IsInRange(field, braveRow, braveCol + 1))
                    {
                        braveCol += 1;
                        char letter = field[braveRow, braveCol];
                        if (char.IsLower(letter))
                        {
                            woodsSymb.Add(letter);
                            woods--;
                            field[braveRow, braveCol] = 'B';
                            field[braveRow, braveCol - 1] = '-';
                        }
                        else if (field[braveRow, braveCol] == 'F')
                        {
                            if (braveRow < field.GetLength(1))
                            {
                                field[braveRow, field.GetLength(1) - 1] = 'B';
                                field[braveRow, braveCol - 1] = '-';
                                field[braveRow, braveCol] = '-';
                                braveCol = field.GetLength(1) - 1;
                            }
                            else
                            {
                                char letter1 = field[braveRow, 0];
                                field[braveRow, 0] = 'B';
                                field[braveRow, braveCol - 1] = '-';
                                field[braveRow, braveCol] = '-';
                                braveCol = 0;
                                if (char.IsLower(letter1))
                                {
                                    woodsSymb.Add(letter1);
                                }
                            }
                        }
                        else
                        {
                            field[braveRow, braveCol] = 'B';
                            field[braveRow, braveCol - 1] = '-';
                        }
                    }
                    else
                    {
                        if (woodsSymb.Count > 0)
                        {
                            woodsSymb.RemoveAt(woodsSymb.Count - 1);
                        }
                    }
                }
                cmd = Console.ReadLine();
            }
            if (woods == 0)
            {
                Console.Write($"The Beaver successfully collect {woodsSymb.Count} wood branches: ");
                Console.WriteLine($"{string.Join(", ", woodsSymb)}.");
            }
            else
            {
                Console.WriteLine($"The Beaver failed to collect every wood branch. There are {woods} branches left.");
            }
            for (int rows = 0; rows < field.GetLength(0); rows++)
            {
                for (int cols = 0; cols < field.GetLength(1); cols++)
                {
                    Console.Write($"{field[rows, cols]} ");
                }
                Console.WriteLine();
            }
        }

        private static bool IsInRange(char[,] matrix, int row, int col)
        {
            return row >= 0 && row < matrix.GetLength(0) &&
                   col >= 0 && col < matrix.GetLength(1);
        }
    }
}
