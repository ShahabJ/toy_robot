using ToyRobot.Library.Model;

namespace ToyRobot.Library.Interface
{
    public interface ITurnable
    {
        Position TurnLeft(Position position);
        Position TurnRight(Position position);
    }
}