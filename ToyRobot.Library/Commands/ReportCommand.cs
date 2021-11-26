using ToyRobot.Library.Model;

namespace ToyRobot.Library.Commands
{
    public class ReportCommand : CommandBase
    {
        public override string Name => "REPORT";
        public override string Regex_Pattern => @"^Report$";

        public override GenericRobot Execute(GenericRobot genericRobot)
        {
            Position currentPosition = genericRobot.CurrentPosition;
 		    System.Console.WriteLine(currentPosition.ToString());
		    return genericRobot;
        }
    }
}