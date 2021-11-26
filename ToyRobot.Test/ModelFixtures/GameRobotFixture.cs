using System;
using FluentAssertions;
using ToyRobot.Library.CustomException;
using ToyRobot.Library.Model;
using ToyRobot.Library.Service;
using Xunit;

namespace ToyRobot.Test.ModelFixtures
{
    public class GameRobotFixture
    {
        private readonly GenericTable table;
        private GenericRobot robot;
        private Position position ;
        public GameRobotFixture()
        {
            table = new GameTable();
            robot = new GameRobot(table);
        }

        [Fact]
        public void IsPlacedOnTableShouldReturnFalseWhenRobotPositionIsNotSet()
        {
            robot.IsPlacedOnTable().Should().BeFalse();
        }

        [Fact]
        public void IsPlacedOnTableShouldReturnTrueWhenRobotPositionIsSet()
        {
            position = new Position(0,0,DirectionEnum.NORTH);
            robot.CurrentPosition = position ;
            robot.IsPlacedOnTable().Should().BeTrue();
        }

        [Fact]
        public void SetCurrentPositionShouldThrowExceptionWhenPositionIsOutOfTable()
        {
            position = new Position(0,10,DirectionEnum.NORTH);
            Action action = () => robot.CurrentPosition =  position;
            action.Should().Throw<RobotException>()
                           .WithMessage(CustomExceptionMessageConstants.DROP_OFF_TABLE);
        }
    }
}