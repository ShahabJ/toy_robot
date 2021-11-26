
using ToyRobot.Library.Interface;
using ToyRobot.Library.Model;

namespace ToyRobot.Library.Service
{
    public class NorthDirection : IDirection
    {
        private int MOVE_STEP = 1;

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public string GetName() => DirectionEnum.NORTH.ToString();

        public Position Move(Position position)
        {
            position.Y += MOVE_STEP;
            return position;
        }

        public override string ToString()
        {
            return base.ToString();
        }

        public Position TurnLeft(Position position)
        {
            position.Direction = DirectionFactory.CreateDirection(DirectionEnum.WEST);
            return position;
        }

        public Position TurnRight(Position position)
        {
            position.Direction = DirectionFactory.CreateDirection(DirectionEnum.EAST);
            return position;
        }
    }


}