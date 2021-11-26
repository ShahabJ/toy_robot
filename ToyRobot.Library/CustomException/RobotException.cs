using System;
using System.Collections.Generic;

namespace ToyRobot.Library.CustomException
{
    public class RobotException : Exception
    {
        public RobotException(string message) :base (message)
        {
        }
    }
}