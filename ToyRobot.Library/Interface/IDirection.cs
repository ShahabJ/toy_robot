
using ToyRobot.Library.Service;

namespace ToyRobot.Library.Interface
{
    public interface IDirection : ITurnable, IMoveable
    {
        string GetName();
    }
}