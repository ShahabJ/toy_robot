using ToyRobot.Library.CustomException;
using ToyRobot.Library.Interface;
using ToyRobot.Library.Service;

namespace ToyRobot.Library.Model
{
    public class DirectionFactory
    {
        public static IDirection CreateDirection(DirectionEnum directionEnum)
        {
            return directionEnum switch 
            {
                DirectionEnum.NORTH => new NorthDirection(),
                DirectionEnum.EAST => new EastDirection(),
                DirectionEnum.WEST => new WestDirection(),
                DirectionEnum.SOUTH => new SouthDirection(),
                _ => throw new RobotException(CustomExceptionMessageConstants.NOT_IMPLENMENTED),
            };
        }
    }
}