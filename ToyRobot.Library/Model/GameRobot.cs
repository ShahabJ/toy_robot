using ToyRobot.Library.CustomException;

namespace ToyRobot.Library.Model
{
    public class GameRobot : GenericRobot
    {
        private readonly GenericTable table;

        public GameRobot(GenericTable table)
        {
            this.table = table;
        }

        private Position currentPosition;
        public override Position CurrentPosition
        {
            get => this.currentPosition;
            set
            {
                // if the generated position is outside the range of the table, throw the exception 
                if (!table.IsOnTheTable(value))
                {
                    throw new RobotException(CustomExceptionMessageConstants.DROP_OFF_TABLE);
                }
                this.currentPosition = value;
            }
        }

        public override bool IsPlacedOnTable() => CurrentPosition != null;
    }
}