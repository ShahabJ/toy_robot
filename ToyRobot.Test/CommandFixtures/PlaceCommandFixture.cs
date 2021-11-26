using System;
using FluentAssertions;
using ToyRobot.Library.Commands;
using ToyRobot.Library.CustomException;
using ToyRobot.Library.Model;
using ToyRobot.Library.Service;
using Xunit;

namespace ToyRobot.Test
{
    public class PlaceCommandFixture
    {
        private CommandBase command;
        private GenericRobot robot;
        private GenericTable table;
        public PlaceCommandFixture()
        {
            command = new PlaceCommand();
            table = new GameTable();
            robot = new GameRobot(table);
        }

        [Theory]
        [InlineData("PLACE 0,0,SOUTH", true)]
        [InlineData("PLACE 0,0,NORTH", true)]
        [InlineData("PLACE 0,0,north", true)]
        [InlineData("PLACE ,0,0,SOUTH", false)]
        [InlineData("PLACE 0 ,0,SOUTH", false)]
        [InlineData("PLACE 0 0,SOUTH", false)]
        public void IsValidCommandShouldReturnExpectedResultForCommandName(string commandName, bool expected)
        {
            command.IsValidCommand(commandName).Should().Be(expected);
        }

        [Fact]
        public void ExecuteShuldThrowExceptionWhenTargetPositionNotSetThroughIsInvalidCommand()
        {
            robot.CurrentPosition = new Position(1, 2, DirectionEnum.NORTH);
            Action action = () => command.Execute(robot);

            action.Should().Throw<RobotException>()
                           .WithMessage(CustomExceptionMessageConstants.INVALID_TARGET_POSITION);

        }

        [Fact]
        public void ExecuteShuldPlaceRobotWhenRobotIsNotOnTheTable()
        {
            command.IsValidCommand("PLACE 1,3,NORTH");
            robot = command.Execute(robot);

            robot.CurrentPosition.X.Should().Be(1);
            robot.CurrentPosition.Y.Should().Be(3);
            robot.CurrentPosition.Direction.GetName().Should().Be(DirectionEnum.NORTH.ToString());
        }

        [Fact]
        public void ExecuteShuldPlaceRobotWithoutChangindDirectionWhenRobotIsOnTheTable()
        {
            //Place robot on the table for first time
            command.IsValidCommand("PLACE 1,3,NORTH");
            robot = command.Execute(robot);

            //Need to call IsValidCommand for second Place Command
            command.IsValidCommand("PLACE 4,5,EAST");
            robot = command.Execute(robot);

            robot.CurrentPosition.X.Should().Be(4);
            robot.CurrentPosition.Y.Should().Be(5);
            robot.CurrentPosition.Direction.GetName().Should().Be(DirectionEnum.NORTH.ToString());
        }
    }
}
