using System.Collections.Generic;
using ApprovalTests;
using ApprovalTests.Reporters;
using ToyRobot.Library.Model;
using ToyRobot.Library.Service;
using Xunit;

namespace ToyRobot.Test.ModelFixtures
{
    [UseReporter(typeof(DiffReporter))]
    public class GameTableFixture
    {
        int minX = 0;
        int minY = 0;
        int maxX = 6;
        int maxY = 6;

        [Fact]
        public void ExecureReport()
        {
            var table = new GameTable(minX, minY, maxX, maxY);
            var result = new List<string>();
            //Header for a test report
            result.Add($"Assertion for GameTable: Min X:{minX},Min Y:{minY}. Max X:{maxX}, Y:{maxY}");

            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    var onTheTable = table.IsOnTheTable(new Position(i, j, DirectionEnum.NORTH)) ? "OnTheTable" : "NotOnTheTable";
                    result.Add($"X:{i},y:{j} => {onTheTable}");
                }
            }

            Approvals.VerifyAll(result, "");
        }
    }
}