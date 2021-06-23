using System;

namespace Moai
{
    class Display
    {
        public static void WriteAt(int columnNumber, int rowNumber, string text)
        {
            Console.SetCursorPosition(columnNumber, rowNumber);
            Console.Write(text);
        }
        public static void WriteAt(int columnNumber, int rowNumber, char sign)
        {
            Console.SetCursorPosition(columnNumber, rowNumber);
            Console.Write(sign);
        }

        internal static void WriteAt(Vector2 position, string text)
        {
            WriteAt(position.x, position.y, text);
        }

        internal static void WriteAt(Vector2 position, char sign)
        {
            WriteAt(position.x, position.y, sign);
        }

        public static void WriteArrayAt(Vector2 position, string[] array)
        {
            int rowNumber = 0;
            foreach (string item in array)
            {
                if (!string.IsNullOrEmpty(item))
                {
                    Display.WriteAt(position.x, position.y + rowNumber, item);
                    rowNumber++;
                }
            }
        }
    }
}
