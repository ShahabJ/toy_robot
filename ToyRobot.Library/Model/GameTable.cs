namespace ToyRobot.Library.Model
{
    public class GameTable : GenericTable
    {
        public GameTable() : base() { }
        public GameTable(int minX, int minY, int maxX, int maxY)
        {
            this.minX = minX;
            this.minY = minY;
            this.maxX = maxX;
            this.maxY = maxY;
        }

        public override bool IsOnTheTable(Position position)
        {
            var x = position.X;
            var y = position.Y;
            return (x >= this.minX && x < this.maxX && y >= this.minY && y < this.maxY);
        }
    }
}