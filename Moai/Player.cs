namespace Moai
{
    class Player
    {
        public int x;
        public int y;
        public string avatar;
        public string[] inventory;

        public Player(int x, int y, string avatar)
        {
            this.x = x;
            this.y = y;
            this.avatar = avatar;
            this.inventory = new string[7];
        }
    }
}
