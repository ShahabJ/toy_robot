using ToyRobot.Library.Model;

namespace ToyRobot.Library.Commands
{
    public class RightCommand : CommandBase
    {
        public override string Name => "RIGHT";
        public override string Regex_Pattern => @"^Right$";

        public override GenericRobot Execute(GenericRobot genericRobot)
        {
            var currentPosition = (Position)genericRobot.CurrentPosition.Clone();
            var direction = currentPosition.Direction;		
            var position =  direction.TurnRight(currentPosition);
            genericRobot.CurrentPosition =position ;
            return genericRobot;
        }
    }
}