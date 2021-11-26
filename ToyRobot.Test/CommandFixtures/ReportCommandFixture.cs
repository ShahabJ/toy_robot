using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using ApprovalTests;
using ApprovalTests.Reporters;
using FluentAssertions;
using ToyRobot.Library.Commands;
using ToyRobot.Library.Model;
using ToyRobot.Library.Service;
using Xunit;

namespace ToyRobot.Test
{
    public class ReportCommandFixture
    {
        private CommandBase command;
        private GenericRobot robot;
        private GenericTable table;
        public ReportCommandFixture()
        {
            command = new ReportCommand();
            table = new GameTable();
            robot = new GameRobot(table);
        }

        [Theory]
        [InlineData("REPORT",true)]
        [InlineData("Report",true)]
        [InlineData("report",true)]
        [InlineData("Report ",false)]
        [InlineData(" report",false)]
        [InlineData("report 1",false)]
        [InlineData("Right",false)]
        [InlineData("troper",false)]
        public void IsValidCommandShouldReturnExpectedResultForCommandName(string commandName, bool expected)
        {
            command.IsValidCommand(commandName).Should().Be(expected);
        }

        [UseReporter(typeof(DiffReporter))]
        [Fact]
        public void ExecuteReport()
        {
            var fakeoutput = new StringBuilder();
            Console.SetOut(new StringWriter(fakeoutput));
            Console.SetIn(new StringReader("a\n"));

            var positions = new List<Position>();
            
            positions.Add(new Position(0, 0, DirectionEnum.NORTH));
            positions.Add(new Position(0, 0, DirectionEnum.EAST));
            positions.Add(new Position(1, 0, DirectionEnum.WEST));
            positions.Add(new Position(0, 1, DirectionEnum.SOUTH));

            foreach (var position in positions)
            {
                robot.CurrentPosition = position;
                command.Execute(robot);
            }
            
            var output = fakeoutput.ToString();
            Approvals.Verify(output);
        }

    }
}
