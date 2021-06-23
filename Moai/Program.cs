using System;
using System.Collections.Generic;

namespace Moai
{
    class Program
    {
        static Dictionary<ConsoleKey, Vector2> inputDirections = new Dictionary<ConsoleKey, Vector2>
        {
            { ConsoleKey.LeftArrow, new Vector2(-1, 0) },
            { ConsoleKey.A, new Vector2(-1, 0) },
            { ConsoleKey.RightArrow, new Vector2(1, 0) },
            { ConsoleKey.D, new Vector2(1, 0) },
            { ConsoleKey.UpArrow, new Vector2(0, -1) },
            { ConsoleKey.W, new Vector2(0, -1) },
            { ConsoleKey.DownArrow, new Vector2(0, 1) },
            { ConsoleKey.S, new Vector2(0, 1) },
        };

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
                "#....#..#",
                "#...##..#",
                "#....#..#",
                "#....#..#",
                "#.......#",
                "#....#..#",
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
            Display.WriteArrayAt(new Vector2(0, 0), level);

            Player player = new Player(2, 3, "@");
            player.inventory[0] = "key";
            player.inventory[3] = "ring";

            while (true)
            {
                Vector2 inventoryPosition = new Vector2(level[0].Length + 2, 1);

                Display.WriteAt(inventoryPosition.x, inventoryPosition.y - 1, "Inventory:");
                Display.WriteArrayAt(inventoryPosition, player.inventory);

                Display.WriteAt(player.position, player.avatar);

                ConsoleKeyInfo keyInfo = Console.ReadKey(true);

                string currentRow = level[player.position.y];
                char currentCell = currentRow[player.position.x];
                Display.WriteAt(player.position, currentCell);

                Vector2 targetPosition = player.position;

                if (keyInfo.Key == ConsoleKey.Escape)
                {
                    break;
                }

                if (inputDirections.ContainsKey(keyInfo.Key))
                {
                    Vector2 diff = inputDirections[keyInfo.Key];
                    targetPosition = player.position.Add(diff);
                }

                if (targetPosition.y >= 0 && targetPosition.y < level.Length
                    && targetPosition.x >= 0 && targetPosition.x < level[targetPosition.y].Length
                    && level[targetPosition.y][targetPosition.x] != '#')
                {
                    player.position = targetPosition;
                }
            }

            Console.SetCursorPosition(0, level.Length);
        }
    }
}
