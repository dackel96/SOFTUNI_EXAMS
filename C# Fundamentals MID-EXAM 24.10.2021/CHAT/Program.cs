using System;
using System.Collections.Generic;
using System.Linq;

namespace CHAT
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> chat = new List<string>();
            string[] input = Console.ReadLine().Split().ToArray();
            while (input[0] != "end")
            {
                if (input[0] == "Chat")
                {
                    chat.Add(input[1]);
                }
                if (input[0] == "Delete" && chat.Contains(input[1]))
                {
                    chat.Remove(input[1]);
                }
                if (input[0] == "Edit" && chat.Contains(input[1]))
                {
                    for (int i = 0; i < chat.Count; i++)
                    {
                        if (chat[i] == input[1])
                        {
                            chat[i] = input[2];
                        }
                    }

                }
                if (input[0] == "Pin" && chat.Contains(input[1]))
                {
                    for (int i = 0; i < chat.Count; i++)
                    {
                        if (chat[i] == input[1])
                        {
                            chat.RemoveAt(i);
                            chat.Add(input[1]);
                        }
                    }
                }
                if (input[0] == "Spam")
                {
                    for (int i = 1; i < input.Length; i++)
                    {
                        chat.Add(input[i]);
                    }
                }
                input = Console.ReadLine().Split().ToArray();
            }
            for (int i = 0; i < chat.Count; i++)
            {
                Console.WriteLine(chat[i]);
            }

        }
    }
}

