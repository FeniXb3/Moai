using System;

namespace Moai
{
    internal struct Vector2
    {
        public int x;
        public int y;

        public Vector2(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        internal Vector2 Add(Vector2 other)
        {
            return new Vector2(x + other.x, y + other.y);
        }
    }
}