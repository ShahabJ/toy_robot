namespace ToyRobot.Library.Model
{
    public abstract class GenericTable
    {
        protected int minX;
        protected int minY;
        protected int maxX;
        protected int maxY;
        private int DEFAULT_X = 6;
        private int DEFAULT_Y = 6;

        public GenericTable()
        {
            this.minX = 0;
            this.minY = 0;
            this.maxX = DEFAULT_X;
            this.maxY = DEFAULT_Y;
        }
        public abstract bool IsOnTheTable(Position position);
    }
}