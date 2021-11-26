using FluentAssertions;
using ToyRobot.Library.Commands;
using ToyRobot.Library.Handler;
using ToyRobot.Library.Interface;
using ToyRobot.Library.Model;
using ToyRobot.Library.Service;
using Xunit;

namespace ToyRobot.Test.ModelFixtures
{
    public class GameConsoleFixture
    {
        GameConsole gameConsole;
        GenericRobot robot;
        GenericTable table;
        IInputData inputData;
        CommandsHandler commandsHandler;
        public GameConsoleFixture()
        {
            table = new GameTable();
            robot = new GameRobot(table);
            commandsHandler = new CommandsHandler();
            commandsHandler.Register(new LeftCommand());
            commandsHandler.Register(new RightCommand());
            commandsHandler.Register(new MoveCommand());
            commandsHandler.Register(new PlaceCommand());
            commandsHandler.Register(new ReportCommand());
        }

        [Theory]
        [InlineData("./ModelFixtures/TestCaseData/test_case_a.txt", "0,1,NORTH")]
        [InlineData("./ModelFixtures/TestCaseData/test_case_b.txt", "0,0,WEST")]
        [InlineData("./ModelFixtures/TestCaseData/test_case_c.txt", "3,3,NORTH")]
        [InlineData("./ModelFixtures/TestCaseData/test_case_d.txt", "5,3,NORTH")]
        [InlineData("./ModelFixtures/TestCaseData/test_case_e.txt", "5,4,NORTH")]
        [InlineData("./ModelFixtures/TestCaseData/test_case_f.txt", "3,2,NORTH")]
        public void PlayShouldSetCuurentPositionWhenAllCommandExecuted(string path, string expected)
        {
            inputData = new InputDataFromFile(path);
            gameConsole = new GameConsole(robot, inputData, commandsHandler);
            var genericRobot = gameConsole.Play();
            genericRobot.CurrentPosition.ToString().Should().Be(expected);
        }
    }
}