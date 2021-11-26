using System;
using System.Collections.Generic;
using ApprovalTests;
using ApprovalTests.Reporters;
using ToyRobot.Library.Interface;
using ToyRobot.Library.Model;
using ToyRobot.Library.Service;
using Xunit;

namespace ToyRobot.Test.ServiceFixtures
{
    [UseReporter(typeof(DiffReporter))]
    public class DirectionFixture
    {
        private Position position;
        private readonly int x = 1;
        private readonly int y = 1;

        [Fact]
        public void GenerateReport()
        {
            var report = new List<string>();
            var directions = new List<IDirection>()
                {
                    new NorthDirection(),
                    new EastDirection(),
                    new WestDirection(),
                    new SouthDirection()
                };

            foreach (var direction in directions)
            {
                position = new Position(x, y, Enum.Parse<DirectionEnum>(direction.GetName()));
                report.Add($"Current Position:{position},New position after Move:{direction.Move((Position)position.Clone())}");
                report.Add($"Current Position:{position},New position after TurnLeft:{direction.TurnLeft((Position)position.Clone())}");
                report.Add($"Current Position:{position},New position after TurnRigh:{direction.TurnRight((Position)position.Clone())}");
            }
            Approvals.VerifyAll(report, "");
        }
    }
}