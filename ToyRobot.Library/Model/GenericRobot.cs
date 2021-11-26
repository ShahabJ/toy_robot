using System;

namespace ToyRobot.Library.Model
{
    public abstract class GenericRobot
    {
        public abstract bool IsPlacedOnTable();
        public abstract Position CurrentPosition { get; set; }
    }
}