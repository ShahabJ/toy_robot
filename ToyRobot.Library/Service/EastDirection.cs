
using ToyRobot.Library.Interface;
using ToyRobot.Library.Model;

namespace ToyRobot.Library.Service
{
    public class EastDirection : IDirection
    {
        private int MOVE_STEP = 1;

        public Position Move(Position position)
        {
			position.X += MOVE_STEP;
			return position;
        }

        public string GetName() => DirectionEnum.EAST.ToString();

        public Position TurnLeft(Position position)
        {
            position.Direction = DirectionFactory.CreateDirection(DirectionEnum.NORTH);
            return position;
        }

        public Position TurnRight(Position position)
        {
            position.Direction = DirectionFactory.CreateDirection(DirectionEnum.SOUTH);
            return position;
        }
    }
}