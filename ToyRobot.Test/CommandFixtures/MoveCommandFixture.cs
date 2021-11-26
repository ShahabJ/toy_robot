using System.Collections.Generic;
using ApprovalTests;
using ApprovalTests.Reporters;
using FluentAssertions;
using ToyRobot.Library.Commands;
using ToyRobot.Library.Model;
using ToyRobot.Library.Service;
using Xunit;

namespace ToyRobot.Test
{
    public class MoveCommandFixture
    {
        private CommandBase command;
        private GenericRobot robot;
        private GenericTable table;
        public MoveCommandFixture()
        {
            command = new MoveCommand();
            table = new GameTable();
            robot = new GameRobot(table);
        }

        [Theory]
        [InlineData("MOVE")]
        [InlineData("move")]
        [InlineData("Move")]
        public void IsValidCommandShouldReturnTrueFor(string commandName)
        {
            command.IsValidCommand(commandName).Should().BeTrue();
        }

        [Theory]
        [InlineData("Move ")]
        [InlineData(" move")]
        [InlineData("move 1")]
        [InlineData("LEFT")]
        [InlineData("EVOM")]
        public void IsValidCommandShouldReturnFalseFor(string commandName)
        {
            command.IsValidCommand(commandName).Should().BeFalse();
        }

        [UseReporter(typeof(DiffReporter))]
        [Fact]
        public void ExecuteReport()
        {   
            var result = new List<string>();
            var positions = new List<Position>();
            
            positions.Add(new Position(0, 0, DirectionEnum.NORTH));
            positions.Add(new Position(0, 0, DirectionEnum.EAST));
            positions.Add(new Position(1, 0, DirectionEnum.WEST));
            positions.Add(new Position(0, 1, DirectionEnum.SOUTH));

            foreach (var position in positions)
            {
                robot.CurrentPosition = position;
                string currentPosition = robot.CurrentPosition.ToString();
                string newPosition = command.Execute(robot).CurrentPosition.ToString();
                result.Add($"Position before move:{currentPosition}, Position After move:{newPosition}");
            }

            Approvals.VerifyAll(result,"Verifyinng Move Commnad => ");
        }
    }
}
