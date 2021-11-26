using ToyRobot.Library.Model;

namespace ToyRobot.Library.Commands
{
    public class MoveCommand : CommandBase
    {
        public override string Name => "MOVE";
        public override string Regex_Pattern => @"^Move$";

        public override GenericRobot Execute(GenericRobot genericRobot)
        {
            var currentPosition = (Position)genericRobot.CurrentPosition.Clone();
            var direction = currentPosition.Direction;		
            var position =  direction.Move(currentPosition);
            genericRobot.CurrentPosition = position ;
            return genericRobot;
        }
    }
}