namespace Moai
{
    class Player
    {
        internal Vector2 position;
        public string avatar;
        public string[] inventory;

        public Player(int x, int y, string avatar)
        {
            this.position = new Vector2(x, y);
            this.avatar = avatar;
            this.inventory = new string[7];
        }
    }
}
