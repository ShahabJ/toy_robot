using System;
using FluentAssertions;
using ToyRobot.Library.Interface;
using ToyRobot.Library.Model;
using ToyRobot.Library.Service;
using Xunit;

namespace ToyRobot.Test.ServiceFixtures
{
    public class EastDirectionFixture
    {
        private IDirection direction ;
        private Position position; 
        private readonly int x = 0;
        private readonly int y = 0;

        public EastDirectionFixture()
        {
            direction = new EastDirection();
            position = new Position(x, y, Enum.Parse<DirectionEnum>(direction.GetName()));
        }

        [Fact]
        public void MoveShouldOnlyIncreaseX_Position()
        {
            position = direction.Move(position);
            position.X.Should().Be(x+1);
            position.Y.Should().Be(y);
            position.Direction.Should().BeOfType<EastDirection>();
        }

        [Fact]
        public void TurnLeftShouldOnlyChangeDirection()
        {
            position = direction.TurnLeft(position);
            position.X.Should().Be(x);
            position.Y.Should().Be(y);
            position.Direction.Should().BeOfType<NorthDirection>();
        }

        [Fact]
        public void TurnRightShouldOnlyChangeDirection()
        {
            position = direction.TurnRight(position);
            position.X.Should().Be(x);
            position.Y.Should().Be(y);
            position.Direction.Should().BeOfType<SouthDirection>();
        }
    }
}