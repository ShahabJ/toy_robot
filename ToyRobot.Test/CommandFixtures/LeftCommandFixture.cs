using System;
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
    [UseReporter(typeof(DiffReporter))]
    public class LeftCommandFixture
    {
        private CommandBase command;
        private GenericRobot robot;
        private GenericTable table;
        public LeftCommandFixture()
        {
            command = new LeftCommand();
            table = new GameTable();
            robot = new GameRobot(table);
        }

        [Fact]
        public void IsValidCommandReport()
        {
            var commands =new String[]{"Left", "left", "LEFT", "LEFT ", "LEFT 1", " LEFT" ,"LFEL"};
            var result = new List<string>();

            foreach (var item in commands)
            {
                var msg = $"{item} ==> {command.IsValidCommand(item)}";
                result.Add(msg);
            }
            Approvals.VerifyAll(result,string.Empty);
        }

        [Fact]
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
                result.Add($"Position before TurnLeft:{currentPosition}, Position After TurnLeft:{newPosition}");
            }

            Approvals.VerifyAll(result,"Verifyinng Left Commnad => ");
        }
    }
}
