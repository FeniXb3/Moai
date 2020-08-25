﻿using System;

namespace Moai
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Who are you, Stranger?");
            string name = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(name))
            {
                Console.WriteLine("I will still call you Stranger, then.");
                name = "Stranger";
            }
            else if (name.ToLower() == "stranger")
            {
                Console.WriteLine("Ha! I knew it!");
            }


            Console.WriteLine($"Where are you from, {name}?");
            string place = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(place))
            {
                Console.WriteLine("You are not too talkative, are you?");
                place = "Nowhere";
            }

            Console.WriteLine($"Welcome to Moai, {name} from {place}!");

            Console.Write("Press any key to continue...");
            Console.ReadKey(true);

            string[] level = {
                "#########",
                "#    #  #",
                "#   ##  #",
                "#    #  #",
                "#    #  #",
                "#       #",
                "#    #  #",
                "#########"
            };

            /*
            https://ascii.co.uk/art/scroll
                 _______________
            ()==(              (@==()
                 '______________'|
                   |             |
                   |             |
                 __)_____________|
            ()==(               (@==()
                 '--------------'
                                  PjP
            */

            string[] scroll = {
                "     _______________",
                "()==(              (@==()",
                "     '______________'|",
                "       |             |",
                "       |             |",
                "     __)_____________|    ",
                "()==(               (@==()",
                "     '--------------'    ",
                "                      PjP"
            };

            Console.Clear();
            Console.WriteLine("Wanna see the map? Press any key until it is revealed...");

            int scrollHalf = scroll.Length / 2;
            for (int i = 0; i < scrollHalf; i++)
            {
                Console.WriteLine(scroll[i]);
            }

            int nextMapRowPosition = Console.CursorTop;
            foreach (string row in level)
            {
                Console.SetCursorPosition(0, nextMapRowPosition);
                Console.WriteLine($"       |  {row}  |");

                for (int i = scrollHalf; i < scroll.Length; i++)
                {
                    Console.WriteLine(scroll[i]);
                }
                nextMapRowPosition++;
                Console.ReadKey(true);
            }

            Console.Clear();
            foreach (string row in level)
            {
                Console.WriteLine(row);
            }

            int playerColumn = 2;
            int playerRow = 3;

            while (true)
            {
                Console.SetCursorPosition(playerColumn, playerRow);
                Console.Write("@");

                ConsoleKeyInfo keyInfo = Console.ReadKey(true);

                Console.SetCursorPosition(playerColumn, playerRow);
                string currentRow = level[playerRow];
                char currentCell = currentRow[playerColumn];
                Console.Write(currentCell);

                int targetColumn = playerColumn;
                int targetRow = playerRow;

                if (keyInfo.Key == ConsoleKey.LeftArrow)
                {
                    targetColumn = playerColumn - 1;
                }
                else if (keyInfo.Key == ConsoleKey.RightArrow)
                {
                    targetColumn = playerColumn + 1;
                }
                else if (keyInfo.Key == ConsoleKey.UpArrow)
                {
                    targetRow = playerRow - 1;
                }
                else if (keyInfo.Key == ConsoleKey.DownArrow)
                {
                    targetRow = playerRow + 1;
                }

                if (targetColumn >= 0 && targetColumn < level[playerRow].Length)
                {
                    playerColumn = targetColumn;
                }
                
                if (targetRow >= 0 && targetRow < level.Length)
                {
                    playerRow = targetRow;
                }
            }

            Console.SetCursorPosition(0, level.Length);
        }
    }
}
