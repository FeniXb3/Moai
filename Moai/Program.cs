using System;

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

            Player player = new Player(2, 3, "@");
            player.inventory[0] = "key";
            player.inventory[3] = "ring";

            while (true)
            {
                int inventoryX = level[0].Length + 2;
                int inventoryY = 0;
                Display.WriteAt(inventoryX, inventoryY++, "Inventory:");

                foreach (var item in player.inventory)
                {
                    if (!string.IsNullOrEmpty(item))
                    {
                        Display.WriteAt(inventoryX, inventoryY++, item);
                    }
                }

                Display.WriteAt(player.x, player.y, player.avatar);

                ConsoleKeyInfo keyInfo = Console.ReadKey(true);

                string currentRow = level[player.y];
                char currentCell = currentRow[player.x];
                Display.WriteAt(player.x, player.y, currentCell);

                Vector2 targetPosition = new Vector2(player.x, player.y);

                if (keyInfo.Key == ConsoleKey.Escape)
                {
                    break;
                }

                switch (keyInfo.Key)
                {
                    case ConsoleKey.LeftArrow:
                    case ConsoleKey.A:
                        targetPosition = new Vector2(player.x - 1, targetPosition.y);
                        break;
                    case ConsoleKey.RightArrow:
                    case ConsoleKey.D:
                        targetPosition = new Vector2(player.x + 1, targetPosition.y);
                        break;
                    case ConsoleKey.UpArrow:
                    case ConsoleKey.W:
                        targetPosition = new Vector2(targetPosition.x, player.y - 1);
                        break;
                    case ConsoleKey.DownArrow:
                    case ConsoleKey.S:
                        targetPosition = new Vector2(targetPosition.x, player.y + 1);
                        break;
                    default:
                        break;
                }

                if (targetPosition.x >= 0 && targetPosition.x < level[player.y].Length && level[player.y][targetPosition.x] != '#')
                {
                    player.x = targetPosition.x;
                }
                
                if (targetPosition.y >= 0 && targetPosition.y < level.Length && level[targetPosition.y][player.x] != '#')
                {
                    player.y = targetPosition.y;
                }
            }

            Console.SetCursorPosition(0, level.Length);
        }
    }
}
