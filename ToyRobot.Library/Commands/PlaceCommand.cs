using System;
using System.Text.RegularExpressions;
using ToyRobot.Library.CustomException;
using ToyRobot.Library.Model;
using ToyRobot.Library.Service;

namespace ToyRobot.Library.Commands
{
    public class PlaceCommand : CommandBase
    {
        char[] CMD_SPLITTER = new char[] { ' ', ',' };
        int X_INDEX = 1;
        int Y_INDEX = 2;
        int DIRECTION_INDEX = 3;
        private Position targetPosition;

        public override string Name => "PLACE";
        public override string Regex_Pattern => @"^PLACE \d{1,},\d{1,},(NORTH|SOUTH|EAST|WEST$)";
        public override GenericRobot Execute(GenericRobot genericRobot)
        {
            if (targetPosition == null) 
            {
                throw new RobotException(CustomExceptionMessageConstants.INVALID_TARGET_POSITION);
            }

            //Set current Direction to targetPosition to keep current Direction
            if (genericRobot.CurrentPosition != null)
            {
                targetPosition.Direction = genericRobot.CurrentPosition.Direction;
            }

            genericRobot.CurrentPosition = targetPosition;
            targetPosition = null;
            return genericRobot;
        }


        //place is special command, every time validated, save the position details
        public override bool IsValidCommand(string commandName)
        {
            var isValid = Regex.Match(commandName, Regex_Pattern, RegexOptions.IgnoreCase).Success;
            if (isValid)
            {
                this.targetPosition = ParsePlace(commandName);
            }
            return isValid;

        }
        private Position ParsePlace(string commandName)
        {
            var str = commandName.Split(CMD_SPLITTER);
            var x = int.Parse(str[X_INDEX]);
            var y = int.Parse(str[Y_INDEX]);
            return new Position(x, y, Enum.Parse<DirectionEnum>(str[DIRECTION_INDEX].ToUpper()));
        }
    }
}