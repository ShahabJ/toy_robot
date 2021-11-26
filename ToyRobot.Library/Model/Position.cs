using System;
using ToyRobot.Library.Interface;
using ToyRobot.Library.Service;

namespace ToyRobot.Library.Model
{
    public class Position : ICloneable
    {
        public int X { get; set; }
        public int Y { get; set; }
        public IDirection Direction { get; set; }
        public Position(int x, int y , DirectionEnum directionEnum)
        {
            this.Y = y;
            this.X = x;
            this.Direction = DirectionFactory.CreateDirection(directionEnum);
        }

        public override string ToString()
        {
            return $"{X},{Y},{Direction.GetName()}";
        }

        public object Clone() 
        {
            return new Position (this.X, this.Y, Enum.Parse<DirectionEnum>(this.Direction.GetName().ToUpper()));
        }
    }
}