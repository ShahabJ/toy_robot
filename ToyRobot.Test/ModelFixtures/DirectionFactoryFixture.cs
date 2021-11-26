using System;
using FluentAssertions;
using ToyRobot.Library.Model;
using ToyRobot.Library.Service;
using Xunit;

namespace ToyRobot.Test.ModelFixtures
{

    public class DirectionFactoryFixture
    {
        [Theory]
        [InlineData(DirectionEnum.NORTH, typeof(NorthDirection))]
        [InlineData(DirectionEnum.EAST, typeof(EastDirection))]
        [InlineData(DirectionEnum.WEST, typeof(WestDirection))]
        [InlineData(DirectionEnum.SOUTH, typeof(SouthDirection))]
        public void CreateDirectionShouldReturnCorretDirectionType(DirectionEnum directionEnum, Type type)
        {
            var direction = DirectionFactory.CreateDirection(directionEnum);
            direction.Should().BeOfType(type);
        }
    }
}