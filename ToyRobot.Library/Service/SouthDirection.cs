
using ToyRobot.Library.Interface;
using ToyRobot.Library.Model;

namespace ToyRobot.Library.Service
{
    public class SouthDirection : IDirection
    {
        private int MOVE_STEP = 1;

        public Position Move(Position position)
        {
            position.Y -= MOVE_STEP;
			return position;
        }
        public string GetName() => DirectionEnum.SOUTH.ToString();

        public Position TurnLeft(Position position)
        {
            position.Direction = DirectionFactory.CreateDirection(DirectionEnum.EAST);
            return position;
        }

        public Position TurnRight(Position position)
        {
            position.Direction = DirectionFactory.CreateDirection(DirectionEnum.WEST);
            return position;
        }
    }


}