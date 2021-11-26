using System;
using FluentAssertions;
using ToyRobot.Library.Commands;
using ToyRobot.Library.CustomException;
using ToyRobot.Library.Handler;
using ToyRobot.Library.Model;
using ToyRobot.Library.Service;
using Xunit;

namespace ToyRobot.Test.HandlerFixtures
{
    public class CommandsHandlerFixture
    {
        private CommandsHandler commandsHandler;
        private GenericRobot robot;
        private GenericTable table;

        public CommandsHandlerFixture()
        {
            table = new GameTable();
            robot = new GameRobot(table);
            robot.CurrentPosition = new Position(0, 0, DirectionEnum.NORTH);
            commandsHandler = new CommandsHandler();
            commandsHandler.Register(new LeftCommand());
            commandsHandler.Register(new RightCommand());
            commandsHandler.Register(new MoveCommand());
            commandsHandler.Register(new PlaceCommand());
            commandsHandler.Register(new ReportCommand());
        }

        [Fact]
        public void ExecuteCommnadShouldReturnCorrectResul()
        {
            GenericRobot genericRobot;

            genericRobot = commandsHandler.ExecuteCommand("MOVE", robot);
            genericRobot.CurrentPosition.Should().BeEquivalentTo(new Position(0, 1, DirectionEnum.NORTH));

            genericRobot = commandsHandler.ExecuteCommand("LEFT", robot);
            genericRobot.CurrentPosition.Should().BeEquivalentTo(new Position(0, 1, DirectionEnum.WEST));

            genericRobot = commandsHandler.ExecuteCommand("RIGHT", robot);
            genericRobot.CurrentPosition.Should().BeEquivalentTo(new Position(0, 1, DirectionEnum.NORTH));

            genericRobot = commandsHandler.ExecuteCommand("REPORT", robot);
            genericRobot.CurrentPosition.Should().BeEquivalentTo(new Position(0, 1, DirectionEnum.NORTH));

            genericRobot = commandsHandler.ExecuteCommand("PLACE 0,0,NORTH", robot);
            genericRobot.CurrentPosition.Should().BeEquivalentTo(new Position(0, 0, DirectionEnum.NORTH));
        }

        [Theory]
        [InlineData("invalid cmd")]
        [InlineData("Place 0,0,UP")]
        public void ExecuteCommandShouldThrowRobotExceptionForInvalidCommand(string cmd)
        {
            Action action = () => commandsHandler.ExecuteCommand(cmd, robot);
            action.Should().Throw<RobotException>()
                        .WithMessage(CustomExceptionMessageConstants.INVALID_CMD);

        }

        [Fact]
        public void ExecuteCommandShouldThrowRobotExceptionForRemovedCommand()
        {
            var cmd = "LEFT";
            commandsHandler.Remove(cmd);
            Action action = () => commandsHandler.ExecuteCommand(cmd, robot);
            action.Should().Throw<RobotException>()
                        .WithMessage(CustomExceptionMessageConstants.INVALID_CMD);

        }
    }
}