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
    public class RightCommandFixture
    {
        private CommandBase command;
        private GenericRobot robot;
        private GenericTable table;
        public RightCommandFixture()
        {
            command = new RightCommand();
            table = new GameTable();
            robot = new GameRobot(table);
        }
        [Theory]
        [InlineData("Right")]
        [InlineData("right")]
        [InlineData("RIGHT")]
        public void IsValidCommandShouldReturnTrueFor(string commandName)
        {
            command.IsValidCommand(commandName).Should().BeTrue();
        }

        [Theory]
        [InlineData("Right ")]
        [InlineData(" right")]
        [InlineData("right 1")]
        [InlineData("1 RIGHT")]
        [InlineData("IHGIR")]
        public void IsValidCommandShouldReturnFalseFor(string commandName)
        {
            command.IsValidCommand(commandName).Should().BeFalse();
        }

        [Fact]
        [UseReporter(typeof(DiffReporter))]
        public void ExecuteReport()
        {   
            var result = new List<string>();
            var positions = new List<Position>();
            
            positions.Add(new Position(0, 0, DirectionEnum.NORTH));
            positions.Add(new Position(0, 0, DirectionEnum.EAST));
            positions.Add(new Position(0, 0, DirectionEnum.WEST));
            positions.Add(new Position(0, 0, DirectionEnum.SOUTH));

            foreach (var position in positions)
            {
                robot.CurrentPosition = position;
                string currentPosition = robot.CurrentPosition.ToString();
                string newPosition = command.Execute(robot).CurrentPosition.ToString();
                result.Add($"Position before TurnRight:{currentPosition}, Position After TurnRight:{newPosition}");
            }

            Approvals.VerifyAll(result,"Verifyinng Right Commnad => ");
        }
    }

}
