using ToyRobot.Library.Model;

namespace ToyRobot.Library.Commands
{
    public class LeftCommand : CommandBase
    {
        public override string Name => "LEFT";
        public override string Regex_Pattern => @"^Left$";

        public override GenericRobot Execute(GenericRobot genericRobot)
        {
            var currentPosition = (Position)genericRobot.CurrentPosition.Clone();
            var direction = currentPosition.Direction;
            var position = direction.TurnLeft(currentPosition);
            genericRobot.CurrentPosition = position;
            return genericRobot;
        }
    }
}